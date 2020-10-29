using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : this("DNI con formato Incorrecto")
        {

        }
        public NacionalidadInvalidaException(string menssage) : base(menssage)
        {

        }
    }
}
