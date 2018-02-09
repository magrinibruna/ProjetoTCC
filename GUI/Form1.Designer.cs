namespace TCC5._0
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEntra = new System.Windows.Forms.Button();
            this.pnlAlteraSenha = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAlteraSenha = new System.Windows.Forms.Button();
            this.cbMostraSenhaAlteraSenha = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlteraSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMostraSenha = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblHora = new System.Windows.Forms.Label();
            this.pnlAlteraSenha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(920, 243);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(314, 29);
            this.txtUsuario.TabIndex = 1;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(920, 323);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(314, 29);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(915, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(915, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha";
            // 
            // btnEntra
            // 
            this.btnEntra.Location = new System.Drawing.Point(1091, 369);
            this.btnEntra.Name = "btnEntra";
            this.btnEntra.Size = new System.Drawing.Size(143, 42);
            this.btnEntra.TabIndex = 5;
            this.btnEntra.Text = "Entrar";
            this.btnEntra.UseVisualStyleBackColor = true;
            this.btnEntra.Click += new System.EventHandler(this.btnEntra_Click);
            // 
            // pnlAlteraSenha
            // 
            this.pnlAlteraSenha.Controls.Add(this.label5);
            this.pnlAlteraSenha.Controls.Add(this.btnAlteraSenha);
            this.pnlAlteraSenha.Controls.Add(this.cbMostraSenhaAlteraSenha);
            this.pnlAlteraSenha.Controls.Add(this.label4);
            this.pnlAlteraSenha.Controls.Add(this.txtAlteraSenha);
            this.pnlAlteraSenha.Controls.Add(this.label3);
            this.pnlAlteraSenha.Location = new System.Drawing.Point(888, 201);
            this.pnlAlteraSenha.Name = "pnlAlteraSenha";
            this.pnlAlteraSenha.Size = new System.Drawing.Size(375, 267);
            this.pnlAlteraSenha.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 48);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sua senha é padrão, por isso é \r\nnecessário a alteração\r\n";
            // 
            // btnAlteraSenha
            // 
            this.btnAlteraSenha.Location = new System.Drawing.Point(218, 203);
            this.btnAlteraSenha.Name = "btnAlteraSenha";
            this.btnAlteraSenha.Size = new System.Drawing.Size(136, 42);
            this.btnAlteraSenha.TabIndex = 11;
            this.btnAlteraSenha.Text = "Alterar Senha";
            this.btnAlteraSenha.UseVisualStyleBackColor = true;
            this.btnAlteraSenha.Click += new System.EventHandler(this.btnAlteraSenha_Click);
            // 
            // cbMostraSenhaAlteraSenha
            // 
            this.cbMostraSenhaAlteraSenha.AutoSize = true;
            this.cbMostraSenhaAlteraSenha.Location = new System.Drawing.Point(17, 169);
            this.cbMostraSenhaAlteraSenha.Name = "cbMostraSenhaAlteraSenha";
            this.cbMostraSenhaAlteraSenha.Size = new System.Drawing.Size(151, 28);
            this.cbMostraSenhaAlteraSenha.TabIndex = 9;
            this.cbMostraSenhaAlteraSenha.Text = "Mostrar Senha";
            this.cbMostraSenhaAlteraSenha.UseVisualStyleBackColor = true;
            this.cbMostraSenhaAlteraSenha.CheckedChanged += new System.EventHandler(this.cbMostraSenhaAlteraSenha_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nova Senha";
            // 
            // txtAlteraSenha
            // 
            this.txtAlteraSenha.Location = new System.Drawing.Point(17, 134);
            this.txtAlteraSenha.Name = "txtAlteraSenha";
            this.txtAlteraSenha.PasswordChar = '*';
            this.txtAlteraSenha.Size = new System.Drawing.Size(338, 29);
            this.txtAlteraSenha.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Alteração de Senha";
            // 
            // cbMostraSenha
            // 
            this.cbMostraSenha.AutoSize = true;
            this.cbMostraSenha.Location = new System.Drawing.Point(919, 358);
            this.cbMostraSenha.Name = "cbMostraSenha";
            this.cbMostraSenha.Size = new System.Drawing.Size(151, 28);
            this.cbMostraSenha.TabIndex = 10;
            this.cbMostraSenha.Text = "Mostrar Senha";
            this.cbMostraSenha.UseVisualStyleBackColor = true;
            this.cbMostraSenha.CheckedChanged += new System.EventHandler(this.cbMostraSenha_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(103, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(589, 441);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(1252, 726);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(103, 29);
            this.lblHora.TabIndex = 12;
            this.lblHora.Text = "00:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 764);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbMostraSenha);
            this.Controls.Add(this.pnlAlteraSenha);
            this.Controls.Add(this.btnEntra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUsuario);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal do Aluno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlAlteraSenha.ResumeLayout(false);
            this.pnlAlteraSenha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEntra;
        private System.Windows.Forms.Panel pnlAlteraSenha;
        private System.Windows.Forms.Button btnAlteraSenha;
        private System.Windows.Forms.CheckBox cbMostraSenhaAlteraSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAlteraSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbMostraSenha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblHora;


    }
}

