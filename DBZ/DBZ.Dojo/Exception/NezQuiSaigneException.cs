using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBZ.Dojo.Exception
{
    public class NezQuiSaigneException : System.Exception
    {
        public NezQuiSaigneException(string message) : base(message){}
    }
}
