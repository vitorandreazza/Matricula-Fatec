using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Matricula.View;
using Matricula.Model;
using System.Windows.Forms;

namespace Matricula.Controller
{
    class LoginController
    {
        private SqlConnection conn = new Conexao().Conn;
        
        public int logar(LoginModel login)
        {
            int retorno = 0;
            try
            {
                conn.Open();

                string logando = "select COUNT(*) from Logins where login = @login and senha = @senha";

                SqlCommand objlogin = new SqlCommand(logando, conn);
                objlogin.Parameters.AddWithValue("@login", login.Login);
                objlogin.Parameters.AddWithValue("@senha", login.Senha);
                retorno = (int)objlogin.ExecuteScalar();
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
            finally
            {
                conn.Close();
            }
            return retorno;
        }

        public DataSet pesLogins()
        {
            DataSet dt = new DataSet();
            try
            {
                conn.Open();
                string consulta = "SELECT * FROM Logins";
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

        public void cadastrarLogin(LoginModel login)
        {
            try
            {
                conn.Open();
                string consulta = "INSERT INTO Logins(Login,Senha) VALUES (@login,@senha)";
                SqlCommand novo = new SqlCommand(consulta, conn);
                novo.Parameters.AddWithValue("@login", login.Login);
                novo.Parameters.AddWithValue("@senha", login.Senha);
                novo.ExecuteNonQuery();
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
        }
    }
}
