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
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using AForge.Video.DirectShow;
using AForge.Video;
using System.IO;

namespace Matricula
{
    public partial class MatriculaForm : Syncfusion.Windows.Forms.MetroForm
    {
        private int countC = 0, countR = 0;
        private TextBox[] txtRArray = new TextBox[3], txtCArray = new TextBox[3];
        private VideoCaptureDevice videoDevice;

        public MatriculaForm()
        {
            InitializeComponent();

            MetroStyleColorTable metroColor = new MetroStyleColorTable();
            metroColor.YesButtonBackColor = Color.FromArgb(0, 191, 177);
            metroColor.NoButtonBackColor = Color.FromArgb(206, 59, 41);
            metroColor.OKButtonBackColor = Color.FromArgb(0, 191, 177);
            metroColor.BackColor = Color.FromArgb(245, 245, 245);
            metroColor.ForeColor = Color.FromArgb(105, 105, 105);//Cor da fonte
            metroColor.BorderColor = Color.FromArgb(0, 191, 177);
            metroColor.CloseButtonColor = Color.FromArgb(255, 255, 255);
            metroColor.CloseButtonHoverColor = Color.FromArgb(255, 255, 255);//Cor do botão com o mouse em cima
            metroColor.CaptionBarColor = Color.FromArgb(0, 191, 177);//Cor da barra
            metroColor.CaptionForeColor = Color.FromArgb(255, 255, 255);//Cor da fonte da barra
            MessageBoxAdv.MetroColorTable = metroColor;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;

            btnMaisR_Click(btnMaisR, new EventArgs());
            btnMainC_Click(btnMainC, new EventArgs());
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (!(ValidaCpf.validaCpf(mtxtCpf.Text)) && mtxtCpf.Text != "   .   .   -  ")
            {
                MessageBoxAdv.Show(this, "O CPF é inválido", "Erro");
                return;
            }

            if (MessageBoxAdv.Show(this, "Deseja realmente confirmar a matrícula?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            byte[] imgArray = null;

            if(ptFotoPes != null && ptFotoPes.Image != null)
            {
                //Stream do array
                MemoryStream stream = new MemoryStream();
                //salva a imagem no stream
                ptFotoPes.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                //transferir o stream para o array de bytes
                imgArray = stream.ToArray();
            }

            string strConn = Matricula.Properties.Settings.Default.ConnMatricula;
            SqlConnection conn = new SqlConnection(strConn);

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
            
            char sexo = '\0';//Atribui NULL a um char

            if (cbSexo.Text == "Masculino")
            {
                sexo = 'M';
            }
            else if (cbSexo.Text == "Feminino")
            {
                sexo = 'F';
            }

            try
            {
                SqlCommand cmdInsertMatricula = new SqlCommand(insertMatricula, conn);

                cmdInsertMatricula.Parameters.AddWithValue("@nome", txtNome.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@dtNasc", dpNascimento.Value.ToString("yyyy-MM-dd"));
                cmdInsertMatricula.Parameters.AddWithValue("@sexo", sexo);
                cmdInsertMatricula.Parameters.AddWithValue("@nacionalidade", txtNacionalidade.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@naturalidade", txtNaturalidade.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@estadoCivil", cbEstadoCivil.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@estado", cbEstado.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@religiao", cbReligiao.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@tipoSanguineo", cbSanguineo.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@rh", cbRH.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@nomePai", txtNomePai.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@nomeMae", txtNomeMae.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@email", txtEmail.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@cep", mtxtCep.Text.Replace("-", ""));
                cmdInsertMatricula.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@numero", txtNumero.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@complemento", txtComplemento.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@bairro", txtBairro.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@municipio", txtMunicipio.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@cpf", mtxtCpf.Text.Replace(".", "").Replace("-", ""));
                cmdInsertMatricula.Parameters.AddWithValue("@dataEmissaoCpf", dpEmissaoCpf.Value.ToString("yyyy-MM-dd"));
                cmdInsertMatricula.Parameters.AddWithValue("@rg", mtxtRg.Text.Replace(".", "").Replace("-", ""));
                cmdInsertMatricula.Parameters.AddWithValue("@dataEmissaoRg", dpEmissaoRg.Value.ToString("yyyy-MM-dd"));
                cmdInsertMatricula.Parameters.AddWithValue("@tituloEleitor", txtTitulo.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@secao", txtSecaoTitulo.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@zona", txtZonaTitulo.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@escola", txtEscola.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@cidadeEscola", txtCidadeEscola.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@estadoEscola", cbEstadoEscola.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@anoConclusao", dpConclusaoEscola.Value.ToString("yyyy-01-01"));
                cmdInsertMatricula.Parameters.AddWithValue("@classificacao", txtClassificacao.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@pontuacao", txtPontuacao.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@curso", cbCurso.Text);
                cmdInsertMatricula.Parameters.AddWithValue("@turno", cbTurno.Text);
                //cmdInsert.Parameters.AddWithValue("@foto", imgArray == null ? (object) DBNull.Value : imgArray);

                conn.Open();
                //Armazena a ultima chave primaria inserida
                int matriculaId = Convert.ToInt32(cmdInsertMatricula.ExecuteScalar());
                //Faz os inserts de acordo com a quantidade de telefones informados
                if (txtRArray[0].Text != "")
                {
                    string insertFixo = "INSERT INTO Fixos (telefone, codMatricula) VALUES (@telefone, @codMatricula)";

                    for (int i = 0; i < countR; i++)
                    {
                        SqlCommand cmdInsertFixo = new SqlCommand(insertFixo, conn);
                        cmdInsertFixo.Parameters.AddWithValue("@telefone", txtRArray[i].Text);
                        cmdInsertFixo.Parameters.AddWithValue("@codMatricula", matriculaId);
                        cmdInsertFixo.ExecuteNonQuery();
                    }
                }

                if (txtCArray[0].Text != "")
                {
                    string insertCelular = "INSERT INTO Celulares (celular, codMatricula) VALUES (@celular, @codMatricula)";

                    for (int i = 0; i < countC; i++)
                    {
                        SqlCommand cmdInsertCel = new SqlCommand(insertCelular, conn);
                        cmdInsertCel.Parameters.AddWithValue("@celular", txtCArray[i].Text);
                        cmdInsertCel.Parameters.AddWithValue("@codMatricula", matriculaId);
                        cmdInsertCel.ExecuteNonQuery();
                    }
                }
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
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBoxAdv.Show(this, "Deseja realmente cancelar a matrícula?", "Cancelamento", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
        }

        private void btnMaisR_Click(object sender, EventArgs e)
        {
            if (countR < 3)
            {
                txtRArray[countR] = novoTextBox();
                //Nomeia o textbox de acordo com o número
                //txtRArray[countR].Name = "txtResidencial" + countR;
                //Atribui a localização do textbox baseado no primeiro
                txtRArray[countR].Location = new Point(12, 197 + 26 * countR);
                countR++;
            }            
            btnMenosR.Visible = true;
        }

        private void btnMainC_Click(object sender, EventArgs e)
        {
            if (countC < 3)
            {
                txtCArray[countC] = novoTextBox();
                //Nomeia o textbox de acordo com o número
                //txtCArray[countC].Name = "txtCelular" + countC;
                //Atribui a localização do textbox baseado no primeiro
                txtCArray[countC].Location = new Point(259, 197 + 26 * countC);
                countC++;
            }
            btnMenosC.Visible = true;
        }

        //Cria um novo TextBoxExt
        private TextBoxExt novoTextBox()
        {
            TextBoxExt txt = new TextBoxExt();
            this.tabResidencial.Controls.Add(txt);
            txt.Size = new Size(197, 20);
            return txt;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                //filtra as webcams
                FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count != 0)
                {
                    //Seleciona a primeira webcam
                    videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);

                    //Encontra a menor resolução de video disponivel que seja >= 120p de altura 
                    int videoMenor = videoDevice.VideoCapabilities[0].FrameSize.Height;
                    int videoIndice = 0;
                    for (int i = 0; i < videoDevice.VideoCapabilities.Length; i++)
                    {
                        if (videoMenor > videoDevice.VideoCapabilities[i].FrameSize.Height &&
                            videoDevice.VideoCapabilities[i].FrameSize.Height >= 120)
                        {
                            videoMenor = videoDevice.VideoCapabilities[i].FrameSize.Height;
                            videoIndice = i;
                        }
                    }

                    //Encontra a menor resolução de foto disponivel que seja >= 120p de altura
                    int snapMenor = videoDevice.SnapshotCapabilities[0].FrameSize.Height;
                    int snapIndice = 0;
                    for (int i = 0; i < videoDevice.SnapshotCapabilities.Length; i++)
                    {
                        if (snapMenor > videoDevice.SnapshotCapabilities[i].FrameSize.Height &&
                            videoDevice.SnapshotCapabilities[i].FrameSize.Height >= 120)
                        {
                            snapMenor = videoDevice.SnapshotCapabilities[i].FrameSize.Height;
                            snapIndice = i;
                        }
                    }

                    Console.Write(videoIndice);
                    Console.Write(snapIndice);
                    //define a resolução do video
                    videoDevice.VideoResolution = videoDevice.VideoCapabilities[videoIndice];
                    //define a resolução da foto
                    videoDevice.SnapshotResolution = videoDevice.SnapshotCapabilities[snapIndice];
                    //atualiza os frames no picturebox
                    videoDevice.NewFrame += (s, en) => ptFotoPes.Image = (Bitmap)en.Frame.Clone();
                    videoDevice.Start();

                    btnConectar.Enabled = false;
                    btnConectar.BackColor = Color.Silver;
                    btnCapturar.Enabled = true;
                    btnCapturar.BackColor = Color.FromArgb(0, 191, 177);
                }
                else
                {
                    MessageBoxAdv.Show(this, "Não há webcam conectada.", "Erro");
                }
            }
            catch(Exception ex)
            {
                MessageBoxAdv.Show(this, "Erro: " + ex, "Erro");
            }
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            int altura = 120, largura = 120, x = 0, y = 0;
            //tranforma a imagem em Bitmap
            Bitmap source = new Bitmap(ptFotoPes.Image);
            //x = (source.Width - largura) / 2;
            //y = (source.Height - altura) / 2;
            //Define o retangulo que será cortado da imagem
            Rectangle area = new Rectangle(new Point(x, y), new Size(largura, altura));

            Bitmap imagemCortada = CortaImagem(source, area);
            ptFotoPes.Image = imagemCortada;
            //Libera a webcam
            if(videoDevice != null)
            {
                videoDevice.SignalToStop();
                videoDevice.WaitForStop();
                videoDevice = null;
            }

            btnConectar.Enabled = true;
            btnConectar.BackColor = Color.FromArgb(0, 191, 177);
            btnCapturar.Enabled = false;
            btnCapturar.BackColor = Color.Silver;
        }

        public Bitmap CortaImagem(Bitmap source, Rectangle area)
        {
            // Bitmap vazia para a nova imagem
            Bitmap bmp = new Bitmap(area.Width, area.Height);

            Graphics g = Graphics.FromImage(bmp);
            //Desenha na area da area especificada
            // na localização 0,0 do bitmap vazio
            g.DrawImage(source, 0, 0, area, GraphicsUnit.Pixel);

            return bmp;
        }

        private void btnMenosR_Click(object sender, EventArgs e)
        {
            if(countR == 2)
            {
                btnMenosR.Visible = false;
            }
            this.tabResidencial.Controls.Remove(txtRArray[countR-1]);
            txtRArray[countR-1].Dispose();
            countR--;
        }

        private void btnMenosC_Click(object sender, EventArgs e)
        {
            if (countC == 2)
            {
                btnMenosC.Visible = false;
            }
            this.tabResidencial.Controls.Remove(txtCArray[countC - 1]);
            txtCArray[countC - 1].Dispose();
            countC--;
        }
    }
}
