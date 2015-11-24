#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Matricula
{
    partial class RelatorioForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioForm));
            Syncfusion.Windows.Forms.CaptionImage captionImage2 = new Syncfusion.Windows.Forms.CaptionImage();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPessoal = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.rvFicha = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabDados = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.rvDados = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnContinuar = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPessoal.SuspendLayout();
            this.tabDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.ActiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.tabControlAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(684, 379);
            this.tabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabControlAdv1.Controls.Add(this.tabPessoal);
            this.tabControlAdv1.Controls.Add(this.tabDados);
            this.tabControlAdv1.FocusOnTabClick = false;
            this.tabControlAdv1.InactiveTabColor = System.Drawing.Color.WhiteSmoke;
            this.tabControlAdv1.Location = new System.Drawing.Point(-1, 3);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.Size = new System.Drawing.Size(684, 379);
            this.tabControlAdv1.TabIndex = 0;
            this.tabControlAdv1.TabPanelBackColor = System.Drawing.Color.WhiteSmoke;
            this.tabControlAdv1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererMetro);
            // 
            // tabPessoal
            // 
            this.tabPessoal.Controls.Add(this.rvFicha);
            this.tabPessoal.Image = null;
            this.tabPessoal.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPessoal.Location = new System.Drawing.Point(0, 21);
            this.tabPessoal.Name = "tabPessoal";
            this.tabPessoal.ShowCloseButton = true;
            this.tabPessoal.Size = new System.Drawing.Size(684, 358);
            this.tabPessoal.TabForeColor = System.Drawing.Color.Gray;
            this.tabPessoal.TabIndex = 1;
            this.tabPessoal.Text = "Ficha de Matrícula";
            this.tabPessoal.ThemesEnabled = false;
            // 
            // rvFicha
            // 
            this.rvFicha.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dtsMatricula";
            reportDataSource1.Value = null;
            reportDataSource2.Name = "dtsFone";
            reportDataSource2.Value = null;
            this.rvFicha.LocalReport.DataSources.Add(reportDataSource1);
            this.rvFicha.LocalReport.DataSources.Add(reportDataSource2);
            this.rvFicha.LocalReport.ReportEmbeddedResource = "Matricula.View.FichaMatricula.rdlc";
            this.rvFicha.Location = new System.Drawing.Point(0, 0);
            this.rvFicha.Name = "rvFicha";
            this.rvFicha.ShowBackButton = false;
            this.rvFicha.ShowContextMenu = false;
            this.rvFicha.ShowCredentialPrompts = false;
            this.rvFicha.ShowDocumentMapButton = false;
            this.rvFicha.ShowFindControls = false;
            this.rvFicha.ShowPageNavigationControls = false;
            this.rvFicha.ShowRefreshButton = false;
            this.rvFicha.ShowStopButton = false;
            this.rvFicha.Size = new System.Drawing.Size(684, 358);
            this.rvFicha.TabIndex = 0;
            // 
            // tabDados
            // 
            this.tabDados.Controls.Add(this.rvDados);
            this.tabDados.Image = null;
            this.tabDados.ImageSize = new System.Drawing.Size(16, 16);
            this.tabDados.Location = new System.Drawing.Point(0, 21);
            this.tabDados.Name = "tabDados";
            this.tabDados.ShowCloseButton = true;
            this.tabDados.Size = new System.Drawing.Size(684, 358);
            this.tabDados.TabForeColor = System.Drawing.Color.DimGray;
            this.tabDados.TabIndex = 3;
            this.tabDados.Text = "Dados Pessoais";
            this.tabDados.ThemesEnabled = false;
            // 
            // rvDados
            // 
            this.rvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "dtsFone";
            reportDataSource3.Value = null;
            reportDataSource4.Name = "dtsMatricula";
            reportDataSource4.Value = null;
            reportDataSource5.Name = "dtsCel";
            reportDataSource5.Value = null;
            this.rvDados.LocalReport.DataSources.Add(reportDataSource3);
            this.rvDados.LocalReport.DataSources.Add(reportDataSource4);
            this.rvDados.LocalReport.DataSources.Add(reportDataSource5);
            this.rvDados.LocalReport.ReportEmbeddedResource = "Matricula.View.DadosAluno.rdlc";
            this.rvDados.Location = new System.Drawing.Point(0, 0);
            this.rvDados.Name = "rvDados";
            this.rvDados.ShowBackButton = false;
            this.rvDados.ShowContextMenu = false;
            this.rvDados.ShowCredentialPrompts = false;
            this.rvDados.ShowDocumentMapButton = false;
            this.rvDados.ShowFindControls = false;
            this.rvDados.ShowPageNavigationControls = false;
            this.rvDados.ShowProgress = false;
            this.rvDados.ShowRefreshButton = false;
            this.rvDados.ShowStopButton = false;
            this.rvDados.Size = new System.Drawing.Size(684, 358);
            this.rvDados.TabIndex = 0;
            // 
            // btnContinuar
            // 
            this.btnContinuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinuar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnContinuar.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnContinuar.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None;
            this.btnContinuar.ComboEditBackColor = System.Drawing.Color.Transparent;
            this.btnContinuar.CustomManagedColor = System.Drawing.Color.Transparent;
            this.btnContinuar.FlatAppearance.BorderSize = 0;
            this.btnContinuar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnContinuar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(150)))));
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.ForeColor = System.Drawing.Color.White;
            this.btnContinuar.IsBackStageButton = false;
            this.btnContinuar.Location = new System.Drawing.Point(600, 388);
            this.btnContinuar.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(177)))));
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 23);
            this.btnContinuar.TabIndex = 0;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyle = false;
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // RelatorioForm
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
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.tabControlAdv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RelatorioForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RelatorioForm_FormClosing);
            this.Load += new System.EventHandler(this.RelatorioForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPessoal.ResumeLayout(false);
            this.tabDados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPessoal;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabDados;
        private Syncfusion.Windows.Forms.ButtonAdv btnContinuar;
        private Microsoft.Reporting.WinForms.ReportViewer rvFicha;
        private Microsoft.Reporting.WinForms.ReportViewer rvDados;


    }
}