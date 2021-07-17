using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class BikeCommunicationStrategy : ICommunicationStrategy
    {
        public void travel()
        {
            System.Console.WriteLine("Commuting via Bike");
        }

        public void timeToTravel()
        {
            System.Console.WriteLine("Time To Travel: 10 Min");
        }

        public void costForTravel()
        {
            System.Console.WriteLine("Cost For Travel: Rs.60");
        }
    }
}
