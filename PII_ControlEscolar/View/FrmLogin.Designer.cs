namespace PII_ControlEscolar.View
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUsuario = new Label();
            lblContraseña = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            btnLogin = new Button();
            btnCancelar = new Button();
            pctBxImagen = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pctBxImagen).BeginInit();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(230, 43);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(63, 19);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContraseña.Location = new Point(205, 120);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(88, 19);
            lblContraseña.TabIndex = 1;
            lblContraseña.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(392, 39);
            txtUsuario.MaxLength = 20;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(392, 116);
            txtContraseña.MaxLength = 25;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(100, 23);
            txtContraseña.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Image = PII_ControlEscolar.Properties.Resources._4115234_login_sign_in_icon1;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(186, 203);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(107, 27);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar Sesion";
            btnLogin.TextAlign = ContentAlignment.MiddleRight;
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = PII_ControlEscolar.Properties.Resources._2303165_cancel_close_delete_forbidden_off_icon;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(407, 203);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 27);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pctBxImagen
            // 
            pctBxImagen.BackColor = SystemColors.Control;
            pctBxImagen.Image = PII_ControlEscolar.Properties.Resources._1519782_colorful_document_note_office_paper_icon2;
            pctBxImagen.Location = new Point(23, 27);
            pctBxImagen.Name = "pctBxImagen";
            pctBxImagen.Size = new Size(128, 128);
            pctBxImagen.SizeMode = PictureBoxSizeMode.AutoSize;
            pctBxImagen.TabIndex = 6;
            pctBxImagen.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 251);
            Controls.Add(pctBxImagen);
            Controls.Add(btnCancelar);
            Controls.Add(btnLogin);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(549, 290);
            MinimumSize = new Size(549, 290);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pctBxImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private Label lblContraseña;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnLogin;
        private Button btnCancelar;
        private PictureBox pctBxImagen;
    }
}