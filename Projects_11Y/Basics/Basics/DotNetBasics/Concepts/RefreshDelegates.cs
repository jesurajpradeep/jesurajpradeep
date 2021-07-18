using System;
using System.Collections.Generic;
using System.Text;
using DotNetBasics.Interfaces;

namespace DotNetBasics
{
    public class RefreshDelegates : IRefreshConcepts
    {
        Action<string> myAction; //Func can contains 0 to 16 input parameters and must have one return type.
        Func<int, double> myFunc; //Action can contain 1 to 16 input parameters and does not have any return type.
        Predicate<string> myPredicate; //Predicate delegate should satisfy some criteria of method and must have one input parameter and one Boolean return type either true or false.
        public RefreshDelegates()
        {
            myAction = new Action<string>(DoSomething);
            myFunc = new Func<int, double>(CalcSomething);
            myPredicate = new Predicate<string>(CheckIfApple);
        }

        public void ExecuteTestProgram()
        {
            myAction("test action delegate");
            Console.WriteLine(myFunc(1001));
            Console.WriteLine(myPredicate("Apple"));
            Console.WriteLine(myPredicate("samsung"));
        }

        private void DoSomething(string msg)
        {
            Console.WriteLine(msg);
        }

        private double CalcSomething(int i)
        {
            myAction("test func delegate");
            return i * i;
        }

        private bool CheckIfApple(string model)
        {
            bool __result = false;
            if (model == "Apple")
                __result = true;

            return __result;


        }

        
    }

}
