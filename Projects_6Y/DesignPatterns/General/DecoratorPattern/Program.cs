using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern
{
    /*
    The role of the Decorator pattern is to provide a way of attaching new state and
    behavior to an object dynamically. The object does not know it is being “decorated,”
    which makes this a useful pattern for evolving systems.
    Eg: Photo and decorations(decorations are independent from its original object.
    
    */
    class Program
    {
        static void Main(string[] args)
        {
            HondaCity obj = new HondaCity();
            Console.WriteLine("Make =  {0}, Model = {1},  Rate = {2}", obj.Make, obj.Model, obj.Price);

            //Special offer
        }
    }
}
