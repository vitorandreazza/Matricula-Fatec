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
//IMPORT BIBLIOTECA
using Syncfusion.Windows.Forms.Tools;
//IMPORT PROJETO
using Matricula.Model;
using Matricula.Controller;

namespace Matricula.View
{
    public partial class QuestionarioForm : Syncfusion.Windows.Forms.MetroForm
    {

        public QuestionarioForm()
        {
            InitializeComponent();
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
            
            sfTab1.ScrollMetroColorTable = colorTable;
            sfTab2.ScrollMetroColorTable = colorTable;

            btnEnviar.ForeColor = Color.White;

            MessageBoxApparence.getMessageBoxApparence();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                QuestionarioModel qtModel = new QuestionarioModel();
                QuestionarioController qtController = new QuestionarioController();

                var panels1 = GetAll(tab1, typeof(Panel));

                foreach(Panel pn in panels1)
                {
                    int tamPn = pn.Name.Length;
                    int numPn = Convert.ToInt32(pn.Name[tamPn - 2].ToString() + pn.Name[tamPn - 1].ToString());
                    //Identifica o checked rb do painel
                    var checkedButton = pn.Controls.OfType<RadioButtonAdv>().FirstOrDefault(r => r.Checked);
                    
                    if (checkedButton == null)
                    {
                        MessageBoxAdv.Show(this, "Responda todas as perguntas!", "Erro");
                        return;
                    }
                    //Adiciona de acordo com o numero do painel
                    //o ultimo número do nome do rb checado
                    qtModel.Respostas[numPn-1] = checkedButton.Name[checkedButton.Name.Length - 1];
                   
                }

                var panels2 = GetAll(tab2, typeof(Panel));

                foreach (Panel pn in panels2)
                {
                    int tamPn = pn.Name.Length;
                    int numPn = Convert.ToInt32(pn.Name[tamPn - 2].ToString() + pn.Name[tamPn - 1].ToString());

                    var checkedButton = pn.Controls.OfType<RadioButtonAdv>().FirstOrDefault(r => r.Checked);
                    
                    if (checkedButton == null)
                    {
                        MessageBoxAdv.Show(this, "Responda todas as perguntas!", "Erro");
                        return;
                    }
                    
                    qtModel.Respostas[numPn-1] = checkedButton.Name[checkedButton.Name.Length - 1];
                }
                string dissertativa = txtQuest27.Text;
                qtController.inserir(qtModel,dissertativa);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }

            MessageBoxAdv.Show(this, "Matrícula efetuada, obrigado!", "Matrícula", MessageBoxButtons.OK);
            Application.Exit();
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        private void QuestionarioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
