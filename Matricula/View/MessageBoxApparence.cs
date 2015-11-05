using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.View
{
    abstract class MessageBoxApparence
    {
        public static void getMessageBoxApparence()
        {
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
    }
}
