using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Contructor statico de la Clase Profesor que inicializa random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto de la Clase Profesor
        /// </summary>
        public Profesor() : this(1, "Sin nombe", "Sin apellido", "1", ENacionalidad.Argentino)
        {
        }

        /// <summary>
        /// SObrecarga del Constructor que instancia los datos pasados como parametros y las clases random 
        /// </summary>
        /// <param name="id">ID del profesor</param>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <param name="dni">DNI del profesor</param>
        /// <param name="nacionalidad">Nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Genera dos clases de manera random para el Profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                clasesDelDia.Enqueue((Universidad.EClases)(random.Next(0, 4)));
            }
        }


        /// <summary>
        /// Da formato a los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Da formato a la clase que da el Profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Devuelde los datos de un Profesor
        /// </summary>
        /// <returns>Devuelde los datos de un profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Verifica si un profesor da una clase
        /// </summary>
        /// <param name="i">El Profesor</param>
        /// <param name="clase">La Clase</param>
        /// <returns>Devuelve true si el Profesor da la clase, false en caso contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool isEqual = false;
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (clase == item)
                {
                    isEqual = true;
                    break;
                }
            }
            return isEqual;
        }

        /// <summary>
        /// Verifica si un Profesor no da una Clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si no da la clase el profesor, false en caso contrario</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
