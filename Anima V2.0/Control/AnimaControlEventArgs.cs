using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Anima
{
    public class AnimaControlEventArgs : EventArgs
    {
        public string Message
        { get; private set; }

        public double LeftPosition
        { get; private set; }

        public double RightPosition
        { get; private set; }

        public Point Position;
        
        public AnimaControlEventArgs(string s)
        {
            this.Message = s;
        }
    }
}
