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

namespace Matricula
{
    public partial class MatriculaForm : Syncfusion.Windows.Forms.MetroForm
    {
        public MatriculaForm()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
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

            //Se o cb index == 0(Feminino) sexo = F senão sexo = M
            string sexo = cbSexo.SelectedIndex == 0 ? "F" : "M";
            //string estadoCivil = cbEstadoCivil.SelectedIndex == -1 ? null : cbEstadoCivil.SelectedItem.ToString();
            //string estado = cbEstado.SelectedIndex == -1 ? null : cbEstado.SelectedItem.ToString();
            //string religiao = cbReligiao.SelectedIndex == -1 ? null : cbReligiao.SelectedItem.ToString();
            //string sanguineo = cbSanguineo.SelectedIndex == -1 ? null : cbSanguineo.SelectedItem.ToString();
            //string rh = cbRH.SelectedIndex == -1 ? null : cbRH.SelectedItem.ToString();
            //string estadoEscola = cbEstadoEscola.SelectedIndex == -1 ? null : cbEstadoEscola.SelectedItem.ToString();

            try
            {
                SqlCommand cmdInsert = new SqlCommand(insertAluno, conn);

                cmdInsert.Parameters.AddWithValue("@nome", txtNome.Text);
                cmdInsert.Parameters.AddWithValue("@dtNasc", dpNascimento.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@sexo", sexo);
                cmdInsert.Parameters.AddWithValue("@nacionalidade", txtNacionalidade.Text);
                cmdInsert.Parameters.AddWithValue("@naturalidade", txtNaturalidade.Text);
                cmdInsert.Parameters.AddWithValue("@estadoCivil", cbEstadoCivil.SelectedItem.ToString());
                cmdInsert.Parameters.AddWithValue("@estado", cbEstado.SelectedItem.ToString());
                cmdInsert.Parameters.AddWithValue("@religiao", cbReligiao.SelectedItem.ToString());
                cmdInsert.Parameters.AddWithValue("@tipoSanguineo", cbSanguineo.SelectedItem.ToString());
                cmdInsert.Parameters.AddWithValue("@rh", cbRH.SelectedItem.ToString());
                cmdInsert.Parameters.AddWithValue("@nomePai", txtNomePai.Text);
                cmdInsert.Parameters.AddWithValue("@nomeMae", txtNomeMae.Text);
                cmdInsert.Parameters.AddWithValue("@email", txtEmail.Text);
                cmdInsert.Parameters.AddWithValue("@cep", txtCep.Text);
                cmdInsert.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmdInsert.Parameters.AddWithValue("@numero", txtNumero.Text);
                cmdInsert.Parameters.AddWithValue("@complemento", txtComplemento.Text);
                cmdInsert.Parameters.AddWithValue("@bairro", txtBairro.Text);
                cmdInsert.Parameters.AddWithValue("@municipio", txtMunicipio.Text);
                cmdInsert.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmdInsert.Parameters.AddWithValue("@dataEmissaoCpf", dpEmissaoCpf.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@rg", txtRg.Text);
                cmdInsert.Parameters.AddWithValue("@dataEmissaoRg", dpEmissaoRg.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@tituloEleitor", txtTitulo.Text);
                cmdInsert.Parameters.AddWithValue("@secao", txtSecaoTitulo.Text);
                cmdInsert.Parameters.AddWithValue("@zona", txtZonaTitulo.Text);
                cmdInsert.Parameters.AddWithValue("@escola", txtEscola.Text);
                cmdInsert.Parameters.AddWithValue("@cidadeEscola", txtCidadeEscola.Text);
                cmdInsert.Parameters.AddWithValue("@estadoEscola", cbEstadoEscola.SelectedItem.ToString());
                cmdInsert.Parameters.AddWithValue("@anoConclusao", dpConclusaoEscola.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@classificacao", txtClassificacao.Text);
                cmdInsert.Parameters.AddWithValue("@pontuacao", txtPontuacao.Text);
                cmdInsert.Parameters.AddWithValue("@curso", cbCurso.SelectedItem.ToString());
                cmdInsert.Parameters.AddWithValue("@turno", cbTurno.SelectedItem.ToString());
                
                conn.Open();
                cmdInsert.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro:" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
