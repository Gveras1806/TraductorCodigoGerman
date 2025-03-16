using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace AnalizadorSemantico
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            this.InitializeComponent();

        }


        private void sema_Click(object sender, EventArgs e)
        {
            string code = analizar.Text;
            AnalyzeCode(code);
        }

        private static readonly Dictionary<SyntaxKind, string> TraduccionesTokens = new()
{
    { SyntaxKind.IdentifierToken, "Identificador" },
    { SyntaxKind.NumericLiteralToken, "Número" },
    { SyntaxKind.StringLiteralToken, "Cadena" },
    { SyntaxKind.PlusToken, "Suma" },
    { SyntaxKind.MinusToken, "Resta" },
    { SyntaxKind.AsteriskToken, "Multiplicación" },
    { SyntaxKind.SlashToken, "División" },
    { SyntaxKind.OpenParenToken, "Paréntesis Abierto" },
    { SyntaxKind.CloseParenToken, "Paréntesis Cerrado" },
    { SyntaxKind.OpenBraceToken, "Llave Abierta" },
    { SyntaxKind.CloseBraceToken, "Llave Cerrada" },
    { SyntaxKind.SemicolonToken, "Punto y Coma" },
    { SyntaxKind.EqualsToken, "Asignación" },
    { SyntaxKind.IfKeyword, "Palabra clave:" },
    { SyntaxKind.ElseKeyword, "Palabra clave:" },
    { SyntaxKind.WhileKeyword, "Palabra clave:" },
    { SyntaxKind.ForKeyword, "Palabra clave:" },
    { SyntaxKind.IntKeyword, "Tipo: ENTERO" },
    { SyntaxKind.DoubleKeyword, "Tipo: DECIMAL" },
    { SyntaxKind.StringKeyword, "Tipo: CADENA" },
    { SyntaxKind.BoolKeyword, "Tipo: BOOLEANO" },
    { SyntaxKind.ReturnKeyword, "Palabra clave: " },
    { SyntaxKind.PublicKeyword, "Modificador: PÚBLICO" },
    { SyntaxKind.PrivateKeyword, "Modificador: PRIVADO" }
};


        private void AnalyzeCode(string code)
        {
            salida.Clear();
            txtResultado.Clear();
            semantico.Clear();

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            CompilationUnitSyntax root = syntaxTree.GetCompilationUnitRoot();

            // Análisis Léxico
            foreach (var token in root.DescendantTokens())
            {
                string descripcionToken = TraduccionesTokens.ContainsKey(token.Kind())
                    ? TraduccionesTokens[token.Kind()]
                    : token.Kind().ToString(); // Si no está en el diccionario, usa el nombre original

                salida.Text += Environment.NewLine + $"{descripcionToken} -> '{token.Text}'";
            }
            // Análisis Sintáctico
            foreach (var diagnostic in syntaxTree.GetDiagnostics())
            {
                if (diagnostic.Severity == DiagnosticSeverity.Error)
                {
                    txtResultado.Text += Environment.NewLine + diagnostic.GetMessage();
                }
            }

            // Análisis Semántico
            var compilation = CSharpCompilation.Create("CodeAnalysis")
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddSyntaxTrees(syntaxTree);

            var semanticModel = compilation.GetSemanticModel(syntaxTree);
            foreach (var diagnostic in compilation.GetDiagnostics())
            {
                if (diagnostic.Severity == DiagnosticSeverity.Error)
                {
                    semantico.Text += Environment.NewLine + diagnostic.GetMessage();
                }
            }
        }

        private void LIMP_Click(object sender, EventArgs e)
        {
            salida.Clear();
            txtResultado.Clear();
            semantico.Clear();
            analizar.Clear();
            tra.Clear();
        }
       
        private void btnTraducir_Click(object sender, EventArgs e)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(analizar.Text);
            CompilationUnitSyntax root = syntaxTree.GetCompilationUnitRoot();
            tra.Text = TranslateToCpp(root);

        }

        private string TranslateToCpp(CompilationUnitSyntax root)
        {
            StringBuilder cppCode = new StringBuilder();
            cppCode.AppendLine("#include <iostream>");
            cppCode.AppendLine("using namespace std;\n");

            // Si existen namespaces, recorrerlos; de lo contrario, buscar clases en la raíz
            if (root.Members.Any(m => m is NamespaceDeclarationSyntax))
            {
                foreach (var ns in root.Members.OfType<NamespaceDeclarationSyntax>())
                {
                    foreach (var classDecl in ns.Members.OfType<ClassDeclarationSyntax>())
                    {
                        cppCode.AppendLine(TranslateClassToCpp(classDecl));
                    }
                }
            }
            else
            {
                foreach (var classDecl in root.Members.OfType<ClassDeclarationSyntax>())
                {
                    cppCode.AppendLine(TranslateClassToCpp(classDecl));
                }
            }
            return cppCode.ToString();
        }

        private string TranslateClassToCpp(ClassDeclarationSyntax classDecl)
        {
            StringBuilder classCode = new StringBuilder();
            classCode.AppendLine($"class {classDecl.Identifier.Text} {{");
            classCode.AppendLine("public:");
            foreach (var member in classDecl.Members)
            {
                if (member is MethodDeclarationSyntax methodDecl)
                {
                    classCode.AppendLine(TranslateMethodToCpp(methodDecl));
                }
            }
            classCode.AppendLine("};\n");
            return classCode.ToString();
        }

        private string TranslateMethodToCpp(MethodDeclarationSyntax methodDecl)
        {
            string returnType = MapType(methodDecl.ReturnType.ToString());
            string methodName = methodDecl.Identifier.Text;
            string parameters = string.Join(", ", methodDecl.ParameterList.Parameters.Select(p =>
                MapType(p.Type.ToString()) + " " + p.Identifier.Text));

            StringBuilder methodCode = new StringBuilder();
            methodCode.AppendLine($"    {returnType} {methodName}({parameters}) {{");

            // Si el método tiene cuerpo
            if (methodDecl.Body != null)
            {
                foreach (var statement in methodDecl.Body.Statements)
                {
                    methodCode.AppendLine(TranslateStatementToCpp(statement));
                }
            }
            // Si el método utiliza cuerpo de expresión (=>)
            else if (methodDecl.ExpressionBody != null)
            {
                methodCode.AppendLine("        return " + TranslateExpressionToCpp(methodDecl.ExpressionBody.Expression) + ";");
            }
            methodCode.AppendLine("    }");
            return methodCode.ToString();
        }

        // Traduce sentencias (actualmente se implementa para 'return')
        private string TranslateStatementToCpp(StatementSyntax statement)
        {
            if (statement is ReturnStatementSyntax returnStmt)
            {
                return "        return " + TranslateExpressionToCpp(returnStmt.Expression) + ";";
            }
            // Se pueden agregar más casos para otros tipos de sentencias
            return "        // [Sentencia no traducida]";
        }

        // Traduce expresiones (implementación básica para expresiones binarias, literales e identificadores)
        private string TranslateExpressionToCpp(ExpressionSyntax expr)
        {
            if (expr is BinaryExpressionSyntax binaryExpr)
            {
                string left = TranslateExpressionToCpp(binaryExpr.Left);
                string right = TranslateExpressionToCpp(binaryExpr.Right);
                string op = binaryExpr.OperatorToken.Text;
                return $"{left} {op} {right}";
            }
            else if (expr is LiteralExpressionSyntax literal)
            {
                return literal.Token.Text;
            }
            else if (expr is IdentifierNameSyntax identifier)
            {
                return identifier.Identifier.Text;
            }
            // Caso por defecto: retorna el texto de la expresión
            return expr.ToString();
        }

        // Función de mapeo de tipos (básico)
        private string MapType(string csType)
        {
            return csType switch
            {
                "int" => "int",
                "float" => "float",
                "double" => "double",
                "bool" => "bool",
                "string" => "std::string",
                "void" => "void",
                _ => csType,
            };
        }

    }
}
