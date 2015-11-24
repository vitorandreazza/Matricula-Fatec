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
            this.cbQuestao.SelectedIndex = -1;
            Estilo();
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
            Color[] color1 = new Color[] { Color.FromArgb(0, 192, 177), Color.FromArgb(0, 192, 177), Color.FromArgb(0, 192, 177) };
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
            else if (cbQuestao.SelectedIndex == 8)
            {
                if (e.AxisOrientation == ChartOrientation.Horizontal)
                {
                    if (e.Label == "1")
                    {
                        e.Label = "Não estudou";
                    }
                    else if (e.Label == "2")
                    {
                        e.Label = "Ensino Fundamental\n- incompleto";
                    }
                    else if (e.Label == "3")
                    {
                        e.Label = "Ensino Fundamental\n - completo";
                    }
                    else if (e.Label == "4")
                    {
                        e.Label = "Ensino Médio\n- incompleto";
                    }
                    else if (e.Label == "5")
                    {
                        e.Label = "Ensino Médio\n - completo";
                    }
                    else if (e.Label == "6")
                    {
                        e.Label = "Ensino Superior\n- incompleto";
                    }
                }
            }
            e.Handled = true;
        }
    }
}


