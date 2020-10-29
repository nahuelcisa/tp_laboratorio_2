using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;


        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = new List<Alumno>(value); ;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = new List<Jornada>(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = new List<Profesor>(value);
            }
        }

        /// <summary>
        /// Indexador de lectura y escritura de la lista de jornadas
        /// </summary>
        /// <param name="i">Indice de la lista de jornadas</param>
        /// <returns>Devuelve la jornada en el indice</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }


        /// <summary>
        /// Constructor por defecto de la clase universidad que instancia las listas de alumnos, jornadas y profesores
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Devuelve los datos de una universidad.
        /// </summary>
        /// <returns>Devuelve los datos de una universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Serializa los datos de una universidad en un archivo .xml
        /// </summary>
        /// <param name="uni">La universidad</param>
        /// <returns>Devuelve true si se pudo serializar, false caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> u = new Xml<Universidad>();
            return u.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Deserializa los datos de una universidad de un archivo .xml
        /// </summary>
        /// <returns>Devuelve una universidad con los datos</returns>
        public Universidad Leer()
        {
            Xml<Universidad> u = new Xml<Universidad>();
            u.Leer("Universidad.xml", out Universidad universidadxml);
            return universidadxml;
        }


        /// <summary>
        /// Da formato a los datos de una universidad
        /// </summary>
        /// <param name="uni">La universidad</param>
        /// <returns>Devuelve los datos de una universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Verifica si un alumno no esta inscripto en una universidad
        /// </summary>
        /// <param name="g">La universidad</param>
        /// <param name="a">El alumno</param>
        /// <returns>Devuelve true si el alumno no esta inscripto en la universidad, false caso contrario</returns>

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica si un profesor no esta dando clases en una universidad
        /// </summary>
        /// <param name="g">La universidad</param>
        /// <param name="i">El profesor</param>
        /// <returns>Devuelve true si el profesor no da clases en la universidad, false caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Busca al primer profesor de la universidad que no pueda dar la clase pasada como parametro
        /// </summary>
        /// <param name="u">La universidad</param>
        /// <param name="clase">La clase</param>
        /// <returns>Devuelve al primer profesor que no puede dar la clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor instructor = null;

            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    instructor = profesor;
                    break;
                }
            }
            return instructor;
        }


        /// <summary>
        /// Verifica si un alumno esta inscripto en una universidad
        /// </summary>
        /// <param name="g">La universidad</param>
        /// <param name="a"> alumno</param>
        /// <returns>Devuelve true si el alumno esta inscripto en la universidad, false caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            if (!Object.Equals(g, null) && !Object.Equals(a, null))
            {
                foreach (Alumno item in g.Alumnos)
                {
                    if (a == item)
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Verifica si un profesor esta dando clases en una universidad
        /// </summary>
        /// <param name="g">La Universidad</param>
        /// <param name="i">Un profesor</param>
        /// <returns>Devuelve true si el profesor da clases en la universidad, false caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            if (!Object.Equals(g, null) && !Object.Equals(i, null))
            {
                foreach (Profesor item in g.Instructores)
                {
                    if (item == i)
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Busca al primer profesor de la universidad capaz de dar la clase pasada como parametro
        /// </summary>
        /// <param name="u">La universidad</param>
        /// <param name="clase">La clase</param>
        /// <returns>Devuelve al primer profesor capaz de dar la clase</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor instructor = null;

            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    instructor = item;
                    break;
                }
            }
            if (Object.Equals(instructor, null))
            {
                throw new SinProfesorException();
            }
            return instructor;
        }

        /// <summary>
        /// Agrega un profesor a la universidad
        /// </summary>
        /// <param name="u">La universidad</param>
        /// <param name="a">El alumno</param>
        /// <returns>Devuelve la universidad pasada como parametro</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Agrega a la universidad una nueva jornada con la clase pasada como parametro, un profesor que pueda la dicha clase y la lista de alumnos que la toman
        /// </summary>
        /// <param name="g">La universidad.</param>
        /// <param name="clase">La clase</param>
        /// <returns>Devuelve la universidad pasada como parametro</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, g == clase);

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    nuevaJornada.Alumnos.Add(alumno);
                }
            }
            if (nuevaJornada.Alumnos.Count > 0)
            {
                g.Jornadas.Add(nuevaJornada);
            }

            return g;
        }

        /// <summary>
        /// Agrega un alumno a la universidad
        /// </summary>
        /// <param name="u">La universidad</param>
        /// <param name="a">El alumno</param>
        /// <returns>Devuelve la universidad pasada como parametro</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
    }
}
