using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;

namespace TestUnitarios.TP4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_ListaGenerica_NoNull()
        {
            Carrito<Producto> carro = new Carrito<Producto>(3);

            Assert.IsNotNull(carro.Productos);
        }

        [TestMethod]
        public void Test_AgregarProductoEnLista()
        {
            Carrito<Producto> carro = new Carrito<Producto>(3);

            Procesador micro = new Procesador("Procesador", "AMD", "Ryzen", 25000, 2, 3);
       

            carro += micro;

            int count = carro.Productos.Count;

            Assert.AreEqual(1, count);

        }

        [TestMethod]

        public void Test_carroLlenoException()
        {
            Carrito<Producto> carro = new Carrito<Producto>(1);

            Procesador micro1 = new Procesador("Procesador", "AMD", "Ryzen", 25000, 2, 3);

            Procesador micro2 = new Procesador("Procesador", "Intel", "i7", 32000, 5, 7);

            carro += micro1;

            try
            {
                carro += micro2;
            }
            catch(CarritoLlenoException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}
