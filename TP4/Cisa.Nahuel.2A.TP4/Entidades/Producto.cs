using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto 
    {
        protected string marca;
        protected string product;
        protected string modelo;
        protected float precio;       
        protected int cantidadDeStock;

        /// <summary>
        /// Propiedad de lectura y escritura del atributo marca
        /// </summary>
        public string Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo modelo
        /// </summary>
        public string Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                this.modelo = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo product
        /// </summary>
        public string Product
        {
            get
            {
                return this.product;
            }
            set
            {
                this.product = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo precio
        /// </summary>
        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo cantidadDeStock
        /// </summary>
        public int CantidadDeStock
        {
            get
            {
                return this.cantidadDeStock;
            }
            set
            {
                this.cantidadDeStock = value;
            }
        }

        /// <summary>
        /// Constructor por default de la clase, settea el stock del producto en 1.
        /// </summary>
        public Producto()
        {
            this.cantidadDeStock = 1;            
        }

        /// <summary>
        /// Constructor parametrizado el cual settea todos los parametros de la clase
        /// </summary>
        /// <param name="product">Tipo de producto del que se habla</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="modelo">Modelo del producto</param>
        /// <param name="precio">Precio del producto</param>
        /// <param name="cantDeStock">Cantidad de stock que tiene el objeto a ser creado</param>

        public Producto(string product ,string marca, string modelo,float precio, int cantDeStock)
        :this()
        {
            this.product = product;
            this.marca = marca;
            this.modelo = modelo;
            this.precio = precio;            
            this.cantidadDeStock = cantDeStock;            
        }

        /// <summary>
        /// Metodo protected, el cual le pasa la informacion al trostring para sobrecargarlo.
        /// </summary>
        /// <returns>string con la informacion del producto</returns>

        protected virtual string ProductoToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Marca: {this.marca}\nPrecio: {this.precio}\n Modelo: {this.Modelo}\n");

            
            sb.AppendFormat($" hay {this.cantidadDeStock} de unidades disponibles.");
            

            return sb.ToString();
        }
        /// <summary>
        /// tostring sobrecargado
        /// </summary>
        /// <returns>informacion del producto</returns>
        public override string ToString()
        {
            return this.ProductoToString();
        }

        /// <summary>
        /// Compara si dos productos son iguales, si comparten marca y modelo, son iguales.
        /// </summary>
        /// <param name="a">producto 1</param>
        /// <param name="b">producto 2</param>
        /// <returns></returns>

        public static bool operator ==(Producto a, Producto b)
        {
            bool rta = false;

            if (string.Compare(a.Marca, b.Marca) == 0 && string.Compare(a.Modelo, b.Modelo) == 0)
            {
                rta = true;
            }

            return rta;
        }

        public static bool operator !=(Producto a, Producto b)
        {
            return !(a == b);
        }

    }
}
