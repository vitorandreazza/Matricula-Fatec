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
    public partial class MainForm : Syncfusion.Windows.Forms.MetroForm
    {
        MatriculaController Pesquisa = new MatriculaController();
        public MainForm()
        {
            InitializeComponent();
            Color verdeClaro = Color.FromArgb(0, 192, 177);
            Color verdeEscuro = Color.FromArgb(0, 163, 150);
            //this.dgConsultas.TableControl.HScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Shared;
            //MetroColorTable colorTable = new MetroColorTable();

            //colorTable.ArrowChecked = verdeEscuro;
            //colorTable.ArrowNormal = verdeClaro;
            ////colorTable.ArrowNormalBackGround = Color.WhiteSmoke;
            //colorTable.ArrowPushed = verdeClaro;
            ////colorTable.ArrowPushedBackGround = verdeClaro;
            //colorTable.ScrollerBackground = Color.WhiteSmoke;
            //colorTable.ThumbChecked = verdeEscuro;
            //colorTable.ThumbNormal = verdeClaro;
            //colorTable.ThumbPushed = verdeEscuro;
            //colorTable.ThumbPushedBorder = verdeClaro;

            //this.sfGrid.VisualStyle = ScrollBarCustomDrawStyles.Metro;
            //this.sfGrid.AttachedTo = this.dgConsultas.TableControl;
            //this.sfGrid.ScrollMetroColorTable = colorTable;

            this.dgConsultas.TableDescriptor.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            this.dgConsultas.TableDescriptor.TableOptions.SelectionBackColor = verdeClaro;
            this.dgConsultas.GridVisualStyles = GridVisualStyles.Metro;
            GridMetroColors theme = new GridMetroColors();
            theme.HeaderBottomBorderColor.GetBrightness();
            theme.HeaderBottomBorderColor = verdeClaro;
            theme.HeaderColor.HoverColor = verdeClaro;
            theme.HeaderTextColor.NormalTextColor = SystemColors.GrayText;
            theme.ComboboxColor.NormalBorderColor = verdeEscuro;
            theme.ComboboxColor.HoverBackColor = Color.White;
            theme.ComboboxColor.HoverBorderColor = verdeEscuro;
            theme.ComboboxColor.PressedBackColor = verdeEscuro;
            theme.ComboboxColor.PresedBorderColor = verdeEscuro;
            this.dgConsultas.SetMetroStyle(theme);

        }

        private void todosAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dgConsultas.ClearSelection();
            dgConsultas.DataSource = Pesquisa.PesquisaTodosAlunos().Tables[0];
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void nomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgConsultas.DataSource = null;
            txtAluno.Visible = true;
            lblAluno.Text = "Nome";
            btnPesquisa.Visible = true;
            lblAluno.Visible = true;
        }

        private void cPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgConsultas.DataSource = null;
            txtAluno.Visible = true;
            lblAluno.Text = "CPF";
            btnPesquisa.Visible = true;
            lblAluno.Visible = true;
        }

        private void loginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgConsultas.DataSource = Pesquisa.login().Tables[0];
            
        }

        private void dgConsultas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void aDSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dgConsultas.DataSource = Pesquisa.PesquisaCurso("Análise e Desenvolvimento de Sistemas", null).Tables[0];
        }

        private void eventosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dgConsultas.DataSource = Pesquisa.PesquisaCurso("Eventos", null).Tables[0];
        }

        private void mecatrônicaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dgConsultas.DataSource = Pesquisa.PesquisaCurso("Mecatrônica Industrial", null).Tables[0];
        }

        private void gestãoEmpresarialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dgConsultas.DataSource = Pesquisa.PesquisaCurso("Gestão Empresarial(EAD)", null).Tables[0];
        }

        private void manhãToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dgConsultas.DataSource = Pesquisa.PesquisaCurso("Gestão da Tecnologia da Informação", "Noite").Tables[0];
        }

        private void noiteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dgConsultas.DataSource = Pesquisa.PesquisaCurso("Gestão da Tecnologia da Informação", "Noite").Tables[0];
        }

        private void religiãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgConsultas.DataSource = null;
            txtAluno.Visible = true;
            lblAluno.Text = "Religião";
            btnPesquisa.Visible = true;
            lblAluno.Visible = true;
            MessageBoxAdv.Show(this, "Informe a religião do aluno abaixo!", "Alerta", MessageBoxButtons.OK);
        }

        private void escolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgConsultas.DataSource = null;
            txtAluno.Visible = true;
            lblAluno.Text = "Escola";
            btnPesquisa.Visible = true;
            lblAluno.Visible = true;
            MessageBoxAdv.Show(this, "Informe a escola do aluno abaixo!", "Alerta", MessageBoxButtons.OK);
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgConsultas.DataSource = null;
            txtAluno.Visible = true;
            lblAluno.Text = "Cidade";
            btnPesquisa.Visible = true;
            lblAluno.Visible = true;
            MessageBoxAdv.Show(this, "Informe a cidade do aluno abaixo!", "Alerta", MessageBoxButtons.OK);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSMatricula.Matriculas' table. You can move, or remove it, as needed.
            this.matriculasTableAdapter1.Fill(this.dSMatricula.Matriculas);
        }

        private void dgConsultas_TableControlCurrentCellStartEditing(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCancelEventArgs e)
        {
            e.Inner.Cancel = true;
        }

        private void dgConsultas_QueryCellStyleInfo(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs e)
        {
            Syncfusion.Grouping.Element el = e.TableCellIdentity.DisplayElement;
            if (el.Kind == Syncfusion.Grouping.DisplayElementKind.Record && e.TableCellIdentity.Column != null &&
            (e.TableCellIdentity.Column.Name == "Type" || e.TableCellIdentity.Column.Name == "Enabled"))
            {
                e.Style.ReadOnly = false;
                e.Style.BackColor = Color.AliceBlue;
            }
            else
            {
                e.Style.ReadOnly = true;
            }
        }

        private void dgConsultas_TableControlCurrentCellActivating(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCurrentCellActivatingEventArgs e)
        {
            e.Inner.ColIndex = 0;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            MatriculaModel Mat = new MatriculaModel();

            if (lblAluno.Text.Equals("CPF"))
            {
                Mat.Cpf = txtAluno.Text;
                dgConsultas.DataSource = Pesquisa.PesquisaAluno(Mat, "CPF").Tables[0];
            }
            else if (lblAluno.Text.Equals("Nome"))
            {
                Mat.Nome = txtAluno.Text;
                dgConsultas.DataSource = Pesquisa.PesquisaAluno(Mat, "Nome").Tables[0];
            }
            else if (lblAluno.Text.Equals("Religião"))
            {
                Mat.Religiao = txtAluno.Text;
                dgConsultas.DataSource = Pesquisa.PesquisaAluno(Mat, "Religiao").Tables[0];
            }
            else if (lblAluno.Text.Equals("Cidade"))
            {
                Mat.Municipio = txtAluno.Text;
                dgConsultas.DataSource = Pesquisa.PesquisaAluno(Mat, "Cidade").Tables[0];
            }
            else if (lblAluno.Text.Equals("Escola"))
            {
                Mat.Escola = txtAluno.Text;
                dgConsultas.DataSource = Pesquisa.PesquisaAluno(Mat, "Escola").Tables[0];
            }
            txtAluno.Clear();
            lblAluno.Visible = false;
            txtAluno.Visible = false;
            btnPesquisa.Visible = false;
        }
    }     
}
