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
                string consulta = "select * from TodosAlunos order by TodosAlunos.nome ASC;"; //view
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
        public DataSet PesquisaAluno(MatriculaModel mat, string tipo)
        {
            DataSet dt = new DataSet();
            try
            {

                conn.Open();
                if (tipo.Equals("Nome"))
                {
                    string consulta = "select Matriculas.*, Celulares.celular,Fixos.telefone from Matriculas LEFT join Celulares ON(Matriculas.codigo= Celulares.codMatricula) LEFT join Fixos ON(Matriculas.codigo = Fixos.codMatricula) where Matriculas.nome like '" + mat.Nome + "%' order by Matriculas.nome ASC";
                    SqlCommand cons = new SqlCommand(consulta, conn);
                    //cons.Parameters.AddWithValue("@nome", mat.Nome);
                    SqlDataAdapter da = new SqlDataAdapter(cons);
                    da.Fill(dt);
                }
                else if (tipo.Equals("CPF"))
                {
                    string consulta = "select Matriculas.*, Celulares.celular,Fixos.telefone from Matriculas LEFT join Celulares ON(Matriculas.codigo= Celulares.codMatricula) LEFT join Fixos ON(Matriculas.codigo = Fixos.codMatricula) where Matriculas.cpf = @cpf order by Matriculas.nome ASC";
                    SqlCommand cons = new SqlCommand(consulta, conn);
                    cons.Parameters.AddWithValue("@cpf", mat.Cpf);
                    SqlDataAdapter da = new SqlDataAdapter(cons);
                    da.Fill(dt);
                }
                else if (tipo.Equals("Cidade"))
                {
                    string consulta = "select Matriculas.*, Celulares.celular,Fixos.telefone from Matriculas LEFT join Celulares ON(Matriculas.codigo= Celulares.codMatricula) LEFT join Fixos ON(Matriculas.codigo = Fixos.codMatricula) where Matriculas.municipio = @cid order by Matriculas.nome ASC";
                    SqlCommand cons = new SqlCommand(consulta, conn);
                    cons.Parameters.AddWithValue("@cid", mat.Municipio);
                    SqlDataAdapter da = new SqlDataAdapter(cons);
                    da.Fill(dt);
                }
                else if (tipo.Equals("Escola"))
                {
                    string consulta = "select Matriculas.*, Celulares.celular,Fixos.telefone from Matriculas LEFT join Celulares ON(Matriculas.codigo= Celulares.codMatricula) LEFT join Fixos ON(Matriculas.codigo = Fixos.codMatricula) where Matriculas.escola like '" + mat.Escola + "%' order by Matriculas.nome ASC";
                    SqlCommand cons = new SqlCommand(consulta, conn);
                    //cons.Parameters.AddWithValue("@escola", mat.Escola);
                    SqlDataAdapter da = new SqlDataAdapter(cons);
                    da.Fill(dt);
                }
                else if (tipo.Equals("Religiao"))
                {
                    string consulta = "select Matriculas.*, Celulares.celular,Fixos.telefone from Matriculas LEFT join Celulares ON(Matriculas.codigo= Celulares.codMatricula) LEFT join Fixos ON(Matriculas.codigo = Fixos.codMatricula) where Matriculas.religiao like '" + mat.Religiao + "%' order by Matriculas.nome ASC";
                    SqlCommand cons = new SqlCommand(consulta, conn);
                    // cons.Parameters.AddWithValue("@religiao", mat.Religiao);
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

        public DataSet login()
        {
            DataSet dt = new DataSet();
            try
            {
                conn.Open();
                string consulta = "select * from logins";
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
        // Pesquisa por curso
        public DataSet PesquisaCurso(string Curso, string Turno)
        {
            DataSet dt = new DataSet();
            try
            {
                if (Curso != "Gestão da Tecnologia da Informação")
                {
                    conn.Open();
                    string consulta = "select Matriculas.*, Celulares.celular,Fixos.telefone from Matriculas LEFT join Celulares ON(Matriculas.codigo= Celulares.codMatricula) LEFT join Fixos ON(Matriculas.codigo = Fixos.codMatricula) where Matriculas.curso= @curso order by Matriculas.nome ASC";
                    SqlCommand cons = new SqlCommand(consulta, conn);
                    cons.Parameters.AddWithValue("@curso", Curso);
                    SqlDataAdapter da = new SqlDataAdapter(cons);
                    da.Fill(dt);
                }
                else if (Curso.Equals("Gestão da Tecnologia da Informação"))
                {
                    string consulta = "select Matriculas.*, Celulares.celular,Fixos.telefone from Matriculas LEFT join Celulares ON(Matriculas.codigo= Celulares.codMatricula) LEFT join Fixos ON(Matriculas.codigo = Fixos.codMatricula) where Matriculas.curso= @curso and Matriculas.turno = @turno order by Matriculas.nome ASC";
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
    }
}
