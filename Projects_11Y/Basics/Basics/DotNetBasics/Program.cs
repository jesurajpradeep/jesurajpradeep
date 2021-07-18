using System;
using DotNetBasics.Interfaces;

namespace DotNetBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            IRefreshConcepts refreshDelegates = new RefreshDelegates();
            refreshDelegates.ExecuteTestProgram();
            Console.ReadLine();
                
        }
    }
}
