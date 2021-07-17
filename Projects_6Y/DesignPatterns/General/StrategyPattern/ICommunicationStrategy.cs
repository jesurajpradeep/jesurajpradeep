using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    /// <summary>
    /// ICommunicationStrategy
    /// </summary>
    interface ICommunicationStrategy
    {
        void travel();
        void timeToTravel();
        void costForTravel();
    }
}
