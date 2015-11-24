#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Matricula
{
    partial class GraficoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Syncfusion.Windows.Forms.Chart.ChartSeries chartSeries1 = new Syncfusion.Windows.Forms.Chart.ChartSeries();
            Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo chartCustomShapeInfo1 = new Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo();
            Syncfusion.Windows.Forms.Chart.ChartLineInfo chartLineInfo1 = new Syncfusion.Windows.Forms.Chart.ChartLineInfo();
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraficoForm));
            Syncfusion.Windows.Forms.CaptionImage captionImage2 = new Syncfusion.Windows.Forms.CaptionImage();
            this.btnExibir = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cbQuestao = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.lblQuest = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.chartQuest = new Syncfusion.Windows.Forms.Chart.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.cbQuestao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExibir
            // 
            this.btnExibir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExibir.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnExibir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnExibir.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnExibir.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None;
            this.btnExibir.ComboEditBackColor = System.Drawing.Color.Transparent;
            this.btnExibir.CustomManagedColor = System.Drawing.Color.Transparent;
            this.btnExibir.FlatAppearance.BorderSize = 0;
            this.btnExibir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnExibir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(150)))));
            this.btnExibir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExibir.ForeColor = System.Drawing.Color.White;
            this.btnExibir.IsBackStageButton = false;
            this.btnExibir.Location = new System.Drawing.Point(595, 34);
            this.btnExibir.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(75, 23);
            this.btnExibir.TabIndex = 0;
            this.btnExibir.Text = "Exibir";
            this.btnExibir.UseVisualStyle = false;
            this.btnExibir.UseVisualStyleBackColor = false;
            this.btnExibir.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // cbQuestao
            // 
            this.cbQuestao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbQuestao.BackColor = System.Drawing.Color.White;
            this.cbQuestao.BeforeTouchSize = new System.Drawing.Size(554, 21);
            this.cbQuestao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuestao.FlatBorderColor = System.Drawing.SystemColors.ControlDark;
            this.cbQuestao.FlatStyle = Syncfusion.Windows.Forms.Tools.ComboFlatStyle.Flat;
            this.cbQuestao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQuestao.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbQuestao.Items.AddRange(new object[] {
            "1 - Qual a sua idade?",
            "2 - Qual a sua religião?",
            "3 - Como você se considera?(Cor)",
            "4 - Qual o seu estado civil?",
            "5 - Qual a escolaridade do seu pai?",
            "6 - Qual a escolaridade da sua mãe?",
            "7 - Quantos idiomas além do Português você domina?",
            "8 - Qual a sua escolaridade?",
            "9 - Em que tipo de escola você estudou?",
            "10 - Você frequentou cursinho preparatório para ingressar na FATEC Itu?",
            "11 - Quantas vezes você prestou o processo de acesso para o vestibular na FATEC I" +
                "tu?",
            "12 - Você já iniciou algum curso superior?",
            "13 - Qual a sua ocupação?",
            "14 - Você exerce atividade remunerada?",
            "15 - Você pretende trabalhar enquanto faz o curso?",
            "16 - Qual é o seu ramo de atividade?",
            "17 - Qual a sua renda mensal?",
            "18 - Qual a sua participação na vida econômica da sua família?",
            "19 - Quantas pessoas compõem sua família?",
            "20 - Qual é a renda mensal de sua família (todos que residem na casa)?",
            "21 - Qual motivo o levou a escolher um curso da FATEC Itu?",
            "22 - Qual é o tipo de sua moradia?",
            "23 - Qual é o tipo de atividade da qual você mais participa?",
            "24 - Qual é o meio de comunicação que você mais utiliza para se manter informado?" +
                "",
            "25 - Qual o meio de transporte utilizado para ir à FATEC Itu?",
            "26 - Como você tomou conhecimento do processo seletivo da FATEC Itu?"});
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "1 - Qual a sua idade?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "2 - Qual a sua religião?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "3 - Como você se considera?(Cor)"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "4 - Qual o seu estado civil?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "5 - Qual a escolaridade do seu pai?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "6 - Qual a escolaridade da sua mãe?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "7 - Quantos idiomas além do Português você domina?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "8 - Qual a sua escolaridade?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "9 - Em que tipo de escola você estudou?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "10 - Você frequentou cursinho preparatório para ingressar na FATEC Itu?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "11 - Quantas vezes você prestou o processo de acesso para o vestibular na FATEC I" +
            "tu?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "12 - Você já iniciou algum curso superior?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "13 - Qual a sua ocupação?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "14 - Você exerce atividade remunerada?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "15 - Você pretende trabalhar enquanto faz o curso?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "16 - Qual é o seu ramo de atividade?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "17 - Qual a sua renda mensal?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "18 - Qual a sua participação na vida econômica da sua família?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "19 - Quantas pessoas compõem sua família?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "20 - Qual é a renda mensal de sua família (todos que residem na casa)?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "21 - Qual motivo o levou a escolher um curso da FATEC Itu?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "22 - Qual é o tipo de sua moradia?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "23 - Qual é o tipo de atividade da qual você mais participa?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "24 - Qual é o meio de comunicação que você mais utiliza para se manter informado?" +
            ""));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "25 - Qual o meio de transporte utilizado para ir à FATEC Itu?"));
            this.cbQuestao.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbQuestao, "26 - Como você tomou conhecimento do processo seletivo da FATEC Itu?"));
            this.cbQuestao.Location = new System.Drawing.Point(23, 36);
            this.cbQuestao.MetroBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.cbQuestao.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(150)))));
            this.cbQuestao.Name = "cbQuestao";
            this.cbQuestao.Size = new System.Drawing.Size(554, 21);
            this.cbQuestao.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.cbQuestao.TabIndex = 12;
            this.cbQuestao.Text = "1 - Qual a sua idade?";
            // 
            // lblQuest
            // 
            this.lblQuest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuest.ForeColor = System.Drawing.Color.DimGray;
            this.lblQuest.Location = new System.Drawing.Point(23, 18);
            this.lblQuest.Name = "lblQuest";
            this.lblQuest.Size = new System.Drawing.Size(60, 15);
            this.lblQuest.TabIndex = 13;
            this.lblQuest.Text = "Questão";
            // 
            // chartQuest
            // 
            this.chartQuest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartQuest.BackInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.WhiteSmoke);
            this.chartQuest.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent);
            this.chartQuest.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartQuest.ChartArea.CursorReDraw = false;
            this.chartQuest.DataSourceName = "[none]";
            this.chartQuest.IsWindowLess = false;
            // 
            // 
            // 
            this.chartQuest.Legend.Location = new System.Drawing.Point(570, 31);
            this.chartQuest.Localize = null;
            this.chartQuest.Location = new System.Drawing.Point(23, 63);
            this.chartQuest.Name = "chartQuest";
            this.chartQuest.PrimaryXAxis.Crossing = double.NaN;
            this.chartQuest.PrimaryXAxis.Margin = true;
            this.chartQuest.PrimaryYAxis.Crossing = double.NaN;
            this.chartQuest.PrimaryYAxis.Margin = true;
            chartSeries1.FancyToolTip.ResizeInsideSymbol = true;
            chartSeries1.Points.Add(1D, ((double)(241D)), ((double)(131D)), ((double)(56D)), ((double)(12D)));
            chartSeries1.Points.Add(2D, ((double)(167D)), ((double)(76D)), ((double)(46D)), ((double)(16D)));
            chartSeries1.Points.Add(3D, ((double)(203D)), ((double)(58D)), ((double)(58D)), ((double)(55D)));
            chartSeries1.Points.Add(4D, ((double)(286D)), ((double)(284D)), ((double)(130D)), ((double)(71D)));
            chartSeries1.Points.Add(5D, ((double)(118D)), ((double)(99D)), ((double)(81D)), ((double)(63D)));
            chartSeries1.Resolution = 0D;
            chartSeries1.StackingGroup = "Default Group";
            chartSeries1.Style.AltTagFormat = "";
            chartSeries1.Style.DrawTextShape = false;
            chartLineInfo1.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            chartLineInfo1.Color = System.Drawing.SystemColors.ControlText;
            chartLineInfo1.DashPattern = null;
            chartLineInfo1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartLineInfo1.Width = 1F;
            chartCustomShapeInfo1.Border = chartLineInfo1;
            chartCustomShapeInfo1.Color = System.Drawing.SystemColors.HighlightText;
            chartCustomShapeInfo1.Type = Syncfusion.Windows.Forms.Chart.ChartCustomShape.Square;
            chartSeries1.Style.TextShape = chartCustomShapeInfo1;
            this.chartQuest.Series.Add(chartSeries1);
            this.chartQuest.Size = new System.Drawing.Size(630, 327);
            this.chartQuest.TabIndex = 14;
            // 
            // 
            // 
            this.chartQuest.Title.Name = "Default";
            this.chartQuest.ChartFormatAxisLabel += new Syncfusion.Windows.Forms.Chart.ChartFormatAxisLabelEventHandler(this.chartQuest_ChartFormatAxisLabel);
            // 
            // GraficoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.BorderThickness = 2;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(177)))));
            this.CaptionBarHeight = 60;
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.CaptionForeColor = System.Drawing.Color.White;
            captionImage1.Image = ((System.Drawing.Image)(resources.GetObject("captionImage1.Image")));
            captionImage1.Location = new System.Drawing.Point(30, 9);
            captionImage1.Name = "CaptionImage3";
            captionImage1.Size = new System.Drawing.Size(45, 45);
            captionImage2.Image = ((System.Drawing.Image)(resources.GetObject("captionImage2.Image")));
            captionImage2.Location = new System.Drawing.Point(80, 20);
            captionImage2.Name = "CaptionImage1";
            captionImage2.Size = new System.Drawing.Size(217, 28);
            this.CaptionImages.Add(captionImage1);
            this.CaptionImages.Add(captionImage2);
            this.ClientSize = new System.Drawing.Size(682, 413);
            this.Controls.Add(this.chartQuest);
            this.Controls.Add(this.cbQuestao);
            this.Controls.Add(this.lblQuest);
            this.Controls.Add(this.btnExibir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GraficoForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GraficoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbQuestao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnExibir;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cbQuestao;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblQuest;
        private Syncfusion.Windows.Forms.Chart.ChartControl chartQuest;


    }
}