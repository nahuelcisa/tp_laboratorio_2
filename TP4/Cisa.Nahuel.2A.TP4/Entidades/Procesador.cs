using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Procesador : Producto
    {
        
        protected int generacion;

        /// <summary>
        /// propiedad de lectura del unico atributo que posee la clase
        /// </summary>
        public int Generacion
        {
            get
            {
                return this.generacion;
            }
        }

        /// <summary>
        /// Constructor parametrizado el cual settea todos los parametros de la clase base, y el de la clase procesador
        /// </summary>
        /// <param name="product">Tipo de producto del que se habla</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="modelo">Modelo del producto</param>
        /// <param name="precio">Precio del producto</param>
        /// <param name="cantDeStock">Cantidad de stock que tiene el objeto a ser creado</param>
        /// <param name="generacion">Generacion del procesador</param>

        public Procesador(string product, string marca, string modelo, float precio, int cantDeStock, int generacion)
        :base(product, marca,modelo,precio,cantDeStock)
        {
            this.generacion = generacion;
        }

        /// <summary>
        /// Sobrecarga del ToString mediante el producto.tostring llamado desde el base, agregando la informacion de la clase procesador, la generacion  que posee.
        /// </summary>
        /// <returns>String con la informacion del objeto</returns>

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" Producto: Procesador");
            sb.Append(base.ProductoToString());
            sb.AppendFormat($" Generacion: {this.Generacion}\n");

            return sb.ToString();
        }
      
    }
}
