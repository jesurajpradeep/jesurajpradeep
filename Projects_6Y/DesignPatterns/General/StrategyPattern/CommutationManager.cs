using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class CommutationManager
    {
        ICommunicationStrategy m_commStrategy = null;

        /// <summary>
        /// CommutationManager
        /// </summary>
        /// <param name="stgy"></param>
        public CommutationManager(ICommunicationStrategy stgy)
        {
            m_commStrategy = stgy;
        }

        /// <summary>
        /// SetCommunicationStrategy
        /// </summary>
        /// <param name="stgy"></param>
        public void SetCommunicationStrategy(ICommunicationStrategy stgy)
        {
            m_commStrategy = stgy;
        }

        /// <summary>
        /// travel
        /// </summtravelary>
        public void travel()
        {
            m_commStrategy.travel();
        }

        /// <summary>
        /// timeToTravel
        /// </summary>
        public void timeToTravel()
        {
            m_commStrategy.timeToTravel();
        }

        /// <summary>
        /// costForTravel
        /// </summary>
        public void costForTravel()
        {
            m_commStrategy.costForTravel();
        }


    }
}
