using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Model
{
    class MatriculaModel
    {
        private string nome, nascimento, nascionalidade, naturalidade, estadoCivil, estado, religiao, tpSanguineo, rh,
                       nomePai, nomeMae, email, cep, endreco, numero, complemento, bairro, municipio, cpf, emissaoCpf, rg, emissaoRg,
                       titulo, secaoTitulo, zonaTitulo, escola, cidadeEscola, estadoEscola, conclusaoEscola, classificacao, pontuacao,
                       curso, turno;

        private int codMatricula;
        private char sexo;

        public int CodMatricula
        {
            get { return codMatricula; }
            set { codMatricula = value; }
        }

        public static bool validarCpf(string cpf)
        {
            return ValidaCpf.validaCpf(cpf);
        }

        public string Turno
        {
            get { return turno; }
            set { turno = value; }
        }

        public string Curso
        {
            get { return curso; }
            set { curso = value; }
        }

        public string Pontuacao
        {
            get { return pontuacao; }
            set { pontuacao = value; }
        }

        public string Classificacao
        {
            get { return classificacao; }
            set { classificacao = value; }
        }

        public string ConclusaoEscola
        {
            get { return conclusaoEscola; }
            set { conclusaoEscola = value; }
        }

        public string EstadoEscola
        {
            get { return estadoEscola; }
            set { estadoEscola = value; }
        }

        public string CidadeEscola
        {
            get { return cidadeEscola; }
            set { cidadeEscola = value; }
        }

        public string Escola
        {
            get { return escola; }
            set { escola = value; }
        }

        public string ZonaTitulo
        {
            get { return zonaTitulo; }
            set { zonaTitulo = value; }
        }

        public string SecaoTitulo
        {
            get { return secaoTitulo; }
            set { secaoTitulo = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string EmissaoRg
        {
            get { return emissaoRg; }
            set { emissaoRg = value; }
        }

        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        public string EmissaoCpf
        {
            get { return emissaoCpf; }
            set { emissaoCpf = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public string Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Endreco
        {
            get { return endreco; }
            set { endreco = value; }
        }

        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string NomeMae
        {
            get { return nomeMae; }
            set { nomeMae = value; }
        }

        public string NomePai
        {
            get { return nomePai; }
            set { nomePai = value; }
        }

        public string Rh
        {
            get { return rh; }
            set { rh = value; }
        }

        public string TpSanguineo
        {
            get { return tpSanguineo; }
            set { tpSanguineo = value; }
        }

        public string Religiao
        {
            get { return religiao; }
            set { religiao = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        public string Naturalidade
        {
            get { return naturalidade; }
            set { naturalidade = value; }
        }

        public string Nacionalidade
        {
            get { return nascionalidade; }
            set { nascionalidade = value; }
        }

        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
                
        public string Nascimento
        {
            get { return nascimento; }
            set { nascimento = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }        
    }
}
