using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula
{
    class ValidaCpf
    {
        public static bool validaCpf(String cpf)
        {
            Boolean valida = true;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            String tempCpf;
            String digito;
            String verifica;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace("-", "").Replace(".", "");

            if (cpf.Length == 11)
            {
                verifica = cpf.Substring(9);
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma = soma + int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                }

                resto = soma % 11;

                resto = resto < 2 ? resto = 0 : resto = 11 - resto; ;

                digito = resto.ToString();

                tempCpf = tempCpf + digito;

                soma = 0;
                for (int i = 0; i < 10; i++)
                {
                    soma = soma + int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                }

                resto = soma % 11;

                resto = resto < 2 ? resto = 0 : resto = 11 - resto; ;

                digito = digito + resto.ToString();

                if (digito != verifica)
                {
                    valida = false;
                }
                switch (cpf)
                {
                    case "00000000000":
                        {
                            valida = false;
                            break;
                        }
                    case "11111111111":
                        {
                            valida = false;
                            break;
                        }
                    case "  22222222222 ":
                        {
                            valida = false;
                            break;
                        }
                    case "33333333333":
                        {
                            valida = false;
                            break;
                        }
                    case "44444444444":
                        {
                            valida = false;
                            break;
                        }
                    case "55555555555":
                        {
                            valida = false;
                            break;
                        }
                    case "66666666666":
                        {
                            valida = false;
                            break;
                        }
                    case "77777777777":
                        {
                            valida = false;
                            break;
                        }
                    case "88888888888":
                        {
                            valida = false;
                            break;
                        }
                    case "99999999999":
                        {
                            valida = false;
                            break;
                        }
                }
            }
            else
            {
                valida = false;
            }
            return valida;
        }
    }
}
