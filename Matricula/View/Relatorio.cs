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
//Imports bibliotecas
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
//Imports projeto
using Matricula.Model;
using Matricula.View;
using Matricula.Controller;


namespace Matricula
{
    public partial class Relatorio : Syncfusion.Windows.Forms.MetroForm
    {
    
        public Relatorio()
        {
            InitializeComponent();
        }

        private void Relatorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBMatriculaDataSet.Celulares' table. You can move, or remove it, as needed.
            this.CelularesTableAdapter.Fill(this.dBMatriculaDataSet.Celulares);
   
            this.fixosTableAdapter.Fill(this.dBMatriculaDataSet.Fixos);
          
            this.matriculasTableAdapter.Fill(this.dBMatriculaDataSet.Matriculas);
            

            this.rvAluno.RefreshReport();
        }

       

    }

     
}
