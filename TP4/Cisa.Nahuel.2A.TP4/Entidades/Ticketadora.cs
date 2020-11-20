using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class Ticketeadora<T> where T : Producto
    {

        /// <summary>
        /// Realiza el ticket de la compra
        /// </summary>
        /// <param name="car">carrito el cual se quiere hacer el ticket</param>
        /// <returns>true si pudo crear el ticket, false si no pudo</returns>
        public static bool ImprimirTicket(Carrito<T> car)
        {
            bool rta = true;

            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\tickets.log";

            try
            {
                using (StreamWriter f = new StreamWriter(path))
                {
                    f.Write("Fecha: ");
                    f.WriteLine(System.DateTime.Now);
                    f.Write("Precio Total: ");
                    f.WriteLine(car.PrecioTotal);
                    foreach (T item in car.Productos)
                    {
                        f.WriteLine(item.ToString());
                    }                    
                    f.WriteLine("---------------------------------");
                }
            }
            catch
            {
                rta = false;
            }
            return rta;
        }
    }
}
