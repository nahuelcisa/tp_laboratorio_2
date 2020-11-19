using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : IProducto
    {
        protected string marca;
        protected string product;
        protected string modelo;
        protected float precio;       
        protected int cantidadDeStock;

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


        public Producto()
        {
            this.cantidadDeStock = 1;            
        }

        public Producto(string product ,string marca, string modelo,float precio, int cantDeStock)
        :this()
        {
            this.product = product;
            this.marca = marca;
            this.modelo = modelo;
            this.precio = precio;            
            this.cantidadDeStock = cantDeStock;            
        }

        protected virtual string ProductoToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Marca: {this.marca}\nPrecio: {this.precio}\n Modelo: {this.Modelo}\n");

            
            sb.AppendFormat($" hay {this.cantidadDeStock} de unidades disponibles.");
            

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.ProductoToString();
        }

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
