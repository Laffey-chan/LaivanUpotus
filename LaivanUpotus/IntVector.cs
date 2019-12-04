using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaivanUpotus
{
    class IntVector : IComparable<IntVector>
    {
        public int x, y;
        public IntVector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Double Magnitude
        {
            get { return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)); }
        }
        public int CompareTo(IntVector intvector)
        {
            try
            {
                return Magnitude.CompareTo(intvector);
            }
            catch (Exception e)
            {
                return 1;
            }
        }
        public static bool operator ==(IntVector operand1, IntVector operand2)
        {
            return (operand1.x - operand2.x == 0 && operand1.y - operand2.y == 0);
        }
        public static bool operator !=(IntVector operand1, IntVector operand2)
        {
            return !(operand1.x - operand2.x == 0 && operand1.y - operand2.y == 0);
        }
    }
}
