using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
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

        public void alterarMatricula(int cod, MatriculaModel matricula)
        {
            SqlConnection Con = new Conexao().Conn;
            Con.Open();
            try
            {
                string atualizar = "UPDATE Matriculas SET nome=@nome, dtNasc=@dtNasc, sexo=@sexo, nacionalidade=@nacionalidade, naturalidade=@naturalidade, cor=@Cor, estadoCivil=@estadoCivil, estado=@estado, religiao=@religiao," +
                    "tipoSanguineo=@tipoSanguineo, rh=@rh, nomePai=@nomePai, nomeMae=@nomeMae, email=@email, cep=@cep, endereco=@endereco, numero=@numero, complemento=@complemento," +
                    "bairro=@bairro, municipio=@municipio, cpf=@cpf, dataEmissaoCpf=@dataEmissaoCpf, rg=@rg, dataEmissaoRg=@dataEmissaoRg, expedidoRG=@ExpedidoRg, reservaMilitar=@reservista, expedidoMilitar=@ExpReservista, dataMilitar=@dataReservista, tituloEleitor=@tituloEleitor, secao=@secao, zona=@zona, escola=@escola," +
                    "cidadeEscola=@cidadeEscola, estadoEscola=@estadoEscola, anoConclusao=@anoConclusao, classificacao=@classificacao, pontuacao=@pontuacao, curso=@curso, turno=@turno, foto=@foto where codigo= @cod";

                SqlCommand updt = new SqlCommand(atualizar, Con);
                updt.Parameters.AddWithValue("@nome", matricula.Nome);
                updt.Parameters.AddWithValue("@dtNasc", matricula.Nascimento);
                updt.Parameters.AddWithValue("@sexo", matricula.Sexo);
                updt.Parameters.AddWithValue("@nacionalidade", matricula.Nacionalidade);
                updt.Parameters.AddWithValue("@naturalidade", matricula.Naturalidade);
                updt.Parameters.AddWithValue("@estadoCivil", matricula.EstadoCivil);
                updt.Parameters.AddWithValue("@estado", matricula.Estado);
                updt.Parameters.AddWithValue("@religiao", matricula.Religiao);
                updt.Parameters.AddWithValue("@tipoSanguineo", matricula.TpSanguineo);
                updt.Parameters.AddWithValue("@rh", matricula.Rh);
                updt.Parameters.AddWithValue("@nomePai", matricula.NomePai);
                updt.Parameters.AddWithValue("@nomeMae", matricula.NomeMae);
                updt.Parameters.AddWithValue("@email", matricula.Email);
                updt.Parameters.AddWithValue("@cep", matricula.Cep);
                updt.Parameters.AddWithValue("@endereco", matricula.Endreco);
                updt.Parameters.AddWithValue("@numero", matricula.Numero);
                updt.Parameters.AddWithValue("@complemento", matricula.Complemento);
                updt.Parameters.AddWithValue("@bairro", matricula.Bairro);
                updt.Parameters.AddWithValue("@municipio", matricula.Municipio);
                updt.Parameters.AddWithValue("@cpf", matricula.Cpf);
                updt.Parameters.AddWithValue("@dataEmissaoCpf", matricula.EmissaoCpf);
                updt.Parameters.AddWithValue("@rg", matricula.Rg);
                updt.Parameters.AddWithValue("@dataEmissaoRg", matricula.EmissaoRg);
                updt.Parameters.AddWithValue("@ExpedidoRg", matricula.ExpedidoRG);
                updt.Parameters.AddWithValue("@tituloEleitor", matricula.Titulo);
                updt.Parameters.AddWithValue("@secao", matricula.SecaoTitulo);
                updt.Parameters.AddWithValue("@zona", matricula.ZonaTitulo);
                updt.Parameters.AddWithValue("@escola", matricula.Escola);
                updt.Parameters.AddWithValue("@cidadeEscola", matricula.CidadeEscola);
                updt.Parameters.AddWithValue("@estadoEscola", matricula.EstadoEscola);
                updt.Parameters.AddWithValue("@anoConclusao", matricula.ConclusaoEscola);
                updt.Parameters.AddWithValue("@classificacao", matricula.Classificacao);
                updt.Parameters.AddWithValue("@pontuacao", matricula.Pontuacao);
                updt.Parameters.AddWithValue("@curso", matricula.Curso);
                updt.Parameters.AddWithValue("@turno", matricula.Turno);
                updt.Parameters.AddWithValue("@foto", matricula.Foto == null ? new byte[0] : matricula.Foto);
                updt.Parameters.AddWithValue("@Cor", matricula.Cor);
                updt.Parameters.AddWithValue("@reservista", matricula.ReservaMilitar);
                updt.Parameters.AddWithValue("@dataReservista", matricula.DataMilitar);
                updt.Parameters.AddWithValue("@ExpReservista", matricula.ExpedidoMilitar);
                updt.Parameters.AddWithValue("@cod", cod);

                updt.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            finally
            {
                Con.Close();
            }
        }
        public List<ReportParameter> relatorioFicha(string cpf, int codigo)
        {
            List<ReportParameter> listaFicha = new List<ReportParameter>();
            try
            {
                conn.Open();
                DataSet dt = new DataSet();
                string consulta;
                if (cpf != null)
                {
                    consulta = "SELECT Matriculas.*,Fixos.telefone FROM Matriculas left join Fixos ON (Matriculas.codigo=Fixos.codMatricula) WHERE cpf='" + cpf + "'";
                }
                else
                {
                    consulta = "SELECT Matriculas.*,Fixos.telefone FROM Matriculas left join Fixos ON (Matriculas.codigo=Fixos.codMatricula) WHERE codigo=" + codigo + "";
                }
                SqlCommand da = new SqlCommand(consulta, conn);
                SqlDataReader reader;
                reader = da.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        listaFicha.Add(new ReportParameter("nome", reader["nome"].ToString()));
                        listaFicha.Add(new ReportParameter("classificacao", reader["classificacao"].ToString()));
                        listaFicha.Add(new ReportParameter("pontuacao", reader["pontuacao"].ToString()));
                        listaFicha.Add(new ReportParameter("rg", reader["rg"].ToString()));
                        listaFicha.Add(new ReportParameter("endereco", reader["endereco"].ToString()));
                        listaFicha.Add(new ReportParameter("numero", reader["numero"].ToString()));
                        listaFicha.Add(new ReportParameter("bairro", reader["bairro"].ToString()));
                        listaFicha.Add(new ReportParameter("cidade", reader["municipio"].ToString()));
                        listaFicha.Add(new ReportParameter("cep", reader["cep"].ToString()));
                        listaFicha.Add(new ReportParameter("curso", reader["curso"].ToString()));
                        listaFicha.Add(new ReportParameter("turno", reader["turno"].ToString()));
                        listaFicha.Add(new ReportParameter("fone", reader["telefone"].ToString()));

                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            finally
            {
                conn.Close();
            }
                return listaFicha;
               
        }
        public List<ReportParameter> relatorioDados(string cpf, int codigo)
        {
            List<ReportParameter> listaDados = new List<ReportParameter>();
            try
            {
                conn.Open();
                DataSet dt = new DataSet();
                string consulta;
                if (cpf != null)
                {
                    consulta = "SELECT Matriculas.*,Fixos.telefone,Celulares.celular FROM Matriculas left join Fixos ON (Matriculas.codigo=Fixos.codMatricula) left join Celulares ON (Matriculas.codigo=Celulares.codMatricula) WHERE cpf='" + cpf + "'";
                }
                else
                {
                    consulta = "SELECT Matriculas.*,Fixos.telefone,Celulares.celular FROM Matriculas left join Fixos ON (Matriculas.codigo=Fixos.codMatricula) left join Celulares ON (Matriculas.codigo=Celulares.codMatricula) WHERE codigo=" + codigo + "";
                }

                SqlCommand da = new SqlCommand(consulta, conn);
                SqlDataReader reader;
                reader = da.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listaDados.Add(new ReportParameter("nome", reader["nome"].ToString()));
                        listaDados.Add(new ReportParameter("dataNasc", Convert.ToDateTime(reader["dtNasc"].ToString()).ToString("dd/MM/yyyy")));
                        if (reader["sexo"].ToString() == "M") { listaDados.Add(new ReportParameter("sexo", "Masculino")); }
                        else if (reader["sexo"].ToString() == "F") { listaDados.Add(new ReportParameter("sexo", "Feminino")); }
                        listaDados.Add(new ReportParameter("estadoCivil", reader["nome"].ToString()));
                        listaDados.Add(new ReportParameter("naturalidade", reader["naturalidade"].ToString()));
                        listaDados.Add(new ReportParameter("estado", reader["estado"].ToString()));
                        listaDados.Add(new ReportParameter("nacionalidade", reader["nacionalidade"].ToString()));
                        listaDados.Add(new ReportParameter("cor", reader["cor"].ToString()));
                        listaDados.Add(new ReportParameter("religiao", reader["religiao"].ToString()));
                        listaDados.Add(new ReportParameter("tipoSanguineo", reader["tipoSanguineo"].ToString()));
                        listaDados.Add(new ReportParameter("cpf", reader["cpf"].ToString()));
                        if (reader["dataEmissaoCpf"].ToString() != "")
                            listaDados.Add(new ReportParameter("dtCpf", Convert.ToDateTime(reader["dataEmissaoCpf"].ToString()).ToString("dd/MM/yyyy")));
                        listaDados.Add(new ReportParameter("reservista", reader["reservaMilitar"].ToString()));
                        if (reader["dataMilitar"].ToString() != "")//
                            listaDados.Add(new ReportParameter("dtReservista", Convert.ToDateTime(reader["dataMilitar"].ToString()).ToString("dd/MM/yyyy")));
                        listaDados.Add(new ReportParameter("expReservista", reader["expedidoMilitar"].ToString()));
                        listaDados.Add(new ReportParameter("rg", reader["rg"].ToString()));
                        listaDados.Add(new ReportParameter("expRg", reader["expedidoRG"].ToString()));
                        if (reader["dataEmissaoRg"].ToString() != "")//
                            listaDados.Add(new ReportParameter("dtRg", Convert.ToDateTime(reader["dataEmissaoRg"].ToString()).ToString("dd/MM/yyyy")));
                        listaDados.Add(new ReportParameter("titulo", reader["tituloEleitor"].ToString()));
                        listaDados.Add(new ReportParameter("secao", reader["secao"].ToString()));
                        listaDados.Add(new ReportParameter("zona", reader["zona"].ToString()));
                        listaDados.Add(new ReportParameter("nomePai", reader["nomePai"].ToString()));
                        listaDados.Add(new ReportParameter("nomeMae", reader["nomeMae"].ToString()));
                        listaDados.Add(new ReportParameter("endereco", reader["endereco"].ToString()));
                        listaDados.Add(new ReportParameter("nro", reader["numero"].ToString()));
                        listaDados.Add(new ReportParameter("complemento", reader["complemento"].ToString()));
                        listaDados.Add(new ReportParameter("cep", reader["cep"].ToString()));
                        listaDados.Add(new ReportParameter("bairro", reader["bairro"].ToString()));
                        listaDados.Add(new ReportParameter("cidade", reader["municipio"].ToString()));
                        listaDados.Add(new ReportParameter("fone", reader["telefone"].ToString()));
                        listaDados.Add(new ReportParameter("celular", reader["celular"].ToString()));
                        listaDados.Add(new ReportParameter("escola", reader["escola"].ToString()));
                        listaDados.Add(new ReportParameter("cidadeEscola", reader["cidadeEscola"].ToString()));
                        listaDados.Add(new ReportParameter("estadoEscola", reader["estadoEscola"].ToString()));
                        listaDados.Add(new ReportParameter("anoEscola", reader["anoConclusao"].ToString()));
                        listaDados.Add(new ReportParameter("email", reader["email"].ToString()));
                        listaDados.Add(new ReportParameter("rh", reader["rh"].ToString()));
                    }
                }

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            finally
            {
                conn.Close();
            }
            return listaDados;
        }

       
    }
}
