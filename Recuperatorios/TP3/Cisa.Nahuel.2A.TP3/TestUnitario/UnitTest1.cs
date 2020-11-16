using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Excepciones;
using Clases_Instanciables;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Valida que la lista de alumnos de una universidad no sea null
        /// </summary>
        [TestMethod]
        public void Lista_Alumnos_Correcta()
        {
            Universidad u = new Universidad();
            Assert.IsNotNull(u.Alumnos);
        }

        /// <summary>
        /// Valida que el alumno no se repita arrojando AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void Alumno_Repetido()
        {
            try
            {
                Universidad u = new Universidad();

                Alumno a1 = new Alumno(1, "lucho", "Sinisterra", "99999999", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
                Alumno a2 = new Alumno(2, "lucho", "Sinisterra", "99999999", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);

                u += a1;
                u += a2;
                
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }


        /// <summary>
        /// Comprueba los rangos de DNI para Argentinos
        /// </summary>
        [TestMethod]
        public void DNI_Validos_Argentino()
        {
            string dniPrimero = "1";
            string dniMedio = new Random().Next(1, 89999999).ToString();
            string dniUltimo = "89999999";


            Alumno alumnoPrimero = new Alumno(1, "Juan", "Lopez", dniPrimero, Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Assert.AreEqual(Convert.ToInt32(alumnoPrimero.DNI), Convert.ToInt32(dniPrimero));

            Alumno alumnoMedio = new Alumno(2, "Fany", "Ferreyra", dniMedio, Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            Assert.AreEqual(Convert.ToInt32(alumnoMedio.DNI), Convert.ToInt32(dniMedio));

            Alumno alumnoUltimo = new Alumno(3, "Maximiliano", "Alvarez", dniUltimo, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.AreEqual(Convert.ToInt32(alumnoUltimo.DNI), Convert.ToInt32(dniUltimo));

        }

        /// <summary>
        /// Valida que el DNI en formato texto NO pueda tener:
        /// Coma
        /// Letras
        /// Arroja DniInvalidoException
        /// </summary>
        [TestMethod]
        public void DNI_Invalido()
        {
            string dniComa = "30.999,999";
            string dniTexto = "30a00123";

            try
            {
                Alumno personaPrimero = new Alumno(1, "Tomas", "Lodoa", dniComa, Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniComa);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            try
            {
                Alumno personaPrimero = new Alumno(1, "Luciano", "Sinisterra", dniComa, Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniTexto);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

    }
}
