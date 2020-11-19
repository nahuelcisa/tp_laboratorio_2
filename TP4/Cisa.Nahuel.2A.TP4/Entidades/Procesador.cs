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
        
        public int Generacion
        {
            get
            {
                return this.generacion;
            }
        }

        public Procesador(string product, string marca, string modelo, float precio, int cantDeStock, int generacion)
        :base(product, marca,modelo,precio,cantDeStock)
        {
            this.generacion = generacion;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Producto: Procesador");
            sb.Append(base.ProductoToString());
            sb.AppendFormat($"Generacion: {this.Generacion}\n");

            return sb.ToString();
        }
      
    }
}
