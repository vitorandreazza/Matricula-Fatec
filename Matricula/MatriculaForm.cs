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
        private TextBox[] txtRArray = new TextBox[2], txtCArray = new TextBox[2];
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
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (!(ValidaCpf.validaCpf(mtxtCpf.Text)))
            {
                MessageBoxAdv.Show(this, "O CPF é inválido", "Erro");
                return;
            }

            if (MessageBoxAdv.Show(this, "Deseja realmente confirmar a matrícula?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            //Stream do array
            MemoryStream stream = new MemoryStream();
            //salva a imagem no stream
            ptFotoPes.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            //transferir o stream para o array de bytes
            byte[] imgArray = stream.ToArray();

            string strConn = Matricula.Properties.Settings.Default.ConnMatricula;
            SqlConnection conn = new SqlConnection(strConn);

            string insertAluno = "INSERT INTO Matriculas" +
            "(nome, dtNasc, sexo, nacionalidade, naturalidade, estadoCivil, estado, religiao," +
            "tipoSanguineo, rh, nomePai, nomeMae, email, cep, endereco, numero, complemento," +
            "bairro, municipio, cpf, dataEmissaoCpf, rg, dataEmissaoRg, tituloEleitor, secao, zona, escola," +
            "cidadeEscola, estadoEscola, anoConclusao, classificacao, pontuacao, curso, turno, foto)" +
            "VALUES" +
            "(@nome, @dtNasc, @sexo, @nacionalidade, @naturalidade, @estadoCivil, @estado, @religiao," +
            "@tipoSanguineo, @rh, @nomePai, @nomeMae, @email, @cep, @endereco, @numero, @complemento," +
            "@bairro, @municipio, @cpf, @dataEmissaoCpf, @rg, @dataEmissaoRg, @tituloEleitor, @secao, @zona, @escola," +
            "@cidadeEscola, @estadoEscola, @anoConclusao, @classificacao, @pontuacao, @curso, @turno, @foto)";

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
                SqlCommand cmdInsert = new SqlCommand(insertAluno, conn);

                cmdInsert.Parameters.AddWithValue("@nome", txtNome.Text);
                cmdInsert.Parameters.AddWithValue("@dtNasc", dpNascimento.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@sexo", sexo);
                cmdInsert.Parameters.AddWithValue("@nacionalidade", txtNacionalidade.Text);
                cmdInsert.Parameters.AddWithValue("@naturalidade", txtNaturalidade.Text);
                cmdInsert.Parameters.AddWithValue("@estadoCivil", cbEstadoCivil.Text);
                cmdInsert.Parameters.AddWithValue("@estado", cbEstado.Text);
                cmdInsert.Parameters.AddWithValue("@religiao", cbReligiao.Text);
                cmdInsert.Parameters.AddWithValue("@tipoSanguineo", cbSanguineo.Text);
                cmdInsert.Parameters.AddWithValue("@rh", cbRH.Text);
                cmdInsert.Parameters.AddWithValue("@nomePai", txtNomePai.Text);
                cmdInsert.Parameters.AddWithValue("@nomeMae", txtNomeMae.Text);
                cmdInsert.Parameters.AddWithValue("@email", txtEmail.Text);
                cmdInsert.Parameters.AddWithValue("@cep", mtxtCep.Text.Replace("-", ""));
                cmdInsert.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmdInsert.Parameters.AddWithValue("@numero", txtNumero.Text);
                cmdInsert.Parameters.AddWithValue("@complemento", txtComplemento.Text);
                cmdInsert.Parameters.AddWithValue("@bairro", txtBairro.Text);
                cmdInsert.Parameters.AddWithValue("@municipio", txtMunicipio.Text);
                cmdInsert.Parameters.AddWithValue("@cpf", mtxtCpf.Text.Replace(".", "").Replace("-", ""));
                cmdInsert.Parameters.AddWithValue("@dataEmissaoCpf", dpEmissaoCpf.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@rg", mtxtRg.Text.Replace(".", "").Replace("-", ""));
                cmdInsert.Parameters.AddWithValue("@dataEmissaoRg", dpEmissaoRg.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@tituloEleitor", txtTitulo.Text);
                cmdInsert.Parameters.AddWithValue("@secao", txtSecaoTitulo.Text);
                cmdInsert.Parameters.AddWithValue("@zona", txtZonaTitulo.Text);
                cmdInsert.Parameters.AddWithValue("@escola", txtEscola.Text);
                cmdInsert.Parameters.AddWithValue("@cidadeEscola", txtCidadeEscola.Text);
                cmdInsert.Parameters.AddWithValue("@estadoEscola", cbEstadoEscola.Text);
                cmdInsert.Parameters.AddWithValue("@anoConclusao", dpConclusaoEscola.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@classificacao", txtClassificacao.Text);
                cmdInsert.Parameters.AddWithValue("@pontuacao", txtPontuacao.Text);
                cmdInsert.Parameters.AddWithValue("@curso", cbCurso.Text);
                cmdInsert.Parameters.AddWithValue("@turno", cbTurno.Text);
                cmdInsert.Parameters.AddWithValue("@foto", imgArray);

                conn.Open();
                cmdInsert.ExecuteNonQuery();
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
            if (countR < 2)
            {
                txtRArray[countR] = novoTextBox();
                //Nomeia o textbox de acordo com o número
                txtRArray[countR].Name = "txtResidencial" + (countR+1);
                //Atribui a localização do textbox baseado no primeiro
                txtRArray[countR].Location = new Point(txtResidencial.Location.X, txtResidencial.Location.Y + 26 * (countR+1));
                countR++;
            }            
            btnMenosR.Visible = true;
        }

        private void btnMainC_Click(object sender, EventArgs e)
        {
            if (countC < 2)
            {
                txtCArray[countC] = novoTextBox();
                //Nomeia o textbox de acordo com o número
                txtCArray[countC].Name = "txtCelular" + (countC+1);
                //Atribui a localização do textbox baseado no primeiro
                txtCArray[countC].Location = new Point(txtCelular.Location.X, txtCelular.Location.Y + 26 * (countC+1));
                countC++;
            }
            btnMenosC.Visible = true;
        }

        //Cria um novo TextBoxExt
        private TextBoxExt novoTextBox()
        {
            TextBoxExt txt = new TextBoxExt();
            this.tabResidencial.Controls.Add(txt);
            txt.Size = new Size(txtResidencial.Size.Width, txtResidencial.Size.Height);
            return txt;
        }

        private void btnConectar_Click(object sender, EventArgs e)
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
                int snapMenor = videoDevice.VideoCapabilities[0].FrameSize.Height;
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
            if(countR == 1)
            {
                btnMenosR.Visible = false;
            }
            this.tabResidencial.Controls.Remove(txtRArray[countR-1]);
            txtRArray[countR-1].Dispose();
            countR--;
        }

        private void btnMenosC_Click(object sender, EventArgs e)
        {
            if (countC == 1)
            {
                btnMenosC.Visible = false;
            }
            this.tabResidencial.Controls.Remove(txtCArray[countC - 1]);
            txtCArray[countC - 1].Dispose();
            countC--;
        }
    }
}
