using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern
{
    class HondaCity : IVehicle
    {
        public string Make 
        { 
            get 
            {
                return "2010";
            }
        }

        public string Model
        {
            get
            {
                return "xyz";
            }
        }

        public double Price 
        { 
            get 
            {
                return 10;
            } 
        }

    }
}
