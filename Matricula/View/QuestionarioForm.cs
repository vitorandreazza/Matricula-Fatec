#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Matricula.View
{
    public partial class QuestionarioForm : Syncfusion.Windows.Forms.MetroForm
    {
        public QuestionarioForm()
        {
            InitializeComponent();
        }

        private void autoLabel1_Click(object sender, EventArgs e)
        {

        }

        private void QuestionarioForm_Load(object sender, EventArgs e)
        {
            Color verdeClaro = Color.FromArgb(0, 192, 177);
            Color verdeEscuro = Color.FromArgb(0, 163, 150);
            MetroColorTable colorTable = new MetroColorTable();
            
            colorTable.ArrowChecked = verdeEscuro;
            colorTable.ArrowNormal = verdeClaro;
            //colorTable.ArrowNormalBackGround = Color.WhiteSmoke;
            colorTable.ArrowPushed = verdeClaro;
            //colorTable.ArrowPushedBackGround = verdeClaro;
            colorTable.ScrollerBackground = Color.WhiteSmoke;
            colorTable.ThumbChecked = verdeEscuro;
            colorTable.ThumbNormal = verdeClaro;
            colorTable.ThumbPushed = verdeEscuro;
            colorTable.ThumbPushedBorder = verdeClaro;
            
            sfPrincipal.ScrollMetroColorTable = colorTable;
        }

        private void pnPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
