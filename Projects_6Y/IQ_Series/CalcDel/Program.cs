using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDel
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = WordCounter.UsingLINQ("false false true", "false");

        }

        static void Equals()
        {
            string test = Console.ReadLine();

            Math obj = new Math();
            PointerToMathLib point = obj.GetPointerToMathFunc(1);
            Console.WriteLine(point.Invoke(1, 1));
        }


    }
}
