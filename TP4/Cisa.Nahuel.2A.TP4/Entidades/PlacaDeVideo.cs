using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlacaDeVideo : Producto
    {
        private int longitud;

        /// <summary>
        /// Propiedad de lectura del atributo longitud.
        /// </summary>

        public int Longitud
        {
            get
            {
                return this.longitud;
            }
        }

        /// <summary>
        /// Constructor parametrizado el cual settea todos los parametros de la clase base, y el de la clase Placa de video
        /// </summary>
        /// <param name="product">Tipo de producto del que se habla </param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="modelo">Modelo del producto</param>
        /// <param name="precio">Precio del producto</param>
        /// <param name="cantDeStock">Cantidad de stock que tiene el objeto a ser creado</param>
        /// <param name="longitud">Longitud de la placa de video.</param>

        public PlacaDeVideo(string product,string marca, string modelo, float precio, int cantDeStock, int longitud)
        :base(product,marca, modelo, precio, cantDeStock)
        {
            this.longitud = longitud;
        }
        /// <summary>
        /// Sobrecarga del ToString mediante el producto.tostring llamado desde el base, agregando la informacion de la clase placa de video, la longitud que posee.
        /// </summary>
        /// <returns>String con la informacion del objeto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" Producto: Placa de video");
            sb.Append(base.ProductoToString());
            sb.AppendFormat($" Longitud: {this.Longitud}cm\n");

            return sb.ToString();
        }

    }
}
