#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Matricula.Model;
using Matricula.Controller;

namespace Matricula.View
{
    public partial class CadastroLoginForm : Syncfusion.Windows.Forms.MetroForm
    {
        public CadastroLoginForm()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text != txtCSenha.Text)
            {
                MessageBoxAdv.Show(this, "A senha não está igual a confirmação!", "Erro");
                return;
            }

            try
            {
                LoginModel loginModel = new LoginModel();
                loginModel.Login = txtLogin.Text;
                loginModel.Senha = txtSenha.Text;
                LoginController loginController = new LoginController();
                loginController.cadastrarLogin(loginModel);
                MessageBoxAdv.Show(this, "Login cadastrado com sucesso!", "Aviso");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBoxAdv.Show(this, "Erro: " + ex, "Erro");
            }
        }

        private void CadastroLoginForm_Load(object sender, EventArgs e)
        {
            MessageBoxApparence.getMessageBoxApparence();
        }

        private void txtCSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnCadastrar_Click(btnCadastrar, new EventArgs());
            }
        }
    }
}
