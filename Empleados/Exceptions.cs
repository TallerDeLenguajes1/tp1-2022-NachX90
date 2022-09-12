using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados
{
    public class IncoherentDateTimeException : Exception
    {
        public override string Message
        {
            get
            {
                return "Inconsistency between dates";
            }
        }
    }
    public class NullOrEmptyStringException : Exception
    {
        public override string Message
        {
            get
            {
                return "Imput should not be null or empty";
            }
        }
    }
}
