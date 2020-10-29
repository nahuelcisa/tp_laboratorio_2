using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        /// <summary>
        /// Constructor por defecto de la clase alumno que intancia los datos de un alumno por defecto
        /// </summary>
        public Alumno() : this(1, "SinNombre", "SinApellido", "0", ENacionalidad.Argentino, Universidad.EClases.SPD)
        {

        }


        /// <summary>
        /// Sobrecarga del contructor por defecto que inicializa los datos de un alumnos recibidos por parametros 
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Nacionaldad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) :
            base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Sobrecarga del contructor de la clase Alumno que inicializa el estado de la cuenta
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Nacionaldad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        /// <param name="estadoCuenta">Estado de la Cuenta del Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) :
            this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }


        /// <summary>
        /// Da formato a los datos del Alumno
        /// </summary>
        /// <returns>Retorna los datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("ESTADO DE CUENTA: Cuota al dia");
            }
            else
            {
                sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            }
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Valida si un Alumno toma una Clase
        /// </summary>
        /// <param name="a">El Alumno</param>
        /// <param name="clase">La Clase</param>
        /// <returns>True si el alumno toma la clase, false en caso contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool isEqual = a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
            return isEqual;
        }

        /// <summary>
        /// Valida si un alumno no toma la clase
        /// </summary>
        /// <param name="a">El Alumno</param>
        /// <param name="clase">La Clase</param>
        /// <returns>Devuelve true si no toma la clase, false en caso contrario</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        /// <summary>
        /// Da formato a la clase Alumno
        /// </summary>
        /// <returns>Devuelve la clase que toma el Alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"TOMA CLASES DE {this.claseQueToma}");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del ToStrgin()
        /// </summary>
        /// <returns>Devuelve los datos del un Alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
