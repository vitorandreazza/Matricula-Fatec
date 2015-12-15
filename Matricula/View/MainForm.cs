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
        private MatriculaController matriculaController = new MatriculaController();

        public MainForm()
        {
            InitializeComponent();
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
        }

        private void GridStyle()
        {
            Color verdeClaro = Color.FromArgb(0, 192, 177);
            Color verdeEscuro = Color.FromArgb(0, 163, 150);
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
            bsMatriculas.DataSource = matriculaController.PesquisaTodosAlunos().Tables[0];
            dgConsultas.DataSource = bsMatriculas;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void nomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bsMatriculas.DataSource = null;
            dgConsultas.DataSource = bsMatriculas;
            txtAluno.Visible = true;
            lblAluno.Text = "Nome";
            btnPesquisa.Visible = true;
            lblAluno.Visible = true;
        }

        private void cPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bsMatriculas.DataSource = null;
            dgConsultas.DataSource = bsMatriculas;
            txtAluno.Visible = true;
            txtAluno.Mask = "###.###.###-##";
            lblAluno.Text = "CPF";
            btnPesquisa.Visible = true;
            lblAluno.Visible = true;
        }

        private void loginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginController pesLogin = new LoginController();
            //bsLogins.DataSource = null;
            bsLogins.DataSource = pesLogin.pesLogins().Tables[0];
            dgConsultas.DataSource = bsLogins;
        }

        private void aDSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bsMatriculas.DataSource = matriculaController.PesquisaCurso("Análise e Desenvolvimento de Sistemas", null).Tables[0];
            dgConsultas.DataSource = bsMatriculas;
        }

        private void eventosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bsMatriculas.DataSource = matriculaController.PesquisaCurso("Eventos", null).Tables[0];
            dgConsultas.DataSource = bsMatriculas;
        }

        private void mecatrônicaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bsMatriculas.DataSource = matriculaController.PesquisaCurso("Mecatrônica Industrial", null).Tables[0];
            dgConsultas.DataSource = bsMatriculas;
        }

        private void gestãoEmpresarialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bsMatriculas.DataSource = matriculaController.PesquisaCurso("Gestão Empresarial(EAD)", null).Tables[0];
            dgConsultas.DataSource = bsMatriculas;
        }

        private void manhãToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dgConsultas.DataSource = matriculaController.PesquisaCurso("Gestão da Tecnologia da Informação", "Noite").Tables[0];
        }

        private void noiteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bsMatriculas.DataSource = matriculaController.PesquisaCurso("Gestão da Tecnologia da Informação", "Noite").Tables[0];
            dgConsultas.DataSource = bsMatriculas;
        }

        private void religiãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bsMatriculas.DataSource = null;
            dgConsultas.DataSource = bsMatriculas;
            txtAluno.Visible = true;
            lblAluno.Text = "Religião";
            btnPesquisa.Visible = true;
            lblAluno.Visible = true;
        }

        private void escolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bsMatriculas.DataSource = null;
            dgConsultas.DataSource = bsMatriculas;
            txtAluno.Visible = true;
            lblAluno.Text = "Escola";
            btnPesquisa.Visible = true;
            lblAluno.Visible = true;
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bsMatriculas.DataSource = null;
            dgConsultas.DataSource = bsMatriculas;
            txtAluno.Visible = true;
            lblAluno.Text = "Cidade";
            btnPesquisa.Visible = true;
            lblAluno.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSMatricula.Logins' table. You can move, or remove it, as needed.
            this.loginsTableAdapter.Fill(this.dSMatricula.Logins);
            // TODO: This line of code loads data into the 'dSMatricula.Matriculas' table. You can move, or remove it, as needed.
            this.matriculasTableAdapter1.Fill(this.dSMatricula.Matriculas);
            GridStyle();
            MessageBoxApparence.getMessageBoxApparence();
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
            string Mat = txtAluno.Text.Replace(".", "").Replace("-", "");

            if (lblAluno.Text.Equals("CPF"))
            {
                bsMatriculas.DataSource = matriculaController.PesquisaAluno(Mat, "cpf").Tables[0];
            }
            else if (lblAluno.Text.Equals("Nome"))
            {
                bsMatriculas.DataSource = matriculaController.PesquisaAluno(Mat, "nome").Tables[0];
            }
            else if (lblAluno.Text.Equals("Religião"))
            {
                bsMatriculas.DataSource = matriculaController.PesquisaAluno(Mat, "religiao").Tables[0];
            }
            else if (lblAluno.Text.Equals("Cidade"))
            {
                bsMatriculas.DataSource = matriculaController.PesquisaAluno(Mat, "municipio").Tables[0];
            }
            else if (lblAluno.Text.Equals("Escola"))
            {
                bsMatriculas.DataSource = matriculaController.PesquisaAluno(Mat, "escola").Tables[0];
            }
            else if (lblAluno.Text.Equals("Rcpf"))
            {
                RelatorioForm r = new RelatorioForm(Mat, 0, true);
                r.Show();
            }
            else if(lblAluno.Text.Equals("Rcodigo"))
            {
                RelatorioForm r = new RelatorioForm(null,Convert.ToInt32(Mat), true);
                r.Show();
            }
            dgConsultas.DataSource = bsMatriculas;
            txtAluno.Clear();
            lblAluno.Visible = false;
            txtAluno.Visible = false;
            txtAluno.Mask = "";
            btnPesquisa.Visible = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBoxAdv.Show(this, "Deseja realmente excluir a matrícula?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            try
            {
                int cod = Convert.ToInt32(dgConsultas.Table.SelectedRecords[0].Record["codigo"]);
                matriculaController.deletarMatricula(cod);
                atualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void atualizarGrid()
        {
            bsMatriculas.DataSource = matriculaController.PesquisaTodosAlunos().Tables[0];
            dgConsultas.DataSource = bsMatriculas;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new MatriculaForm(true).ShowDialog();
            return;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                int cod = Convert.ToInt32(dgConsultas.Table.SelectedRecords[0].Record["codigo"]);
                DataTable dt = new DataTable();
                dt = matriculaController.pesquisarAlunoEsp(cod).Tables[0];

                MatriculaModel matricula = new MatriculaModel();
                matricula.Nome = dt.Rows[0]["nome"].ToString();
                matricula.Nascimento = dt.Rows[0]["dtNasc"].ToString();
                matricula.Sexo = Convert.ToChar(dt.Rows[0]["sexo"]);
                matricula.Nacionalidade = dt.Rows[0]["nacionalidade"].ToString();
                matricula.Naturalidade = dt.Rows[0]["naturalidade"].ToString();
                matricula.EstadoCivil = dt.Rows[0]["estadoCivil"].ToString();
                matricula.Estado = dt.Rows[0]["estado"].ToString();
                matricula.Religiao = dt.Rows[0]["religiao"].ToString();
                matricula.TpSanguineo = dt.Rows[0]["tipoSanguineo"].ToString();
                matricula.Rh = dt.Rows[0]["rh"].ToString();
                matricula.NomePai = dt.Rows[0]["nomePai"].ToString();
                matricula.NomeMae = dt.Rows[0]["nomeMae"].ToString();
                matricula.Email = dt.Rows[0]["email"].ToString();
                matricula.Cep = dt.Rows[0]["cep"].ToString();
                matricula.Endreco = dt.Rows[0]["endereco"].ToString();
                matricula.Numero = dt.Rows[0]["numero"].ToString();
                matricula.Complemento = dt.Rows[0]["complemento"].ToString();
                matricula.Bairro = dt.Rows[0]["bairro"].ToString();
                matricula.Municipio = dt.Rows[0]["municipio"].ToString();
                matricula.Cpf = dt.Rows[0]["cpf"].ToString();
                matricula.EmissaoCpf = dt.Rows[0]["dataEmissaoCpf"].ToString();
                matricula.Rg = dt.Rows[0]["rg"].ToString();
                matricula.EmissaoRg = dt.Rows[0]["dataEmissaoRg"].ToString();
                matricula.Titulo = dt.Rows[0]["tituloEleitor"].ToString();
                matricula.SecaoTitulo = dt.Rows[0]["secao"].ToString();
                matricula.ZonaTitulo = dt.Rows[0]["zona"].ToString();
                matricula.Escola = dt.Rows[0]["escola"].ToString();
                matricula.CidadeEscola = dt.Rows[0]["cidadeEscola"].ToString();
                matricula.EstadoEscola = dt.Rows[0]["estadoEscola"].ToString();
                matricula.ConclusaoEscola = dt.Rows[0]["anoConclusao"].ToString();
                matricula.Classificacao = dt.Rows[0]["classificacao"].ToString();
                matricula.Pontuacao = dt.Rows[0]["pontuacao"].ToString();
                matricula.Curso = dt.Rows[0]["curso"].ToString();
                matricula.Turno = dt.Rows[0]["turno"].ToString();
                matricula.Foto = (byte[]) dt.Rows[0]["foto"];
                matricula.ExpedidoRG = dt.Rows[0]["expedidoRG"].ToString();
                matricula.Cor = dt.Rows[0]["cor"].ToString();
                matricula.ReservaMilitar = dt.Rows[0]["reservaMilitar"].ToString();
                matricula.DataMilitar = dt.Rows[0]["dataMilitar"].ToString();
                matricula.ExpedidoMilitar = dt.Rows[0]["expedidoMilitar"].ToString();

                DataTable dtTelefone = new DataTable();
                DataTable dtCelular = new DataTable();
                dtTelefone = new TelefonesController().pesquisarTelefone(cod).Tables[0];
                dtCelular = new TelefonesController().pesquisarCelular(cod).Tables[0];
                
                int telCount = dtTelefone.Rows.Count, celCount = dtCelular.Rows.Count;
                string[] tel = new string[telCount], cel = new string[celCount];
   
                for (int i = 0; i < telCount; i++ )
                {
                    tel[i] = dtTelefone.Rows[i]["telefone"].ToString();
                }

                for (int i = 0; i < celCount; i++)
                {
                    cel[i] = dtCelular.Rows[i]["celular"].ToString();
                }

                MatriculaForm mat = new MatriculaForm(cod, matricula, cel, tel);
                mat.Show();
            }
            catch(Exception ex)
            {
                MessageBoxAdv.Show(""+ex);
            }

        }

        private void dgConsultas_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            
        }

        private void loginsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
                        
        }

        private void GraficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraficoForm gr = new GraficoForm();
            gr.Show();
        }

        private void cadastrarLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CadastroLoginForm().Show();
        }

        private void txtAluno_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnPesquisa_Click(btnPesquisa, new EventArgs());
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void cPFToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            txtAluno.Visible = true;
            txtAluno.Mask = "###.###.###-##";
            btnPesquisa.Visible = true;
            txtAluno.Clear();
            lblAluno.Text = "Rcpf";
        }

        private void códigoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtAluno.Visible = true;
            btnPesquisa.Visible = true;
            txtAluno.Clear();
            lblAluno.Text = "Rcodigo";
        }

        private void questionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new QuestionarioForm().Show();
        }
    }     
}
