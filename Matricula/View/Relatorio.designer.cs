#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Matricula
{
    partial class Relatorio
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
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relatorio));
            Syncfusion.Windows.Forms.CaptionImage captionImage2 = new Syncfusion.Windows.Forms.CaptionImage();
            this.matriculasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBMatriculaDataSet = new Matricula.DBMatriculaDataSet();
            this.fixosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvAluno = new Microsoft.Reporting.WinForms.ReportViewer();
            this.matriculasTableAdapter = new Matricula.DBMatriculaDataSetTableAdapters.MatriculasTableAdapter();
            this.fixosTableAdapter = new Matricula.DBMatriculaDataSetTableAdapters.FixosTableAdapter();
            this.CelularesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CelularesTableAdapter = new Matricula.DBMatriculaDataSetTableAdapters.CelularesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.matriculasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBMatriculaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CelularesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // matriculasBindingSource
            // 
            this.matriculasBindingSource.DataMember = "Matriculas";
            this.matriculasBindingSource.DataSource = this.dBMatriculaDataSet;
            // 
            // dBMatriculaDataSet
            // 
            this.dBMatriculaDataSet.DataSetName = "DBMatriculaDataSet";
            this.dBMatriculaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fixosBindingSource
            // 
            this.fixosBindingSource.DataMember = "Fixos";
            this.fixosBindingSource.DataSource = this.dBMatriculaDataSet;
            // 
            // rvAluno
            // 
            this.rvAluno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rvAluno.IsDocumentMapWidthFixed = true;
            reportDataSource1.Name = "dtsFone";
            reportDataSource1.Value = this.fixosBindingSource;
            reportDataSource2.Name = "dtsMatricula";
            reportDataSource2.Value = this.matriculasBindingSource;
            reportDataSource3.Name = "dtsCel";
            reportDataSource3.Value = this.CelularesBindingSource;
            this.rvAluno.LocalReport.DataSources.Add(reportDataSource1);
            this.rvAluno.LocalReport.DataSources.Add(reportDataSource2);
            this.rvAluno.LocalReport.DataSources.Add(reportDataSource3);
            this.rvAluno.LocalReport.ReportEmbeddedResource = "Matricula.View.DadosAluno.rdlc";
            this.rvAluno.Location = new System.Drawing.Point(-6, 1);
            this.rvAluno.Name = "rvAluno";
            this.rvAluno.PromptAreaCollapsed = true;
            this.rvAluno.ShowBackButton = false;
            this.rvAluno.ShowFindControls = false;
            this.rvAluno.ShowRefreshButton = false;
            this.rvAluno.ShowStopButton = false;
            this.rvAluno.ShowZoomControl = false;
            this.rvAluno.Size = new System.Drawing.Size(610, 363);
            this.rvAluno.TabIndex = 0;
            this.rvAluno.UseWaitCursor = true;
            // 
            // matriculasTableAdapter
            // 
            this.matriculasTableAdapter.ClearBeforeFill = true;
            // 
            // fixosTableAdapter
            // 
            this.fixosTableAdapter.ClearBeforeFill = true;
            // 
            // CelularesBindingSource
            // 
            this.CelularesBindingSource.DataMember = "Celulares";
            this.CelularesBindingSource.DataSource = this.dBMatriculaDataSet;
            // 
            // CelularesTableAdapter
            // 
            this.CelularesTableAdapter.ClearBeforeFill = true;
            // 
            // Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(177)))));
            this.CaptionBarHeight = 60;
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.White;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.CaptionForeColor = System.Drawing.Color.White;
            captionImage1.Image = ((System.Drawing.Image)(resources.GetObject("captionImage1.Image")));
            captionImage1.Location = new System.Drawing.Point(30, 9);
            captionImage1.Name = "CaptionImage1";
            captionImage1.Size = new System.Drawing.Size(45, 45);
            captionImage2.Image = ((System.Drawing.Image)(resources.GetObject("captionImage2.Image")));
            captionImage2.Location = new System.Drawing.Point(80, 20);
            captionImage2.Name = "CaptionImage2";
            captionImage2.Size = new System.Drawing.Size(74, 28);
            this.CaptionImages.Add(captionImage1);
            this.CaptionImages.Add(captionImage2);
            this.ClientSize = new System.Drawing.Size(598, 357);
            this.Controls.Add(this.rvAluno);
            this.DoubleBuffered = true;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(177)))));
            this.Name = "Relatorio";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Relatorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.matriculasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBMatriculaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CelularesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvAluno;
        private DBMatriculaDataSet dBMatriculaDataSet;
        private System.Windows.Forms.BindingSource matriculasBindingSource;
        private DBMatriculaDataSetTableAdapters.MatriculasTableAdapter matriculasTableAdapter;
        private System.Windows.Forms.BindingSource fixosBindingSource;
        private DBMatriculaDataSetTableAdapters.FixosTableAdapter fixosTableAdapter;
        private System.Windows.Forms.BindingSource CelularesBindingSource;
        private DBMatriculaDataSetTableAdapters.CelularesTableAdapter CelularesTableAdapter;




    }
}