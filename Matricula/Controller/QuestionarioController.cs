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
    class QuestionarioController
    {
        private SqlConnection conn = new Conexao().Conn;

        public void inserir(QuestionarioModel qt) //int matriculaId)
        {
            string inserirQuestionario = "INSERT INTO Questionarios"+
            "(q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, q14, q15, q16, q17, q18, q19,"+
            "q20, q21, q22, q23, q24, q25, q26)"+
            "VALUES"+
            "(@q1, @q2, @q3, @q4, @q5, @q6, @q7, @q8, @q9, @q10, @q11, @q12, @q13, @q14, @q15, @q16,"+
            "@q17, @q18, @q19, @q20, @q21, @q22, @q23, @q24, @q25, @q26)";

            try
            {
                SqlCommand cmdInsertQuestionario = new SqlCommand(inserirQuestionario, conn);
                for (int i = 0; i < 26; i++)
                {
                    cmdInsertQuestionario.Parameters.AddWithValue("@q"+(i+1), qt.Respostas[i]);
                }
                //cmdInsertQuestionario.Parameters.AddWithValue("@q1", qt.Respostas[0]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q2", qt.Respostas[1]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q3", qt.Respostas[2]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q4", qt.Respostas[3]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q5", qt.Respostas[4]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q6", qt.Respostas[5]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q7", qt.Respostas[6]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q8", qt.Respostas[7]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q9", qt.Respostas[8]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q10", qt.Respostas[9]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q11", qt.Respostas[10]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q12", qt.Respostas[11]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q13", qt.Respostas[12]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q14", qt.Respostas[13]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q15", qt.Respostas[14]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q16", qt.Respostas[15]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q17", qt.Respostas[16]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q18", qt.Respostas[17]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q19", qt.Respostas[18]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q20", qt.Respostas[19]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q21", qt.Respostas[20]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q22", qt.Respostas[21]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q23", qt.Respostas[22]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q24", qt.Respostas[23]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q25", qt.Respostas[24]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@q26", qt.Respostas[25]);
                //cmdInsertQuestionario.Parameters.AddWithValue("@codMatricula", matriculaId);

                conn.Open();
                cmdInsertQuestionario.ExecuteNonQuery();
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
    }
}
