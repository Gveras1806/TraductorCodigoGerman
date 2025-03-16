namespace AnalizadorSemantico
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label3 = new Label();
            txtResultado = new TextBox();
            LIMP = new Button();
            label2 = new Label();
            label1 = new Label();
            salida = new TextBox();
            analizar = new TextBox();
            sema = new Button();
            label4 = new Label();
            semantico = new TextBox();
            label5 = new Label();
            tra = new TextBox();
            btnTraducir = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(484, 163);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 26;
            label3.Text = "Analizador Sintactico:";
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(484, 181);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(459, 223);
            txtResultado.TabIndex = 25;
            // 
            // LIMP
            // 
            LIMP.BackColor = Color.LightCoral;
            LIMP.Font = new Font("Segoe UI Black", 9F, FontStyle.Underline);
            LIMP.ForeColor = SystemColors.Control;
            LIMP.Image = Properties.Resources.icons8_limpiar_48;
            LIMP.ImeMode = ImeMode.NoControl;
            LIMP.Location = new Point(888, 12);
            LIMP.Name = "LIMP";
            LIMP.Size = new Size(55, 53);
            LIMP.TabIndex = 24;
            LIMP.UseVisualStyleBackColor = false;
            LIMP.Click += LIMP_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(12, 18);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 23;
            label2.Text = "Analizar:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(12, 163);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 22;
            label1.Text = "Analizador Lexico:";
            // 
            // salida
            // 
            salida.Location = new Point(12, 181);
            salida.Multiline = true;
            salida.Name = "salida";
            salida.Size = new Size(459, 223);
            salida.TabIndex = 21;
            // 
            // analizar
            // 
            analizar.Location = new Point(12, 36);
            analizar.Multiline = true;
            analizar.Name = "analizar";
            analizar.Size = new Size(377, 111);
            analizar.TabIndex = 20;
            // 
            // sema
            // 
            sema.BackColor = Color.DarkSeaGreen;
            sema.ImeMode = ImeMode.NoControl;
            sema.Location = new Point(249, 150);
            sema.Name = "sema";
            sema.Size = new Size(140, 25);
            sema.TabIndex = 31;
            sema.Text = "Analizar";
            sema.UseVisualStyleBackColor = false;
            sema.Click += sema_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(12, 407);
            label4.Name = "label4";
            label4.Size = new Size(125, 15);
            label4.TabIndex = 30;
            label4.Text = "Analizador Semantico:";
            // 
            // semantico
            // 
            semantico.Location = new Point(12, 425);
            semantico.Multiline = true;
            semantico.Name = "semantico";
            semantico.Size = new Size(459, 232);
            semantico.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(484, 416);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 33;
            label5.Text = "Traductor";
            // 
            // tra
            // 
            tra.Location = new Point(484, 434);
            tra.Multiline = true;
            tra.Name = "tra";
            tra.Size = new Size(459, 223);
            tra.TabIndex = 32;
            // 
            // btnTraducir
            // 
            btnTraducir.BackColor = Color.DarkSeaGreen;
            btnTraducir.ImeMode = ImeMode.NoControl;
            btnTraducir.Location = new Point(803, 407);
            btnTraducir.Name = "btnTraducir";
            btnTraducir.Size = new Size(140, 25);
            btnTraducir.TabIndex = 34;
            btnTraducir.Text = "Traducir";
            btnTraducir.UseVisualStyleBackColor = false;
            btnTraducir.Click += btnTraducir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(951, 671);
            Controls.Add(btnTraducir);
            Controls.Add(label5);
            Controls.Add(tra);
            Controls.Add(sema);
            Controls.Add(label4);
            Controls.Add(semantico);
            Controls.Add(label3);
            Controls.Add(txtResultado);
            Controls.Add(LIMP);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(salida);
            Controls.Add(analizar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "ANALIZADORES GERMAN VERAS 1-18-0723";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private TextBox txtResultado;
        private Button LIMP;
        private Label label2;
        private Label label1;
        private TextBox salida;
        private TextBox analizar;
        private Button sema;
        private Label label4;
        private TextBox semantico;
        private Label label5;
        private TextBox tra;
        private Button btnTraducir;
    }
}
