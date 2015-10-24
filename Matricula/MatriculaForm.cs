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

namespace Matricula
{
    public partial class MatriculaForm : Syncfusion.Windows.Forms.MetroForm
    {
        public MatriculaForm()
        {
            InitializeComponent();

            MetroStyleColorTable metroColor = new MetroStyleColorTable();
            metroColor.YesButtonBackColor = Color.FromArgb(0, 191, 177);
            metroColor.NoButtonBackColor = Color.FromArgb(206, 59, 41);
            metroColor.BackColor = Color.FromArgb(245, 245, 245);
            metroColor.ForeColor = Color.FromArgb(105, 105, 105);
            metroColor.BorderColor = Color.FromArgb(0, 191, 177);
            metroColor.CaptionBarColor = Color.FromArgb(0, 191, 177);
            metroColor.CaptionForeColor = Color.FromArgb(255, 255, 255);
            MessageBoxAdv.MetroColorTable = metroColor;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;

        }
     
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            if(MessageBoxAdv.Show(this, "Deseja realmente confirmar a matrícula?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            string strConn = Matricula.Properties.Settings.Default.ConnMatricula;
            SqlConnection conn = new SqlConnection(strConn);

            string insertAluno = "INSERT INTO Matriculas" +
            "(nome, dtNasc, sexo, nacionalidade, naturalidade, estadoCivil, estado, religiao," +
            "tipoSanguineo, rh, nomePai, nomeMae, email, cep, endereco, numero, complemento," +
            "bairro, municipio, cpf, dataEmissaoCpf, rg, dataEmissaoRg, tituloEleitor, secao, zona, escola," +
            "cidadeEscola, estadoEscola, anoConclusao, classificacao, pontuacao, curso, turno)" +
            "VALUES" +
            "(@nome, @dtNasc, @sexo, @nacionalidade, @naturalidade, @estadoCivil, @estado, @religiao," +
            "@tipoSanguineo, @rh, @nomePai, @nomeMae, @email, @cep, @endereco, @numero, @complemento," +
            "@bairro, @municipio, @cpf, @dataEmissaoCpf, @rg, @dataEmissaoRg, @tituloEleitor, @secao, @zona, @escola," +
            "@cidadeEscola, @estadoEscola, @anoConclusao, @classificacao, @pontuacao, @curso, @turno)";

            char sexo = '\0';

            if(cbSexo.Text == "Masculino")
            {
                sexo = 'M';
            }
            else if (cbSexo.Text == "Feminino")
            {
                sexo = 'F';
            }

            try
            {
                SqlCommand cmdInsert = new SqlCommand(insertAluno, conn);

                cmdInsert.Parameters.AddWithValue("@nome", txtNome.Text);
                cmdInsert.Parameters.AddWithValue("@dtNasc", dpNascimento.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@sexo", sexo);
                cmdInsert.Parameters.AddWithValue("@nacionalidade", txtNacionalidade.Text);
                cmdInsert.Parameters.AddWithValue("@naturalidade", txtNaturalidade.Text);
                cmdInsert.Parameters.AddWithValue("@estadoCivil", cbEstadoCivil.Text);
                cmdInsert.Parameters.AddWithValue("@estado", cbEstado.Text);
                cmdInsert.Parameters.AddWithValue("@religiao", cbReligiao.Text);
                cmdInsert.Parameters.AddWithValue("@tipoSanguineo", cbSanguineo.Text);
                cmdInsert.Parameters.AddWithValue("@rh", cbRH.Text);
                cmdInsert.Parameters.AddWithValue("@nomePai", txtNomePai.Text);
                cmdInsert.Parameters.AddWithValue("@nomeMae", txtNomeMae.Text);
                cmdInsert.Parameters.AddWithValue("@email", txtEmail.Text);
                cmdInsert.Parameters.AddWithValue("@cep", mtxtCEP.Text);
                cmdInsert.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmdInsert.Parameters.AddWithValue("@numero", txtNumero.Text);
                cmdInsert.Parameters.AddWithValue("@complemento", txtComplemento.Text);
                cmdInsert.Parameters.AddWithValue("@bairro", txtBairro.Text);
                cmdInsert.Parameters.AddWithValue("@municipio", txtMunicipio.Text);
                cmdInsert.Parameters.AddWithValue("@cpf", mtxtCpf.Text);
                cmdInsert.Parameters.AddWithValue("@dataEmissaoCpf", dpEmissaoCpf.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@rg", mtxtRg.Text);
                cmdInsert.Parameters.AddWithValue("@dataEmissaoRg", dpEmissaoRg.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@tituloEleitor", mtxtTitulo.Text);
                cmdInsert.Parameters.AddWithValue("@secao", txtSecaoTitulo.Text);
                cmdInsert.Parameters.AddWithValue("@zona", txtZonaTitulo.Text);
                cmdInsert.Parameters.AddWithValue("@escola", txtEscola.Text);
                cmdInsert.Parameters.AddWithValue("@cidadeEscola", txtCidadeEscola.Text);
                cmdInsert.Parameters.AddWithValue("@estadoEscola", cbEstadoEscola.Text);
                cmdInsert.Parameters.AddWithValue("@anoConclusao", dpConclusaoEscola.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@classificacao", txtClassificacao.Text);
                cmdInsert.Parameters.AddWithValue("@pontuacao", txtPontuacao.Text);
                cmdInsert.Parameters.AddWithValue("@curso", cbCurso.Text);
                cmdInsert.Parameters.AddWithValue("@turno", cbTurno.Text);

                conn.Open();
                cmdInsert.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                string str;
                str = "Source:" + ex.Source;
                str += "\n" + "Number:" + ex.Number.ToString();
                str += "\n" + "Message:" + ex.Message;
                str += "\n" + "Class:" + ex.Class.ToString();
                str += "\n" + "Procedure:" + ex.Procedure.ToString();
                str += "\n" + "Line Number:" + ex.LineNumber.ToString();
                str += "\n" + "Server:" + ex.Server.ToString();

                MessageBox.Show(str, "Database Exception");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBoxAdv.Show(this, "Deseja realmente cancelar a matrícula?", "Cancelamento", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
        }

        int countR = 0;
        private void btnMaisR_Click(object sender, EventArgs e)
        {
            countR++;
            if(countR <= 2)
            {
                TextBoxExt txt = novoTextBox();
                txt.Name = "txtResidencial"+countR;
                txt.Location = new Point(txtResidencial.Location.X, txtResidencial.Location.Y+26*countR);
            }
        }

        int countC = 0;
        private void btnMainC_Click(object sender, EventArgs e)
        {
            countC++;
            if(countC <= 2)
            {
                TextBoxExt txt = novoTextBox();
                txt.Name = "txtCelular" + countC;
                txt.Location = new Point(txtCelular.Location.X, txtCelular.Location.Y + 26 * countC);
            }
        }

        private TextBoxExt novoTextBox()
        {
            TextBoxExt txt = new TextBoxExt();
            this.tabResidencial.Controls.Add(txt);
            txt.Size = new Size(txtResidencial.Size.Width, txtResidencial.Size.Height);
            return txt;
        }
    }
}
