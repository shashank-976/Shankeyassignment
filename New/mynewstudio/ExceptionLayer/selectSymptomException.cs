using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLayer
{
   public class selectSymptomException:Exception
    {
        public selectSymptomException(string message) : base(message)
        {

        }
    }
}
