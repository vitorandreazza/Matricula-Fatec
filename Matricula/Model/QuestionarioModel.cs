using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Model
{
    class QuestionarioModel
    {
        private char[] respostas;

        public QuestionarioModel()
        {
            respostas = new char[26];
        }

        public char[] Respostas
        {
            get { return respostas; }
            set { respostas = value; }
        }

    }
}
