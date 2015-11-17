using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Matricula.Controller
{
    class Conexao
    {
        private SqlConnection conn = null;

        public SqlConnection Conn
        {
            get { return conn; }
        }

        public Conexao()
        {
            try
            {
                string strConn = Matricula.Properties.Settings.Default.DBMatriculaConnectionString;
                conn = new SqlConnection(strConn);
            }
            catch(SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }
    }
}
