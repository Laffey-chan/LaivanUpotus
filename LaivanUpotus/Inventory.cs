using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaivanUpotus
{
    class Inventory
    {
        public int S { get; set; }
        public int A { get; set; }

        public Inventory(int s = 0, int a =0)
        {
            S = s;
            A = a;
        }

        public override string ToString()
        {
            return S +"\n"+A;
        }
    }
}
