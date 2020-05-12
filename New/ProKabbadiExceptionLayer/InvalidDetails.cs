using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProKabbadiExceptionLayer
{
    public class InvalidDetails:Exception
    {
        public InvalidDetails(string message) : base(message)
        {

        }
    }
}
