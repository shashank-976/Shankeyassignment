using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLayer
{
    public class MedicalException:Exception
    {
        public MedicalException(string message) : base(message)
        {

        }
    }
}
