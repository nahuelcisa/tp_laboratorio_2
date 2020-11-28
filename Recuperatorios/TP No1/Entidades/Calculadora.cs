using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

        #region Metodo Operar

        /// <summary>
        /// Realiza la operacion solicitada.
        /// </summary>
        /// <param name="num1">Numero 1</param>
        /// <param name="num2">Numero 2</param>
        /// <param name="operador">Operador, por default es el +</param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            operador = ValidarOperador(operador);

            if (num1 != null && num2 != null)
            {
                switch (operador)
                {
                    case "+":
                        retorno = num1 + num2;
                        break;

                    case "-":
                        retorno = num1 - num2;
                        break;

                    case "*":
                        retorno = num1 * num2;
                        break;

                    case "/":
                        retorno = num1 / num2;
                        break;
                    default:                       
                        break;
                }
            }

            return retorno;
        }


        #endregion

        #region Metodo ValidarOperador

        /// <summary>
        /// Verifica que el operador sea + - / *, en caso contrario retorna +
        /// </summary>
        /// <param name="operador">operador en si</param>
        /// <returns>operador en forma de string</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }
            
            return retorno;
        }
        #endregion
    }
}
