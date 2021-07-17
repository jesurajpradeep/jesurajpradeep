using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDel
{
    public class StringArrOutput
    {
        public string[] arr = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"};

        public void PrintArray(string[] coll)
        {
            foreach(string element in coll)
            {
                Console.WriteLine(element);
            }
        }

        public void ArrayReverse(string[] coll)
        {
            //coll.Reverse(); // Value Type
            Array.Reverse(coll); // Reference type
        }


        public void Execute()
        {
            Console.WriteLine("Initial array");
            PrintArray(arr);
            ArrayReverse(arr);
            Console.WriteLine("After reversing");
            PrintArray(arr);

        }
    
    }
}
