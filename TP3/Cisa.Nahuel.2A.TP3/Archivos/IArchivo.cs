using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        /// <summary>
        /// Fima del Metodo Guardar de IArchivo
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Firma del Metodo Leer de IArchivos
        /// </summary>
        /// <param name="archivo">Ruta al Archivo</param>
        /// <param name="datos">Datos a leer</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }
}
