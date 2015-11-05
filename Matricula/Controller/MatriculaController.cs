using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
//Imports projeto
using Matricula.Model;

namespace Matricula.Controller
{
    class MatriculaController 
    {
        private SqlConnection conn = new Conexao().Conn;

        public void inserir(MatriculaModel matricula)
        {
            string insertMatricula = "INSERT INTO Matriculas" +
            "(nome, dtNasc, sexo, nacionalidade, naturalidade, estadoCivil, estado, religiao," +
            "tipoSanguineo, rh, nomePai, nomeMae, email, cep, endereco, numero, complemento," +
            "bairro, municipio, cpf, dataEmissaoCpf, rg, dataEmissaoRg, tituloEleitor, secao, zona, escola," +
            "cidadeEscola, estadoEscola, anoConclusao, classificacao, pontuacao, curso, turno)" +
            "VALUES" +
            "(@nome, @dtNasc, @sexo, @nacionalidade, @naturalidade, @estadoCivil, @estado, @religiao," +
            "@tipoSanguineo, @rh, @nomePai, @nomeMae, @email, @cep, @endereco, @numero, @complemento," +
            "@bairro, @municipio, @cpf, @dataEmissaoCpf, @rg, @dataEmissaoRg, @tituloEleitor, @secao, @zona, @escola," +
            "@cidadeEscola, @estadoEscola, @anoConclusao, @classificacao, @pontuacao, @curso, @turno); SELECT SCOPE_IDENTITY()";
            //SELECT SCOPE_IDENTITY() -> Retorna o último valor de identidade inserido em uma coluna de identidade no mesmo escopo
            
            try
            {
                SqlCommand cmdInsertMatricula = new SqlCommand(insertMatricula, conn);

                cmdInsertMatricula.Parameters.AddWithValue("@nome", matricula.Nome);
                cmdInsertMatricula.Parameters.AddWithValue("@dtNasc", matricula.Nascimento);
                cmdInsertMatricula.Parameters.AddWithValue("@sexo", matricula.Sexo);
                cmdInsertMatricula.Parameters.AddWithValue("@nacionalidade", matricula.Nacionalidade);
                cmdInsertMatricula.Parameters.AddWithValue("@naturalidade", matricula.Naturalidade);
                cmdInsertMatricula.Parameters.AddWithValue("@estadoCivil", matricula.EstadoCivil);
                cmdInsertMatricula.Parameters.AddWithValue("@estado", matricula.Estado);
                cmdInsertMatricula.Parameters.AddWithValue("@religiao", matricula.Religiao);
                cmdInsertMatricula.Parameters.AddWithValue("@tipoSanguineo", matricula.TpSanguineo);
                cmdInsertMatricula.Parameters.AddWithValue("@rh", matricula.Rh);
                cmdInsertMatricula.Parameters.AddWithValue("@nomePai", matricula.NomePai);
                cmdInsertMatricula.Parameters.AddWithValue("@nomeMae", matricula.NomeMae);
                cmdInsertMatricula.Parameters.AddWithValue("@email", matricula.Email);
                cmdInsertMatricula.Parameters.AddWithValue("@cep", matricula.Cep);
                cmdInsertMatricula.Parameters.AddWithValue("@endereco", matricula.Endreco);
                cmdInsertMatricula.Parameters.AddWithValue("@numero", matricula.Numero);
                cmdInsertMatricula.Parameters.AddWithValue("@complemento", matricula.Complemento);
                cmdInsertMatricula.Parameters.AddWithValue("@bairro", matricula.Bairro);
                cmdInsertMatricula.Parameters.AddWithValue("@municipio", matricula.Municipio);
                cmdInsertMatricula.Parameters.AddWithValue("@cpf", matricula.Cpf);
                cmdInsertMatricula.Parameters.AddWithValue("@dataEmissaoCpf", matricula.EmissaoCpf);
                cmdInsertMatricula.Parameters.AddWithValue("@rg", matricula.Rg);
                cmdInsertMatricula.Parameters.AddWithValue("@dataEmissaoRg", matricula.EmissaoRg);
                cmdInsertMatricula.Parameters.AddWithValue("@tituloEleitor", matricula.Titulo);
                cmdInsertMatricula.Parameters.AddWithValue("@secao", matricula.SecaoTitulo);
                cmdInsertMatricula.Parameters.AddWithValue("@zona", matricula.ZonaTitulo);
                cmdInsertMatricula.Parameters.AddWithValue("@escola", matricula.Escola);
                cmdInsertMatricula.Parameters.AddWithValue("@cidadeEscola", matricula.CidadeEscola);
                cmdInsertMatricula.Parameters.AddWithValue("@estadoEscola", matricula.EstadoEscola);
                cmdInsertMatricula.Parameters.AddWithValue("@anoConclusao", matricula.ConclusaoEscola);
                cmdInsertMatricula.Parameters.AddWithValue("@classificacao", matricula.Classificacao);
                cmdInsertMatricula.Parameters.AddWithValue("@pontuacao", matricula.Pontuacao);
                cmdInsertMatricula.Parameters.AddWithValue("@curso", matricula.Curso);
                cmdInsertMatricula.Parameters.AddWithValue("@turno", matricula.Turno);

                conn.Open();
                //Armazena a ultima chave primaria inserida
                matricula.CodMatricula = Convert.ToInt32(cmdInsertMatricula.ExecuteScalar());
            }
            catch(SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }
    }
}
