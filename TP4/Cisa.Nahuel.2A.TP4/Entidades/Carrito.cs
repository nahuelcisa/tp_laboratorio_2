using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Carrito<T> where T: Producto 
    {
        protected List<T> productos;
        protected int cantidad;
        public delegate void EventoPrecio(object sender, EventArgs e);
        public event EventoPrecio PrecioSuperado;              

        public List<T> Productos { get {return this.productos; }  }

        /// <summary>
        /// Propiedad lectura del precio minimo, se utiliza para lanzar el evento de pago en cuotas.
        /// </summary>

        public float PrecioMinimo
        {
            get
            {
                float total = 0;

                foreach (T item in productos)
                {
                    total += item.Precio;
                }

                return total;
            }
        }

        /// <summary>
        /// Propiedad de lectura, devuelve el precio total del carrito.
        /// </summary>
        public float PrecioTotal
        {
            get
            {
                float total = 0;

                foreach (T item in productos)
                {
                    total += item.Precio;
                }

                return total;
            }
        }

        /// <summary>
        /// Constructor por defecto, este inicializa la lista generica, la cantidad admitida por default es 5
        /// </summary>

        public Carrito()
        {
            this.productos = new List<T>();
            this.cantidad = 5;
            
        }

        /// <summary>
        /// Sobrecarga del constructor, elige la cantidad de elementos que pueden entrar en el carrito
        /// </summary>
        /// <param name="cantidad"></param>

        public Carrito(int cantidad)
        :this()
        {
            this.cantidad = cantidad;
        }

        /// <summary>
        /// Operador +, se utiliza para agregar un producto al carrito.
        /// a su vez, es el encargado de lanzar la excepcion carritollenoexception en caso de ser requerido.
        /// tambien, invoke al evento precio superado, que alerta al comprador que supero el precio minimo para poder acceder al pago en cuotas.
        /// </summary>
        /// <param name="d">El carrito al cual se le quiere agergar el producto.</param>
        /// <param name="p">Producto a ser agregado.</param>
        /// <returns>un nuevo carrito con el producto agregado si lo pudo agregar, si no, devuelve el carrito sin el producto agregado.</returns>
        
        public static Carrito<T> operator +(Carrito<T> d, T p)
        {

            if (d.productos.Count < d.cantidad && d != null)
            {
                d.productos.Add(p);
            }
            else if(d.productos.Count >= d.cantidad)
            {
                throw new CarritoLlenoException();
            }

            if (d.PrecioMinimo > 500 && d.PrecioSuperado != null)
            {
                d.PrecioSuperado.Invoke(d, EventArgs.Empty);
            }
           
           return d;
        }              

    }
}
