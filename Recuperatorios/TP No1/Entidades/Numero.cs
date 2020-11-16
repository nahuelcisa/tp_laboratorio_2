using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {

        #region Atributo
        private double numero;
        #endregion


        #region Set


        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }


        #endregion


        #region Constructor

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numParam)
        {
            this.numero = numParam;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }


        #endregion


        #region Metodos

        private double ValidarNumero(string strNumero)
        {

            double retorno;

            double.TryParse(strNumero, out retorno);

            return retorno;
        }


        private static bool EsBinario(string binario)
        {
            int cont = 0;

            foreach (var item in binario)
            {
                if(item == 0 || item == 1)
                {
                    cont++;
                }
            }

            if(cont == binario.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string BinarioDecimal(string binario)
        {
            bool aux = true;
            string retorno = "Error.";

            foreach (var item in binario)
            {
                if(item != '0' && item != '1')
                {
                    aux = false;
                }
            }


            if(aux == true)
            {
                retorno = Convert.ToInt32(binario, 2).ToString();
            }

            return retorno;
        }


        public static string DecimalBinario(string numero)
        {
            string retorno = "Error.";

            double aux;

            if (double.TryParse(numero, out aux) )
            {
                retorno = DecimalBinario(aux);
            }

            return retorno;
        }

        public  static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)Math.Abs(numero), 2);
        }


        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }


        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = double.MinValue;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;

            return resultado;
        }


        #endregion
    }
}
