using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDel
{
    public delegate int PointerToMathLib(int x, int y);
    public class Math
    {
        public PointerToMathLib GetPointerToMathFunc(int operation)
        {
            PointerToMathLib libRef = null;

            if (operation == 1)
                libRef = Add;
            else if (operation == 2)
                libRef = Sub;
            else if (operation == 3)
                libRef = Mul;
            else if (operation == 4)
                libRef = Div;

            return libRef;

        }

        private int Add(int i, int y)
        {
            return i + y;
        }

        private int Sub(int i, int y)
        {
            return i - y;
        }

        private int Mul(int i, int y)
        {
            return i * y;
        }

        private int Div(int i, int y)
        {
            return i / y;
        }
    }
}
