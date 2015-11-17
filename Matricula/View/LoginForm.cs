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
using System.Data.SqlClient;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Matricula.View;
using Matricula.Controller;
using Matricula.Model;

namespace Matricula
{
    public partial class LoginForm : Syncfusion.Windows.Forms.MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
            MessageBoxApparence.getMessageBoxApparence();
        }

        private void rbAluno_CheckChanged(object sender, EventArgs e)
        {
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
        }

        private void rbAdm_CheckChanged(object sender, EventArgs e)
        {
            txtLogin.Enabled = true;
            txtSenha.Enabled = true;
            txtLogin.Clear();
            txtSenha.Clear();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (rbAluno.Checked)
            {
                MatriculaForm mf = new MatriculaForm();
                this.Hide();
                mf.ShowDialog();
                return;
            }
            try
            {
                int retorno;
                LoginModel login = new LoginModel();
                LoginController lg = new LoginController();
                login.Login = txtLogin.Text;
                login.Senha = txtSenha.Text;
                retorno = lg.logar(login);

                if (retorno.Equals(1))
                {
                    MainForm adm = new MainForm();
                    this.Hide();
                    adm.ShowDialog();
                }
                else
                {
                    MessageBoxAdv.Show("Login ou senha inválido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }   
        }
    }
}
