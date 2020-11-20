using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Gabinete : Producto , ISerializa, IDeserializa
    {
        protected int cantidadDeVentiladores;

        /// <summary>
        /// propiedad de lectura y escritura del unico atributo que posee la clase
        /// </summary>
        public int CantidadDeVentiladores
        {
            get
            {
                return this.cantidadDeVentiladores;
            }
            set
            {
                this.cantidadDeVentiladores = value;
            }
        }

        /// <summary>
        /// Constructor por default de la clase, creando un gabinete vacio.
        /// </summary>

        public Gabinete() : base("", "", "", 0, 0) { this.cantidadDeVentiladores = 0; }

        /// <summary>
        /// Constructor parametrizado el cual settea todos los parametros de la clase base, y el de la clase gabinete
        /// </summary>
        /// <param name="product">Tipo de producto del que se habla.</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="modelo">Modelo del producto</param>
        /// <param name="precio">Precio del producto</param>
        /// <param name="cantDeStock">Cantidad de stock que tiene el objeto a ser creado</param>
        /// <param name="cantidadDeVentiladores">Cantidad de ventiladores que poseen los gabinetes o el gabinete creado.</param>
        public Gabinete(string product,string marca, string modelo, float precio, int cantDeStock, int cantidadDeVentiladores)
            : base(product, marca, modelo, precio, cantDeStock)
        {
            this.cantidadDeVentiladores = cantidadDeVentiladores;         
        }

        /// <summary>
        /// Sobrecarga del ToString mediante el producto.tostring llamado desde el base, agregando la informacion de la clase gabinete, la cantidad de ventialdores que posee.
        /// </summary>
        /// <returns>String con la informacion del objeto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" Producto: Gabinete");
            sb.Append(base.ProductoToString());
            sb.AppendFormat($"\n Cantidad de Ventiladores: {this.CantidadDeVentiladores}\n");

            return sb.ToString();
        }
        /// <summary>
        /// Deserializa el objeto xml
        /// </summary>
        /// <param name="l">parametro de salida del gabinete serializado</param>
        /// <returns>true si lo pudo leer, false si no</returns>
        bool IDeserializa.Xml(out Gabinete l)
        {
            bool rta = true;

            try
            {
                using (XmlTextReader read = new XmlTextReader(this.Path))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Gabinete));

                    l = (Gabinete)ser.Deserialize(read);

                }

            }
            catch (Exception)
            {
                rta = false;
                l = new Gabinete();
            }

            return rta;

        }
        /// <summary>
        /// propiedad de lectura de la ruta en la cual el gabinete sera serializado
        /// </summary>
        public string Path
        {
            get
            {
                return Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop).ToString() + "\\Nahuel.Cisa.gabinete.xml";
            }
        }

        /// <summary>
        /// propiedad de serializacion del gabinete en cuestion.
        /// </summary>
        /// <returns>true si tuvo exito, false en caso contrario</returns>

        public bool Xml()
        {
            bool rta = true;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(this.Path, System.Text.Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Gabinete));

                    serializer.Serialize(writer, this);
                }

            }
            catch (Exception)
            {
                rta = false;

            }

            return rta;
        }
    }
}
