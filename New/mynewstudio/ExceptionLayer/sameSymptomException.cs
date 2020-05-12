using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLayer
{
   public class sameSymptomException:Exception
    {
        public sameSymptomException(string message) : base(message)
        {

        }
    }
}
