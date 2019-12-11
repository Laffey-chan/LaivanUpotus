using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaivanUpotus
{
    class Ships
    {
        public IntVector Vector { get; }
        public bool Destroy { get; set; }

        public Ships(int x,int y)
        {
            this.Vector = new IntVector(x,y);
        }
    }
}
