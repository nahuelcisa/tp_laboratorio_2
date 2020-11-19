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

        public int Longitud
        {
            get
            {
                return this.longitud;
            }
        }

        public PlacaDeVideo(string product,string marca, string modelo, float precio, int cantDeStock, int longitud)
        :base(product,marca, modelo, precio, cantDeStock)
        {
            this.longitud = longitud;
        }

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
