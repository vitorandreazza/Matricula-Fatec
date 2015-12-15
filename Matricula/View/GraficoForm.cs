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
using System.Drawing.Text;
//Imports bibliotecas
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms.Chart;
//Imports projeto
using Matricula.Model;
using Matricula.View;
using Matricula.Controller;

namespace Matricula
{
    public partial class GraficoForm : Syncfusion.Windows.Forms.MetroForm
    {


        public GraficoForm()
        {

            InitializeComponent();
            MessageBoxApparence.getMessageBoxApparence();
        }



        private void btnContinuar_Click(object sender, EventArgs e)
        {
            GraficoController gc = new GraficoController();
            ChartSeries cs = new ChartSeries();
            GraficoModel gm = new GraficoModel();
            int questao,max;
            chartQuest.Series.Clear();
            chartQuest.Text = cbQuestao.Text;
            questao = cbQuestao.SelectedIndex + 1;

            max = gm.tamanhoAlternativas(questao);
            limiteAxisX(max);
            cs = gc.gerarGrafico(questao);
            cs.Type = ChartSeriesType.Column;

            chartQuest.Legend.Visible = false;
            this.chartQuest.Series.Add(cs);
            this.chartQuest.PrimaryXAxis.RangeType = Syncfusion.Windows.Forms.Chart.ChartAxisRangeType.Set;
            this.chartQuest.PrimaryXAxis.Range.Interval = 1;

            Estilo();
            chartQuest.ChartFormatAxisLabel += new ChartFormatAxisLabelEventHandler(chartQuest_ChartFormatAxisLabel);
        }

        private void GraficoForm_Load(object sender, EventArgs e)
        {
            chartQuest.Series.Clear();
            Estilo();
            cbQuestao_SelectedIndexChanged(cbQuestao,new EventArgs());
        }

        private void Estilo()
        {

            this.chartQuest.LegendPosition = ChartDock.Right;
            this.chartQuest.LegendsPlacement = ChartPlacement.Outside;
            this.chartQuest.Legend.Alignment = ChartAlignment.Center;
            this.chartQuest.ChartArea.PrimaryXAxis.HidePartialLabels = true;

            this.chartQuest.ChartInterior = new Syncfusion.Drawing.BrushInfo(Color.WhiteSmoke);
            this.chartQuest.BackInterior = new Syncfusion.Drawing.BrushInfo(Color.WhiteSmoke);
            this.chartQuest.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(Color.WhiteSmoke);

            this.chartQuest.PrimaryXAxis.GridLineType.ForeColor = Color.DarkGray;
            this.chartQuest.PrimaryYAxis.GridLineType.ForeColor = Color.DarkGray;

            this.chartQuest.PrimaryXAxis.LineType.ForeColor = Color.DarkGray;
            this.chartQuest.PrimaryYAxis.LineType.ForeColor = Color.DarkGray;

            this.chartQuest.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            this.chartQuest.Legend.BackColor = Color.White;
            this.chartQuest.Legend.Border.BackColor = Color.DarkGray;
            Color[] color1 = new Color[] { Color.FromArgb(0, 165, 150), Color.FromArgb(0, 165, 150), Color.FromArgb(0, 165, 150) };
            this.chartQuest.Series[0].Style.Interior = new BrushInfo(GradientStyle.Horizontal, color1);
            this.chartQuest.Series[0].Style.Border.Color = Color.FromArgb(112, 143, 171);


        }

        private void limiteAxisX(int max)
        {
            this.chartQuest.PrimaryXAxis.Range.Min = 0;
            this.chartQuest.PrimaryXAxis.Range.Max = max+1;
        }

