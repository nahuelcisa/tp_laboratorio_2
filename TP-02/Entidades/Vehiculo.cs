using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo //****Cambie sealed por abstract****
    {
        public enum EMarca //****agregue public****
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio //****Agregue public****
        {
            Chico, Mediano, Grande
        }
        EMarca marca;
        string chasis;
        ConsoleColor color;

        public Vehiculo(string pChasis, EMarca pMarca, ConsoleColor pColor)
        {
            this.chasis = pChasis;
            this.marca = pMarca;
            this.color = pColor;
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected  abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        virtual public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {this.chasis}");
            sb.AppendLine($"MARCA : {this.marca.ToString()}");
            sb.AppendLine($"COLOR : {this.color.ToString()}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        public static explicit operator string(Vehiculo p)
        {         
            return p.Mostrar();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            bool rta = false;

            if (String.Compare(v1.chasis, v2.chasis) == 0)
            {
                rta = true;
            }

            return rta;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (!(v1 == v2));
        }
    }
}
