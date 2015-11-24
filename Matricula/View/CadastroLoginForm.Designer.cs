#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Matricula.View
{
    partial class CadastroLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroLoginForm));
            this.btnCadastrar = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtSenha = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblSenha = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtLogin = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblLogin = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtCSenha = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCSenha)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCadastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnCadastrar.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnCadastrar.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None;
            this.btnCadastrar.ComboEditBackColor = System.Drawing.Color.Transparent;
            this.btnCadastrar.CustomManagedColor = System.Drawing.Color.Transparent;
            this.btnCadastrar.FlatAppearance.BorderSize = 0;
            this.btnCadastrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnCadastrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(150)))));
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.ForeColor = System.Drawing.Color.White;
            this.btnCadastrar.IsBackStageButton = false;
            this.btnCadastrar.Location = new System.Drawing.Point(91, 170);
            this.btnCadastrar.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 12;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyle = false;
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.BeforeTouchSize = new System.Drawing.Size(173, 20);
            this.txtSenha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSenha.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(150)))));
            this.txtSenha.Location = new System.Drawing.Point(12, 81);
            this.txtSenha.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(220, 20);
            this.txtSenha.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtSenha.TabIndex = 11;
            // 
            // lblSenha
            // 
            this.lblSenha.Location = new System.Drawing.Point(12, 65);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(38, 13);
            this.lblSenha.TabIndex = 10;
            this.lblSenha.Text = "Senha";
            // 
            // txtLogin
            // 
            this.txtLogin.BeforeTouchSize = new System.Drawing.Size(173, 20);
            this.txtLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLogin.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(150)))));
            this.txtLogin.Location = new System.Drawing.Point(12, 31);
            this.txtLogin.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(220, 20);
            this.txtLogin.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtLogin.TabIndex = 9;
            // 
            // lblLogin
            // 
            this.lblLogin.Location = new System.Drawing.Point(12, 15);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 8;
            this.lblLogin.Text = "Login";
            // 
            // txtCSenha
            // 
            this.txtCSenha.BeforeTouchSize = new System.Drawing.Size(173, 20);
            this.txtCSenha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCSenha.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(150)))));
            this.txtCSenha.Location = new System.Drawing.Point(12, 130);
            this.txtCSenha.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtCSenha.Name = "txtCSenha";
            this.txtCSenha.PasswordChar = '*';
            this.txtCSenha.Size = new System.Drawing.Size(220, 20);
            this.txtCSenha.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtCSenha.TabIndex = 14;
            this.txtCSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCSenha_KeyDown);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(12, 114);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(85, 13);
            this.autoLabel1.TabIndex = 13;
            this.autoLabel1.Text = "Confirmar Senha";
            // 
            // CadastroLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(177)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.White;
            this.CaptionForeColor = System.Drawing.Color.White;
            captionImage1.Image = ((System.Drawing.Image)(resources.GetObject("captionImage1.Image")));
            captionImage1.Location = new System.Drawing.Point(12, 6);
            captionImage1.Name = "CaptionImage1";
            captionImage1.Size = new System.Drawing.Size(47, 25);
            this.CaptionImages.Add(captionImage1);
            this.ClientSize = new System.Drawing.Size(246, 203);
            this.Controls.Add(this.txtCSenha);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CadastroLoginForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.Load += new System.EventHandler(this.CadastroLoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCSenha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCadastrar;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSenha;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblSenha;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtLogin;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblLogin;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCSenha;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
    }
}