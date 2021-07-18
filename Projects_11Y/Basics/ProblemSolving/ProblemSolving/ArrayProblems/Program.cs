using System;
using ArrayProblems.Interfaces;
using ArrayProblems.Problems;

namespace ArrayProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            HourGlassProblem();
            Console.ReadLine();
        }

        static void HourGlassProblem()
        {
            IArrayProblem prob = new HourGlass();
            prob.Solve();
        }
        
    }
}
