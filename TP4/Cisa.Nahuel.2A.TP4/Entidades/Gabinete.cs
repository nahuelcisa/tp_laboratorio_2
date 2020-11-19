using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gabinete : Producto
    {
        protected int cantidadDeVentiladores;

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

 
      

        public Gabinete(string product,string marca, string modelo, float precio, int cantDeStock, int cantidadDeVentiladores)
            : base(product, marca, modelo, precio, cantDeStock)
        {
            this.cantidadDeVentiladores = cantidadDeVentiladores;         
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" Producto: Gabinete");
            sb.Append(base.ProductoToString());
            sb.AppendFormat($"\n Cantidad de Ventiladores: {this.CantidadDeVentiladores}\n");

            return sb.ToString();
        }
    }
}
