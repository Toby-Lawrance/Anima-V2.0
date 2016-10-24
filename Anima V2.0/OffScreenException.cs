using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anima
{
    public class OffScreenException : System.Exception
    {
        public OffScreenException(string message) : base(message)
        {
            
        }

        public OffScreenException(Anima.Point Position) : base("Offscreen at X: " + Position.Left + " Y: " + Position.Top)
        {
        }
    }
}