        private void chartQuest_ChartFormatAxisLabel(object sender, ChartFormatAxisLabelEventArgs e)
        {
            if (cbQuestao.SelectedIndex == 0)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Menor que 18 anos";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Entre 18 a 25 anos";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Entre 26 a 30 anos";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Entre 31 a 35 anos";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Entre 36 a 40 anos";
                    }
                    else if (e.Label == "6")
                    {
                        e.Label = "Maior que 40 anos";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 1)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Católica";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Espírita";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Evangélica";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Outras";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Nenhuma";
                    }  
                }
            }
            else if (cbQuestao.SelectedIndex == 2)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Branco";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Pardo";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Negro";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Amarelo";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Indígena";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 3)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Solteiro";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Casado/mora com o companheiro";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Separado/divorciado/desquitado";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Viúvo";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 4 || cbQuestao.SelectedIndex==5)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Não estudou";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Ensino Fundamental\nincompleto";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Ensino Fundamental\ncompleto";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Ensino Médio\nincompleto";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Ensino Médio\ncompleto";
                    }
                    else if (e.Label == "6")
                    {
                        e.Label = "Ensino Superior\nincompleto";
                    }
                    else if (e.Label == "7")
                    {
                        e.Label = "Ensino Superior\ncompleto";
                    }
                    else if (e.Label == "8")
                    {
                        e.Label = "Pós-graduação";
                    }
                    else if (e.Label == "9")
                    {
                        e.Label = "Não sei";
                    }
                    else if (e.Label == "10")
                    {
                        e.Label = "";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 6)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Nenhum";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Um idioma";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Dois idiomas";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Três idiomas ou mais";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 7)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Ensino Médio - completo";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Ensino Superior - incompleto";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Ensino Superior - completo";
                    }         
                }
            }
            else if (cbQuestao.SelectedIndex == 8)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Somente em\nescola pública";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Maior parte dos anos\nem escola pública";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Somente em\nescola particular";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Maior parte dos anos\nem escola particular";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Somente em\nescola conveniada";
                    }
                    else if (e.Label == "6")
                    {
                        e.Label = "Maior parte dos anos\nem escola conveniada";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 9)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Não";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Sim, menos de um semestre";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Sim, um semestre";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Sim, por um ano";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Sim, por mais de um ano";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 10)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Nenhuma";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Uma vez";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Duas vezes";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Três vezes";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Mais de três vezes";
                    }  
                }
            }
            else if (cbQuestao.SelectedIndex == 11)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Não";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Sim, mas abandonei";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Sim, estou cursando";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Sim, mas já conclui";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 12)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Estudante";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Desempregado";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Contrato com carteira\nde trabalho assinada";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Servidor público";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Trabalhador autônomo";
                    }
                    else if (e.Label == "6")
                    {
                        e.Label = "Aposentado";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 13)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Não";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Sim, em tempo parcial\n(mais de 30 horas semanais)";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Sim, em tempo integral\n(Mais de 30 horas semanais)";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Sim, trabalho eventualmente";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 14)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Não";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Sim, apenas em estágios";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Sim, desde o 1ºano em tempo parcial";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Sim, desde o 1ºano em tempo integral";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 20)//21
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Saúde";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Educação";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Indústrias";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Comércio";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Outros";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 15)//16
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Não tenho";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Menos de 1 salário mínimo";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "De 1 a 3 salários mínimos";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "De 3 a 6 salários mínimos";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "De 6 a 10 salários mínimos";
                    }
                    else if (e.Label == "6")
                    {
                        e.Label = "mais de 10 salários mínimos";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 16)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Financiado pela família\nou por outras pessoas";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Trabalha, mas recebe ajuda\nfinanceirada família\nou de outras pessoas";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Trabalha, e é responsável pelo\nseu próprio sustento,\nnão recebendo ajuda financeira";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Trabalha, e é o responsável pelo seu\npróprio sustento, e contribui\nparcialmente para o\nsustento de outras pessoas";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Trabalha, e é o responsável\npelo sustento da família";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 17)//18
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "1 ou 2 pessoas";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "3 ou 4 pessoas";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "5 ou 6 pessoas";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "De 6 a 10 pessoas";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Mais de 10 pessoas";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 18)//19
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Menos de 1 salário mínimo";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "De 1 a 3 salários mínimos";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "De 3 a 6 salários mínimos";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "De 6 a 10 salários mínimos";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "mais de 10 salários mínimos";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 19)//20
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Qualificação profissional";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Exigência do serviço";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Melhoria salarial";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Preparação para o vestibular";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Ser faculdade pública";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 21)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Própria";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Cedida";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Financiada";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Alugada";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Outras";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 22)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Religiosa";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Artística e cultural(cinema,show)";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Política partidária";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Esportiva";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Outros";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 23)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Jornal escrito/revista";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Televisão";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Rádio";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Internet";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Outros";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 24)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Ônibus urbano";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Ônibus interurbano";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Bicicleta/à pé";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Carro próprio";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Moto própria";
                    }
                    else if (e.Label == "6")
                    {
                        e.Label = "Van";
                    }
                }
            }
            else if (cbQuestao.SelectedIndex == 25)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Jornais/Internet";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Material gráfico(cartazes/panfletos)";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Televisão/rádio";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Escola de ensino médio/cursinho";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Amigos, vizinhos ou parentes";
                    }
                }
            }
            e.Handled = true;
        }

      

        private void cbQuestao_SelectedIndexChanged(object sender, EventArgs e)
        {
            GraficoController gc = new GraficoController();
            ChartSeries cs = new ChartSeries();
            GraficoModel gm = new GraficoModel();
            int questao, max;
            chartQuest.Series.Clear();
            chartQuest.Text = cbQuestao.Text;
            questao = cbQuestao.SelectedIndex + 1;

            max = gm.tamanhoAlternativas(questao);
            limiteAxisX(max);
            cs = gc.gerarGrafico(questao);
            cs.Type = ChartSeriesType.Column;

            chartQuest.Legend.Visible = false;
            this.chartQuest.Series.Add(cs);
            this.chartQuest.PrimaryXAxis.RangeType = Syncfusion.Windows.Forms.Chart.ChartAxisRangeType.Set;
            this.chartQuest.PrimaryXAxis.Range.Interval = 1;

            Estilo();
            chartQuest.ChartFormatAxisLabel += new ChartFormatAxisLabelEventHandler(chartQuest_ChartFormatAxisLabel);
        }
    }
}


