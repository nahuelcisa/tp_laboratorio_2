using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa en un Archivo .xml cualquier tipo de dato
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a serializar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializadorxml = new XmlSerializer(typeof(T));
                using (TextWriter tw = new StreamWriter(archivo))
                {
                    serializadorxml.Serialize(tw, datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Deserializa de un Archivo .xml cualquier tipo de dato
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a deserializar</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            datos = default(T);
            try
            {
                XmlSerializer serializadorxml = new XmlSerializer(typeof(T));
                using (TextReader tr = new StreamReader(archivo))
                {
                    datos = (T)serializadorxml.Deserialize(tr);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
