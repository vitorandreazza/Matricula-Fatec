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
using System.Drawing.Text;
using Microsoft.Reporting.WinForms;
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

        private int countC = 0, countR = 0, codigo;
        private MaskedEditBox[] mtxtRArray = new MaskedEditBox[3], mtxtCArray = new MaskedEditBox[3];
        private VideoCaptureDevice videoDevice;
        private bool alterar=false, novo=false;
        private string[] cel, tel;

        public MatriculaForm()
        {
            InitializeComponent();
        }

        public MatriculaForm(bool novo)
        {
            InitializeComponent();
            this.novo = novo;
        }

        public MatriculaForm(int codigo, MatriculaModel matriculaAlterar,string[] cel, string[] tel)
        {
            InitializeComponent();

            txtNome.Text = matriculaAlterar.Nome;
            mtxtNascimento.Text = matriculaAlterar.Nascimento;
            cbSexo.SelectedIndex = cbSexo.FindString(matriculaAlterar.Sexo.ToString());
            txtNacionalidade.Text = matriculaAlterar.Nacionalidade;
            txtNaturalidade.Text = matriculaAlterar.Naturalidade;
            cbEstadoCivil.SelectedIndex = cbEstadoCivil.FindStringExact(matriculaAlterar.EstadoCivil);
            cbEstado.SelectedIndex = cbEstado.FindStringExact(matriculaAlterar.Estado);
            cbReligiao.SelectedIndex = cbReligiao.FindStringExact(matriculaAlterar.Religiao);
            cbSanguineo.SelectedIndex=cbSanguineo.FindStringExact(matriculaAlterar.TpSanguineo);
            cbRH.SelectedIndex = cbRH.FindStringExact(matriculaAlterar.Rh);
            txtNomePai.Text = matriculaAlterar.NomePai;
            txtNomeMae.Text = matriculaAlterar.NomeMae;
            txtEmail.Text = matriculaAlterar.Email;
            mtxtCep.Text = matriculaAlterar.Cep;
            txtEndereco.Text = matriculaAlterar.Endreco;
            txtNumero.Text = matriculaAlterar.Numero;
            txtComplemento.Text = matriculaAlterar.Complemento;
            txtBairro.Text = matriculaAlterar.Bairro;
            txtMunicipio.Text = matriculaAlterar.Municipio;
            mtxtCpf.Text = matriculaAlterar.Cpf;
            mtxtEmissaoCpf.Text = matriculaAlterar.EmissaoCpf;
            mtxtRg.Text = matriculaAlterar.Rg;
            mtxtEmissaoRg.Text = matriculaAlterar.EmissaoRg;
            txtTitulo.Text = matriculaAlterar.Titulo;
            txtSecaoTitulo.Text = matriculaAlterar.SecaoTitulo;
            txtZonaTitulo.Text = matriculaAlterar.ZonaTitulo;
            txtEscola.Text = matriculaAlterar.Escola;
            txtCidadeEscola.Text = matriculaAlterar.CidadeEscola;
            cbEstadoEscola.SelectedIndex = cbEstadoEscola.FindStringExact(matriculaAlterar.EstadoEscola);
            mtxtConclusaoEscola.Text = matriculaAlterar.ConclusaoEscola;
            txtClassificacao.Text = matriculaAlterar.Classificacao;
            txtPontuacao.Text = matriculaAlterar.Pontuacao;
            cbCurso.SelectedIndex = cbCurso.FindStringExact(matriculaAlterar.Curso);
            cbTurno.SelectedIndex = cbTurno.FindStringExact(matriculaAlterar.Turno);
            txtExpedidoRg.Text = matriculaAlterar.ExpedidoRG;
            txtCor.Text = matriculaAlterar.Cor;
            txtMilitar.Text = matriculaAlterar.ReservaMilitar;
            txtDataMilitar.Text = matriculaAlterar.DataMilitar;
            txtExpMilitar.Text = matriculaAlterar.ExpedidoMilitar;
            if(matriculaAlterar.Foto.Length > 0) 
            {
                MemoryStream ms = new MemoryStream(matriculaAlterar.Foto);
                Image foto1 = Image.FromStream(ms);
                ptFotoPes.Image = foto1;
           }
            this.cel = cel;
            this.tel = tel;
            this.codigo = codigo;
            alterar = true;
            foreach(string cel1 in this.cel)
            {
                Console.WriteLine(cel1+"\n");
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!(ValidaCpf.validaCpf(mtxtCpf.Text)) &&
                replaceAll(mtxtCpf.Text) != "")
                //mtxtCpf.Text.Replace("_", "").Replace(".", "").Replace("-", "").Replace(" ", "") != "")
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
                Console.WriteLine("entrou aqui");
                //Stream do array
                MemoryStream stream = new MemoryStream();
                //salva a imagem no stream
                ptFotoPes.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                //transferir o stream para o array de bytes
                imgArray = stream.ToArray();
                //Salva a imagem no diretorio
                ptFotoPes.Image.Save("c:\\fotos\\" + txtNome + ".png", System.Drawing.Imaging.ImageFormat.Png);
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
                    if(mtxtNascimento.Text != null)
                    matricula.Nascimento = formatarData(mtxtNascimento.Text);
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
                    matricula.Cep = replaceAll(mtxtCep.Text);
                    matricula.Endreco = txtEndereco.Text;
                    matricula.Numero = txtNumero.Text;
                    matricula.Complemento = txtComplemento.Text;
                    matricula.Bairro = txtBairro.Text;
                    matricula.Municipio = txtMunicipio.Text;
                    matricula.Cpf = replaceAll(mtxtCpf.Text);
                    if (mtxtEmissaoCpf.Text != null)
                    matricula.EmissaoCpf = formatarData(mtxtEmissaoCpf.Text);
                    matricula.Rg = replaceAll(mtxtRg.Text);
                    if (mtxtEmissaoRg.Text != null)
                    matricula.EmissaoRg = formatarData(mtxtEmissaoRg.Text);
                    matricula.Titulo = txtTitulo.Text;
                    matricula.SecaoTitulo = txtSecaoTitulo.Text;
                    matricula.ZonaTitulo = txtZonaTitulo.Text;
                    matricula.Escola = txtEscola.Text;
                    matricula.CidadeEscola = txtCidadeEscola.Text;
                    matricula.EstadoEscola = cbEstadoEscola.Text;
                    matricula.ConclusaoEscola = mtxtConclusaoEscola.Text;
                    matricula.Classificacao = txtClassificacao.Text;
                    matricula.Pontuacao = txtPontuacao.Text;
                    matricula.Curso = cbCurso.Text;
                    matricula.Turno = cbTurno.Text;
                    matricula.Foto = imgArray;
                    matricula.ExpedidoRG = txtExpedidoRg.Text;
                    matricula.Cor = txtCor.Text;
                    matricula.ReservaMilitar = txtMilitar.Text;
                    if (txtDataMilitar.Text != null)
                    matricula.DataMilitar = formatarData(txtDataMilitar.Text);
                    matricula.ExpedidoMilitar = txtExpMilitar.Text;    

                    if(alterar)
                    {
                        matriculaController.alterarMatricula(codigo, matricula);
                    }
                    else
                    {
                        matricula.DataMatricula = DateTime.Today.ToString("yyyy-MM-dd");
                        matriculaController.inserir(matricula);
                    }
                    
                //Faz os inserts de acordo com a quantidade de telefones informados
                if (replaceAll(mtxtRArray[0].Text) != "")
                {
                    for(int i = 0; i < countR; i++)
                    {
                        string fixo = replaceAll(mtxtRArray[i].Text);
                        telefoneController.inserirFixo(fixo, matricula.CodMatricula);
                    }
                }

                if (replaceAll(mtxtCArray[0].Text) != "")
                {
                    for (int i = 0; i < countC; i++)
                    {
                        string celular = replaceAll(mtxtCArray[i].Text);
                        telefoneController.inserirCelular(celular, matricula.CodMatricula);
                    }    
                }
                
                
                if(alterar == false && novo == false)
                {
                    int codigo = matricula.CodMatricula;
                    relatorio(codigo,null);

                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }

        }

        private void relatorio(int codigo, string cpf)
        {
            string fixo = replaceAll(mtxtRArray[0].Text);
            string celular = replaceAll(mtxtCArray[0].Text);
            this.Hide();
            RelatorioForm r = new RelatorioForm(null,codigo, false);
            r.ShowDialog();
        }

        private string formatarData(string data)
        {
            string resultado;

            if(replaceAll(data) == "")
            {
                resultado = "";
            }
            else
            {
                resultado = Convert.ToDateTime(data).ToString("yyyy-MM-dd");
            }

            return resultado;
        }

        private string replaceAll(string str)
        {
            return str.Replace(" ", "").Replace(".", "").Replace("-", "").Replace("_", "").Replace("(", "").Replace(")", "").Replace("/", "");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBoxAdv.Show(this, "Deseja realmente cancelar a matrícula?", "Cancelamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(novo || alterar)
                {
                    this.Close();
                }
                else
                {
                    Application.Exit();
                } 

            }
        }

        //Cria um novo TextBoxExt
        private MaskedEditBox novoTextBox()
        {
            MaskedEditBox txt = new MaskedEditBox();
            this.tabResidencial.Controls.Add(txt);
            txt.Size = new Size(197, 20);
            txt.PassivePromptCharacter = '_';
            txt.PromptCharacter = '_';
            txt.PositionAt = SpecialCursorPosition.FirstMaskPosition;
            return txt;
        }

        private void btnMaisR_Click(object sender, EventArgs e)
        {
            if (countR < 3)
            {
                mtxtRArray[countR] = novoTextBox();
                mtxtRArray[countR].Mask = "(##)####-####";
                //Atribui a localização do textbox baseado no primeiro
                mtxtRArray[countR].Location = new Point(12, 197 + 26 * countR);
                countR++;
            }        
    
            if(countR > 1)
            btnMenosR.Visible = true;
        }

        private void btnMainC_Click(object sender, EventArgs e)
        {
            if (countC < 3)
            {
                mtxtCArray[countC] = novoTextBox();
                mtxtCArray[countC].Mask = "(##)#####-####";
                //Atribui a localização do textbox baseado no primeiro
                mtxtCArray[countC].Location = new Point(259, 197 + 26 * countC);
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
            this.tabResidencial.Controls.Remove(mtxtRArray[countR - 1]);
            mtxtRArray[countR - 1].Dispose();
            countR--;
        }

        private void btnMenosC_Click(object sender, EventArgs e)
        {
            if (countC == 2)
            {
                btnMenosC.Visible = false;
            }
            this.tabResidencial.Controls.Remove(mtxtCArray[countC - 1]);
            mtxtCArray[countC - 1].Dispose();
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
                    videoDevice.SnapshotResolution = videoDevice.VideoCapabilities[snapIndice];
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
            //imagemCortada.Save("c:\\fotos\\" + txtNome + ".png", System.Drawing.Imaging.ImageFormat.Png);
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

        private Bitmap CortaImagem(Bitmap source, Rectangle area)
        {
            // Bitmap vazia para a nova imagem
            Bitmap bmp = new Bitmap(area.Width, area.Height);

            Graphics g = Graphics.FromImage(bmp);
            //Desenha na area da area especificada
            // na localização 0,0 do bitmap vazio
            g.DrawImage(source, 0, 0, area, GraphicsUnit.Pixel);

            return bmp;
        }

        private void MatriculaForm_Load(object sender, EventArgs e)
        {
            //Aparencia do messagebox            
            MessageBoxApparence.getMessageBoxApparence();
            //Coloca os primeiros textbox de telefone
            if(alterar)
            {
                for (int i = 0; i < tel.Count(); i++)
                    btnMaisR_Click(btnMaisR, new EventArgs());

                for (int i = 0; i < cel.Count(); i++)
                    btnMainC_Click(btnMainC, new EventArgs());

                for (int i = 0; i < tel.Count(); i++ )
                    mtxtRArray[i].Text = tel[i];
            
                for (int i = 0; i < cel.Count(); i++)
                    mtxtCArray[i].Text = cel[i];
            }
            else
            {
                btnMaisR_Click(btnMaisR, new EventArgs());
                btnMainC_Click(btnMainC, new EventArgs());
            }
        }

        private void cbCurso_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbCurso.Text.Equals("Análise e Desenvolvimento de Sistemas"))
            {
                cbTurno.Items.Clear();
                cbTurno.Items.Add("Tarde");
            }
            else if (cbCurso.Text.Equals("Eventos"))
            {
                cbTurno.Items.Clear();
                cbTurno.Items.Add("Manhã");
            }
            else if (cbCurso.Text.Equals("Gestão da Tecnologia da Informação"))
            {
                cbTurno.Items.Clear();
                cbTurno.Items.Add("Manhã");
                cbTurno.Items.Add("Noite");
            }
            else if (cbCurso.Text.Equals("Mecatrônica Industrial"))
            {
                cbTurno.Items.Clear();
                cbTurno.Items.Add("Manhã");
            }
            else if (cbCurso.Text.Equals("Gestão Empresarial(EAD)"))
            {
                cbTurno.Items.Clear();
            }
        }

        private void MatriculaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alterar == false && novo == false)
            {
                Application.Exit();
            }
            else
            {
                //Form main = Application.OpenForms["MainForm"];
                //main.
            }
        }
    }
}
