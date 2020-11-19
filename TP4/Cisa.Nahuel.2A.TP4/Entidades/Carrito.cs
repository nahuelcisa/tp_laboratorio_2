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

        public Carrito()
        {
            this.productos = new List<T>();
            
        }

        public Carrito(int cantidad)
        :this()
        {
            this.cantidad = cantidad;
        }
        
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

        

        public string Path
        {
            get
            {
                return Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop).ToString() + "\\Nahuel.Cisa.lapiz.xml";
            }
        }

        public bool Xml()
        {
            bool rta = true;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(this.Path, System.Text.Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Producto));

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
