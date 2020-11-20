using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class TestBBDD
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        /// <summary>
        /// Inicializa la ruta de la bbdd
        /// </summary>
        public TestBBDD()
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.conexion);
        }


        /// <summary>
        /// Testea si la conexion se pudo realizar con exito
        /// </summary>
        /// <returns>True si pudo, False si no pudo conectarse</returns>
        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        /// <summary>
        /// retorna una lista de productos traidos desde la BBDD
        /// </summary>
        /// <returns></returns>
        public List<Producto> ObtenerListaDato()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM productos";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto item = new Producto();

                    // ACCEDO POR NOMBRE, POR INDICE O POR GETTER (SEGUN TIPO DE DATO)
                    item.Product = lector["producto"].ToString();
                    item.Marca = lector["marca"].ToString();
                    item.Modelo = lector["modelo"].ToString();
                    item.Precio = float.Parse(lector["precio"].ToString());
                    item.CantidadDeStock = int.Parse(lector["cantidad_de_stock"].ToString());

                    lista.Add(item);
                }

                lector.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }

    }
}
