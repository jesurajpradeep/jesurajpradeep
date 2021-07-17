using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    public class CarCommunicationStragegy : ICommunicationStrategy
    {
        public void travel()
        {
            System.Console.WriteLine("Commuting via Car");
        }

        public void timeToTravel()
        {
            System.Console.WriteLine("Time To Travel: 20 Min");
        }

        public void costForTravel()
        {
            System.Console.WriteLine("Cost For Travel: Rs.120");
        }
    }
}
