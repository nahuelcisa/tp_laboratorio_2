using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Carrito<Producto> carro = new Carrito<Producto>(3);

            Gabinete gabo = new Gabinete("Gabinete", "Corsair", "Strix", 46, 4, 7);

            Procesador micro = new Procesador("Procesador", "AMD", "Ryzen", 89, 3, 1);

            PlacaDeVideo gpu = new PlacaDeVideo("PlacaDeVideo", "NVIDIA", "Geforce", 100, 8, 240);

            Console.WriteLine("Es el carrito de compra, ahora tiene {0} elementos", carro.Productos.Count);

            Console.WriteLine("Agrego los elementos al carrito, maximo entran 3 productos, al agregar otro, hay una excepcion, carrito lleno exception.");

            carro += gabo;
            carro += micro;
            carro += gpu;

            Console.WriteLine("El carrito tiene {0} elementos\n", carro.Productos.Count);

            try
            {
                carro += gabo;
            }
            catch(CarritoLlenoException ex)
            {
                Console.WriteLine(ex.InformarCarritoLleno());
            }

            Console.WriteLine("---------------------------------------\n testing del tostring\n---------------------------------------");

            foreach (Producto item in carro.Productos)
            {
                Console.WriteLine(item.ToString());
            }


            Console.WriteLine("---------------------------------------");
            Console.WriteLine("TEST CONEXION BASE DE DATOS");
            Console.WriteLine("---------------------------------------");

            TestBBDD ado = new TestBBDD();

            if (ado.ProbarConexion())
            {
                Console.WriteLine("se conectó");
            }
            else
            {
                Console.WriteLine("no se conectó");
            }

            List<Producto> lista = ado.ObtenerListaDato();

            foreach (Producto item in lista)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("---------------------------------------");


            Console.ReadKey();
        }
    }
}
