using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas

{
    public abstract class Persona
    {
        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;


        /// <summary>
        /// Propiedad de lectura y escritura del apellido de la Persona
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del DNI de la persona
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de la Nacionalidad de la perosna
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del Nombre de la Persona
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del DNI de tipo string de la Persona
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }


        /// <summary>
        /// Constructor por defecto de la Persona que inicializa los datos por defecto
        /// </summary>
        public Persona()
        {
            this.Nacionalidad = ENacionalidad.Argentino;
            this.Nombre = "";
            this.Apellido = "";
            this.DNI = 1;
        }


        /// <summary>
        /// Sobrecarga del constructor de la clase Persona que instancia los datos pasados como paramtros 
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apeliido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase Persona que instancia los datos pasados como paramtros 
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apeliido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase Persona que instancia los datos pasados como paramtros 
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apeliido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }


        /// <summary>
        /// Sobrecarca del ToString()
        /// </summary>
        /// <returns>Devuelve en un formato especifico los datos de una persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");

            return sb.ToString();
        }


        /// <summary>
        /// Valida el DNI(int) segun la nacionalidad de la persona
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>Devuelve el DNI validaddo, en caso de error lanza una Excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                    break;
            }

            return dato;
        }


        /// <summary>
        /// Sobrecarga de ValidarDni, verifica que el DNI(string) este detro de los rangos y no contenga letras
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>Devuelve el DNI validado, en caso de error lanza una Excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numeroDni = -1;
            if (dato.Length < 1 || dato.Length > 8 || !Int32.TryParse(dato, out numeroDni))
            {
                throw new DniInvalidoException("El DNI no coincide con el formato");
            }
            return ValidarDni(nacionalidad, numeroDni);
        }

        /// <summary>
        /// Valida el nombre y apellido de la persona
        /// </summary>
        /// <param name="dato">el nombre o apellido de la persona</param>
        /// <returns>Retorna el nombre o apellido validado</returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex(@"[a-zA-Z]*");
            Match match = regex.Match(dato);
            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        ///  Enumerado de tipo de Nacionalidad de la Persona
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
