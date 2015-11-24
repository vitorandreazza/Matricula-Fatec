using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Model
{
    class GraficoModel
    {
        private int[] alternativas = new int[26];

        public int[] totalAlternativas()
        {
            this.alternativas[0] = 6;
            this.alternativas[1] = 5;
            this.alternativas[2] = 5;
            this.alternativas[3] = 4;
            this.alternativas[4] = 9;
            this.alternativas[5] = 9;
            this.alternativas[6] = 4;
            this.alternativas[7] = 3;
            this.alternativas[8] = 6;
            this.alternativas[9] = 5;
            this.alternativas[10] = 5;
            this.alternativas[11] = 4;
            this.alternativas[12] = 6;
            this.alternativas[13] = 4;
            this.alternativas[14] = 4;
            this.alternativas[15] = 5;
            this.alternativas[16] = 6;
            this.alternativas[17] = 5;
            this.alternativas[18] = 5;
            this.alternativas[19] = 5;
            this.alternativas[20] = 5;
            this.alternativas[21] = 5;
            this.alternativas[22] = 5;
            this.alternativas[23] = 5;
            this.alternativas[24] = 6;
            this.alternativas[25] = 5;

            return this.alternativas;
        }

        public int tamanhoAlternativas(int questao)
        {
            totalAlternativas();
            return this.alternativas[questao - 1];
        }
    }
}
