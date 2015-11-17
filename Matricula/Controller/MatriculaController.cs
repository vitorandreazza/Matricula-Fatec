using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
//Imports projeto
using Matricula.Model;
using System.Data;

namespace Matricula.Controller
{
    class MatriculaController 
    {
        private SqlConnection conn = new Conexao().Conn;

        public void inserir(MatriculaModel matricula)
        {
            string insertMatricula = "INSERT INTO Matriculas" +
            "(nome, dtNasc, sexo, nacionalidade, naturalidade, cor, estadoCivil, estado, religiao," +
            "tipoSanguineo, rh, nomePai, nomeMae, email, cep, endereco, numero, complemento," +
            "bairro, municipio, cpf, dataEmissaoCpf, rg, dataEmissaoRg, expedidoRG, reservaMilitar, expedidoMilitar, dataMilitar, tituloEleitor, secao, zona, escola," +
            "cidadeEscola, estadoEscola, anoConclusao, classificacao, pontuacao, curso, turno, foto)" +
            "VALUES" +
            "(@nome, @dtNasc, @sexo, @nacionalidade, @naturalidade, @Cor,@estadoCivil, @estado, @religiao," +
            "@tipoSanguineo, @rh, @nomePai, @nomeMae, @email, @cep, @endereco, @numero, @complemento," +
            "@bairro, @municipio, @cpf, @dataEmissaoCpf, @rg, @dataEmissaoRg, @ExpedidoRg, @reservista, @ExpReservista, @dataReservista, @tituloEleitor, @secao, @zona, @escola," +
            "@cidadeEscola, @estadoEscola, @anoConclusao, @classificacao, @pontuacao, @curso, @turno, @foto); SELECT SCOPE_IDENTITY()";
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
                cmdInsertMatricula.Parameters.AddWithValue("@ExpedidoRg", matricula.ExpedidoRG);
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
                cmdInsertMatricula.Parameters.AddWithValue("@foto", matricula.Foto == null ? new byte[0] : matricula.Foto);
                cmdInsertMatricula.Parameters.AddWithValue("@Cor", matricula.Cor);
                cmdInsertMatricula.Parameters.AddWithValue("@reservista", matricula.ReservaMilitar);
                cmdInsertMatricula.Parameters.AddWithValue("@dataReservista", matricula.DataMilitar);
                cmdInsertMatricula.Parameters.AddWithValue("@ExpReservista", matricula.ExpedidoMilitar);
                conn.Open();
                //Armazena a ultima chave primaria inserida
                matricula.CodMatricula = Convert.ToInt32(cmdInsertMatricula.ExecuteScalar());
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }

        //consultas

        public DataSet PesquisaTodosAlunos()
        {
            DataSet dt = new DataSet();
            try
            {
                conn.Open();
                string consulta = "SELECT * FROM Matriculas ORDER BY Matriculas.codigo ASC;"; //view
                SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
                da.Fill(dt);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        //Consulta aluno
        public DataSet PesquisaAluno(string mat, string tipo)
        {
            DataSet dt = new DataSet();
            try
            {

                conn.Open();
                string consulta = "SELECT * FROM Matriculas WHERE Matriculas."+tipo+" like @param + '%' ORDER BY Matriculas.codigo ASC";
                SqlCommand cons = new SqlCommand(consulta, conn);
                cons.Parameters.AddWithValue("@param", mat);
                SqlDataAdapter da = new SqlDataAdapter(cons);
                da.Fill(dt);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        // Pesquisa por curso
        public DataSet PesquisaCurso(string Curso, string Turno)
        {
            DataSet dt = new DataSet();
            try
            {
                conn.Open();
                if (Curso != "Gestão da Tecnologia da Informação")
                {
                    string consulta = "SELECT * FROM Matriculas WHERE Matriculas.curso= @curso ORDER BY Matriculas.codigo ASC";
                    SqlCommand cons = new SqlCommand(consulta, conn);
                    cons.Parameters.AddWithValue("@curso", Curso);
                    SqlDataAdapter da = new SqlDataAdapter(cons);
                    da.Fill(dt);
                }
                else if (Curso.Equals("Gestão da Tecnologia da Informação"))
                {
                    string consulta = "SELECT * FROM Matriculas WHERE Matriculas.curso = @curso AND Matriculas.turno = @turno ORDER BY Matriculas.codigo ASC";
                    SqlCommand cons = new SqlCommand(consulta, conn);
                    cons.Parameters.AddWithValue("@curso", Curso);
                    cons.Parameters.AddWithValue("@turno", Turno);
                    SqlDataAdapter da = new SqlDataAdapter(cons);
                    da.Fill(dt);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public void deletarMatricula(int cod)
        {
            try
            {
                string deletar = "DELETE FROM Matriculas WHERE codigo= @cod;"
                + "DELETE FROM Celulares WHERE codMatricula = @cod2;"
                + "DELETE FROM Fixos WHERE codMatricula = @cod3;";

                SqlCommand del = new SqlCommand(deletar, conn);
                del.Parameters.AddWithValue("@cod", cod);
                del.Parameters.AddWithValue("@cod2", cod);
                del.Parameters.AddWithValue("@cod3", cod);
                conn.Open();
                del.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet pesquisarAlunoEsp(int codigo)
        {
            DataSet dt = new DataSet();
            try
            {
                string select = "SELECT * FROM Matriculas WHERE Matriculas.codigo = @codigo";

                SqlCommand pes = new SqlCommand(select, conn);
                pes.Parameters.AddWithValue("@codigo", codigo);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(pes);
                da.Fill(dt);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
