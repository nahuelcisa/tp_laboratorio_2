using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface IProducto
    {
        string Marca{get; }
        string Modelo { get; }
        float Precio { get; }       
        int CantidadDeStock { get; }

    }
}
