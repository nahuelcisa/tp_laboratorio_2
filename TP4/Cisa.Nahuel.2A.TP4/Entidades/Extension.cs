using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extension
    {
        public static string InformarCarritoLleno(this CarritoLlenoException ex)
        {
            return "El Carrito esta lleno.";
        }

        public static string InformarComboVacio(this ComboVacioException ex)
        {
            return "Hay que elegir un valor.";
        }
    }
}
