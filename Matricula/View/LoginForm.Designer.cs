#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Matricula
{
    partial class LoginForm
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
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.rbAdm = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.rbAluno = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.lblLogin = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtLogin = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtSenha = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblSenha = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnEntrar = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.rbAdm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbAluno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha)).BeginInit();
            this.SuspendLayout();
            // 
            // rbAdm
            // 
            this.rbAdm.BeforeTouchSize = new System.Drawing.Size(97, 21);
            this.rbAdm.DrawFocusRectangle = false;
            this.rbAdm.Location = new System.Drawing.Point(12, 29);
            this.rbAdm.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(150)))));
            this.rbAdm.Name = "rbAdm";
            this.rbAdm.Size = new System.Drawing.Size(97, 21);
            this.rbAdm.Style = Syncfusion.Windows.Forms.Tools.RadioButtonAdvStyle.Metro;
            this.rbAdm.TabIndex = 0;
            this.rbAdm.TabStop = false;
            this.rbAdm.Text = "Administrador";
            this.rbAdm.ThemesEnabled = false;
            this.rbAdm.CheckChanged += new System.EventHandler(this.rbAdm_CheckChanged);
            // 
            // rbAluno
            // 
            this.rbAluno.BeforeTouchSize = new System.Drawing.Size(53, 21);
            this.rbAluno.Checked = true;
            this.rbAluno.DrawFocusRectangle = false;
            this.rbAluno.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbAluno.Location = new System.Drawing.Point(158, 29);
            this.rbAluno.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(150)))));
            this.rbAluno.Name = "rbAluno";
            this.rbAluno.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Silver;
            this.rbAluno.Size = new System.Drawing.Size(53, 21);
            this.rbAluno.Style = Syncfusion.Windows.Forms.Tools.RadioButtonAdvStyle.Metro;
            this.rbAluno.TabIndex = 1;
            this.rbAluno.Text = "Aluno";
            this.rbAluno.ThemesEnabled = false;
            this.rbAluno.CheckChanged += new System.EventHandler(this.rbAluno_CheckChanged);
            // 
            // lblLogin
            // 
            this.lblLogin.Location = new System.Drawing.Point(12, 69);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.BeforeTouchSize = new System.Drawing.Size(526, 20);
            this.txtLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLogin.Enabled = false;
            this.txtLogin.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(150)))));
            this.txtLogin.Location = new System.Drawing.Point(12, 85);
            this.txtLogin.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(220, 20);
            this.txtLogin.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtLogin.TabIndex = 3;
            // 
            // txtSenha
            // 
            this.txtSenha.BeforeTouchSize = new System.Drawing.Size(526, 20);
            this.txtSenha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSenha.Enabled = false;
            this.txtSenha.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(150)))));
            this.txtSenha.Location = new System.Drawing.Point(12, 135);
            this.txtSenha.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(220, 20);
            this.txtSenha.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtSenha.TabIndex = 5;
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            // 
            // lblSenha
            // 
            this.lblSenha.Location = new System.Drawing.Point(12, 119);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(38, 13);
            this.lblSenha.TabIndex = 4;
            this.lblSenha.Text = "Senha";
            // 
            // btnEntrar
            // 
            this.btnEntrar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnEntrar.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnEntrar.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None;
            this.btnEntrar.ComboEditBackColor = System.Drawing.Color.Transparent;
            this.btnEntrar.CustomManagedColor = System.Drawing.Color.Transparent;
            this.btnEntrar.FlatAppearance.BorderSize = 0;
            this.btnEntrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnEntrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(150)))));
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.IsBackStageButton = false;
            this.btnEntrar.Location = new System.Drawing.Point(90, 191);
            this.btnEntrar.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(75, 23);
            this.btnEntrar.TabIndex = 7;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyle = false;
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(177)))));
            this.CaptionBarHeight = 30;
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.White;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.White;
            captionImage1.Image = ((System.Drawing.Image)(resources.GetObject("captionImage1.Image")));
            captionImage1.Location = new System.Drawing.Point(12, 6);
            captionImage1.Name = "CaptionImage1";
            captionImage1.Size = new System.Drawing.Size(47, 25);
            this.CaptionImages.Add(captionImage1);
            this.ClientSize = new System.Drawing.Size(244, 226);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.rbAluno);
            this.Controls.Add(this.rbAdm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(177)))));
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            ((System.ComponentModel.ISupportInitialize)(this.rbAdm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbAluno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbAdm;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbAluno;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblLogin;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtLogin;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSenha;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblSenha;
        private Syncfusion.Windows.Forms.ButtonAdv btnEntrar;
    }
}