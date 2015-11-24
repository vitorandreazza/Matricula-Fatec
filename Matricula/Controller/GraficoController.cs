using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//gráfico
using Syncfusion.Windows.Forms.Chart;
//sql
using System.Data.SqlClient;
using System.Data;
using Matricula.Model;

namespace Matricula.Controller
{
    public partial class GraficoController
    {
         private SqlConnection con = new Conexao().Conn;
         private GraficoModel gm = new GraficoModel();
         private ChartSeries cs = new ChartSeries();
         private int[] x = new int[26];
            
        public ChartSeries gerarGrafico(int questao)
        {
            x = gm.totalAlternativas();
            try
            {
                con.Open();
                for (int i = 1; i <= this.x[questao-1]; i++)
                {
                    string consulta = "SELECT COUNT(q" + questao + ") FROM Questionarios WHERE q" + questao + "='" + i + "'";
                    SqlCommand comando = new SqlCommand(consulta, con);
                    int r = (int)comando.ExecuteScalar();
                    this.cs.Points.Add(i, r);
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
                con.Close();
            }
            return cs;
        }

    }
}
