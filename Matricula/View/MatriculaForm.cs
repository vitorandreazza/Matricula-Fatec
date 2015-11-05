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
using System.IO;
//Imports bibliotecas
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using AForge.Video.DirectShow;
using AForge.Video;
//Imports projeto
using Matricula.Model;
using Matricula.View;
using Matricula.Controller;

namespace Matricula
{
    public partial class MatriculaForm : Syncfusion.Windows.Forms.MetroForm
    {
        private MatriculaController matriculaController = new MatriculaController();
        private TelefonesController telefoneController = new TelefonesController();

        private int countC = 0, countR = 0;
        private TextBox[] txtRArray = new TextBox[3], txtCArray = new TextBox[3];
        private VideoCaptureDevice videoDevice;

        public MatriculaForm()
        {
            InitializeComponent();
            //Aparencia do messagebox            
            MessageBoxApparence.getMessageBoxApparence();
            //Coloca os primeiros textbox de telefone
            btnMaisR_Click(btnMaisR, new EventArgs());
            btnMainC_Click(btnMainC, new EventArgs());
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (!(MatriculaModel.validarCpf(mtxtCpf.Text)) && mtxtCpf.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != "")
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
            
            try
            {
                MatriculaModel matricula = new MatriculaModel();

                if (cbSexo.Text == "Masculino")
                {
                    matricula.Sexo = 'M';
                }
                else if (cbSexo.Text == "Feminino")
                {
                    matricula.Sexo = 'F';
                }

                matricula.Nome = txtNome.Text;
                matricula.Nascimento = dpNascimento.Value.ToString("yyyy-MM-dd");
                matricula.Nacionalidade = txtNacionalidade.Text;
                matricula.Naturalidade = txtNaturalidade.Text;
                matricula.EstadoCivil = cbEstadoCivil.Text;
                matricula.Estado = cbEstado.Text;
                matricula.Religiao = cbReligiao.Text;
                matricula.TpSanguineo = cbSanguineo.Text;
                matricula.Rh = cbRH.Text;
                matricula.NomePai = txtNomePai.Text;
                matricula.NomeMae = txtNomeMae.Text;
                matricula.Email = txtEmail.Text;
                matricula.Cep = mtxtCep.Text.Replace("-", "");
                matricula.Endreco = txtEndereco.Text;
                matricula.Numero = txtNumero.Text;
                matricula.Complemento = txtComplemento.Text;
                matricula.Bairro = txtBairro.Text;
                matricula.Municipio = txtMunicipio.Text;
                matricula.Cpf = mtxtCpf.Text.Replace(".", "").Replace("-", "");
                matricula.EmissaoCpf = dpEmissaoCpf.Value.ToString("yyyy-MM-dd");
                matricula.Rg = mtxtRg.Text.Replace(".", "").Replace("-", "");
                matricula.EmissaoRg = dpEmissaoRg.Value.ToString("yyyy-MM-dd");
                matricula.Titulo = txtTitulo.Text;
                matricula.SecaoTitulo = txtSecaoTitulo.Text;
                matricula.ZonaTitulo = txtZonaTitulo.Text;
                matricula.Escola = txtEscola.Text;
                matricula.CidadeEscola = txtCidadeEscola.Text;
                matricula.EstadoEscola = cbEstadoEscola.Text;
                matricula.ConclusaoEscola = dpConclusaoEscola.Value.ToString("yyyy-01-01");
                matricula.Classificacao = txtClassificacao.Text;
                matricula.Pontuacao = txtPontuacao.Text;
                matricula.Curso = cbCurso.Text;
                matricula.Turno = cbTurno.Text;
                //cmdInsert.Parameters.AddWithValue("@foto", imgArray == null ? (object) DBNull.Value : imgArray);

                matriculaController.inserir(matricula);
                
                //Faz os inserts de acordo com a quantidade de telefones informados
                if (txtRArray[0].Text != "")
                {
                    for(int i = 0; i < countR; i++)
                    {
                        string fixo = txtRArray[i].Text.Replace("(", "").Replace(")", "").Replace("-", "");
                        telefoneController.inserirFixo(fixo, matricula.CodMatricula);
                    }
                }

                if (txtCArray[0].Text != "")
                {
                    for (int i = 0; i < countC; i++)
                    {
                        string celular = txtCArray[i].Text.Replace("(", "").Replace(")", "").Replace("-", "");
                        telefoneController.inserirCelular(celular, matricula.CodMatricula);
                    }    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBoxAdv.Show(this, "Deseja realmente cancelar a matrícula?", "Cancelamento", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
        }

        //Cria um novo TextBoxExt
        private TextBoxExt novoTextBox()
        {
            TextBoxExt txt = new TextBoxExt();
            this.tabResidencial.Controls.Add(txt);
            txt.Size = new Size(197, 20);
            return txt;
        }

        private void btnMaisR_Click(object sender, EventArgs e)
        {
            if (countR < 3)
            {
                txtRArray[countR] = novoTextBox();
                //Atribui a localização do textbox baseado no primeiro
                txtRArray[countR].Location = new Point(12, 197 + 26 * countR);
                countR++;
            }        
    
            if(countR > 1)
            btnMenosR.Visible = true;
        }

        private void btnMainC_Click(object sender, EventArgs e)
        {
            if (countC < 3)
            {
                txtCArray[countC] = novoTextBox();
                //Atribui a localização do textbox baseado no primeiro
                txtCArray[countC].Location = new Point(259, 197 + 26 * countC);
                countC++;
            }

            if(countC > 1)
            btnMenosC.Visible = true;
        }

        private void btnMenosR_Click(object sender, EventArgs e)
        {
            if (countR == 2)
            {
                btnMenosR.Visible = false;
            }
            this.tabResidencial.Controls.Remove(txtRArray[countR - 1]);
            txtRArray[countR - 1].Dispose();
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
    }
}
