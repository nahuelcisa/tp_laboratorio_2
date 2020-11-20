using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extension
    {

        /// <summary>
        /// Extiende la excepcion para poder mostrar el mensaje en cuestion.
        /// </summary>
        /// <param name="ex">carritollenoexception </param>
        /// <returns>Mensaje de la excepcion</returns>
        public static string InformarCarritoLleno(this CarritoLlenoException ex)
        {
            return "El Carrito esta lleno.";
        }

        /// <summary>
        /// Extiende la excepcion para poder mostrar el mensaje en cuestion.
        /// </summary>
        /// <param name="ex">ComboVacioException </param>
        /// <returns>Mensaje de la excepcion</returns>
        public static string InformarComboVacio(this ComboVacioException ex)
        {
            return "Hay que elegir un valor.";
        }
    }
}
