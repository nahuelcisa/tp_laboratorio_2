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

        /// <summary>
        /// propiedad que setea el numero, valida el numero que sea algo correcto
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }


        #endregion


        #region Constructor

        /// <summary>
        /// constructor por defecto, el numero es 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Settea el numero pasado por parametro y lo asigna al atributo
        /// </summary>
        /// <param name="numParam">numero para asignar</param>
        public Numero(double numParam)
        {
            this.numero = numParam;
        }

        /// <summary>
        /// Recibe como string el numero y realiza el parse.
        /// </summary>
        /// <param name="strNumero">numero en forma de string</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }


        #endregion


        #region Metodos

        /// <summary>
        /// valida el numero realizando el parse.
        /// </summary>
        /// <param name="strNumero">numero en formato string</param>
        /// <returns>retorna el numero parseado</returns>
        private double ValidarNumero(string strNumero)
        {

            double retorno;

            double.TryParse(strNumero, out retorno);

            return retorno;
        }

        /// <summary>
        /// verifica que el numero sea binario fijandose si la cadena recibida es 0 y 1
        /// </summary>
        /// <param name="binario">cadena del numero binario</param>
        /// <returns>true si es binario, false si no lo es</returns>
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

        /// <summary>
        /// Transforma el numero string recibido por parametro para transformarlo de binario a decimal
        /// </summary>
        /// <param name="binario">numero binario en forma de cadena</param>
        /// <returns>Error si no pudo convertirlo, en caso contrario devuelve la conversion</returns>

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

        /// <summary>
        /// transofrma la cadena de decimal a binario.
        /// </summary>
        /// <param name="numero">numero en string</param>
        /// <returns>Error si no pudo convertirlo, en caso contrario devuelve la conversion</returns>
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

        /// <summary>
        /// Toma la parte entera del numero recibido por parametro y la transforma a binario
        /// </summary>
        /// <param name="numero">Numero</param>
        /// <returns>Numero pasado por parametro representado en binario en formato string</returns>
        public  static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)Math.Abs(numero), 2);
        }

        /// <summary>
        /// realiza la resta de ambos numeros
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>retorna el resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }

        /// <summary>
        /// realiza la multiplicacion entre ambos numeros
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>retorna el resultado de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }
        /// <summary>
        /// realiza la division, primero verificando el valor minimo mediante la constante MinValue, y verifica que no se este dividiendo por cero.
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>resultado de la division si pudo realizarla, caso contrario la constante MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = double.MinValue;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }

        /// <summary>
        /// realiza la suma entre los dos numeros pasados por parametro
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;

            return resultado;
        }


        #endregion
    }
}
