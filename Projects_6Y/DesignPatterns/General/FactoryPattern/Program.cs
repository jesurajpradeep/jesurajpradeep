using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*

In Factory pattern, we create object without exposing the creation logic.
In this pattern, an interface is used for creating an object, 
but let subclass decide which class to instantiate. The creation of object is done when it is required.

1. Subclasses figure out what objects should be created.
2. Parent class allows later instantiation to subclasses means the creation of object is done when it is required.
3. The process of objects creation is required to centralize within the application.
4. A class (creator) will not know what classes it will be required to create

*/

namespace FactoryPattern
{
    interface IProduct
    {
        string ShipFrom();
    }

    class ProductA : IProduct
    {
        public String ShipFrom()
        {
            return "from South Africa";
        }
    }

    class ProductB : IProduct
    {
        public String ShipFrom()
        {
            return "from Spain";
        }
    }

    class DefaultProduct : IProduct
    {
        public String ShipFrom()
        {
            return "not available";
        }
    }

    class Creator
    {
        public IProduct FactoryMethod(int month)
        {
            if (month >= 4 && month <= 11)
                return new ProductA();
            else
                if (month == 1 || month == 2 || month == 12)
                    return new ProductB();
                else return new DefaultProduct();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Creator c = new Creator();
            IProduct product;
            for (int i = 1; i <= 12; i++)
            {
                product = c.FactoryMethod(i);
                Console.WriteLine("Avocados " + product.ShipFrom());
            }
        }
    }
}
