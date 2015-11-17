using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Matricula.View;
using Matricula.Model;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace Matricula.Controller
{
    class LoginController
    {
        public int logar(LoginModel login)
        {
            MessageBoxApparence.getMessageBoxApparence();
            SqlConnection con = new Conexao().Conn;
            int retorno = 0;
            try
            {
                con.Open();

                string logando = "select COUNT(*) from Logins where login = @login and senha = @senha";

                SqlCommand objlogin = new SqlCommand(logando, con);
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

                MessageBoxAdv.Show(str, "Database Exception");
            }
            finally
            {
                con.Close();
            }
            return retorno;
        }
    }
}
