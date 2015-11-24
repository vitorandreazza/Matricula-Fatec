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
using System.IO;
using System.Drawing.Text;
using Microsoft.Reporting.WinForms;
//Imports bibliotecas
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using AForge.Video.DirectShow;
using AForge.Video;
//Imports projeto
using Matricula.Model;
using Matricula.View;
using Matricula.Controller;

namespace Matricula
{
    public partial class RelatorioForm: Syncfusion.Windows.Forms.MetroForm
    {
        private bool admin = false;

        public RelatorioForm(string cpf,int codigo, bool admin)
        {
            InitializeComponent();
            MessageBoxApparence.getMessageBoxApparence();
            MatriculaController mc = new MatriculaController();
            // Ficha Matricula
            rvFicha.ProcessingMode = ProcessingMode.Local;
            rvFicha.LocalReport.ReportEmbeddedResource = "Matricula.View.FichaMatricula.rdlc";
            rvFicha.LocalReport.SetParameters(mc.relatorioFicha(cpf,codigo));
            // Dados 
            rvDados.ProcessingMode = ProcessingMode.Local;
            rvDados.LocalReport.ReportEmbeddedResource = "Matricula.View.DadosAluno.rdlc";
            rvDados.LocalReport.SetParameters(mc.relatorioDados(cpf,codigo));

            this.admin = admin;
        }

        private void RelatorioForm_Load(object sender, EventArgs e)
        {

            this.rvFicha.RefreshReport();
            this.rvDados.RefreshReport();
            if(admin)
            {
                btnContinuar.Visible = false;
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (MessageBoxAdv.Show(this, "Deseja realmente continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            else
            {
                this.Hide();
                QuestionarioForm r1 = new QuestionarioForm();
                r1.ShowDialog();
            }
        }

        private void RelatorioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(admin == false)
            {
                Application.Exit();
            }
        }
    }
}
