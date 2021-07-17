using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservorPattern.Example1
{
    /// <summary>
    /// Concrete Subject
    /// </summary>

    class WeatherStation : ISubject
    {
        List<IObserver> oObserverList;

        public WeatherStation()
        {
            oObserverList = new List<IObserver>();
        }

        public void registerObserver(IObserver newObserver)
        {
            oObserverList.Add(newObserver);
        }

        public void removeObserver(IObserver exisitingObserver)
        {
            oObserverList.Remove(exisitingObserver);
        }

        public void notifyObservers(string strWeatherInfo)
        {
            foreach (IObserver oObserver in oObserverList)
            {
                oObserver.update(strWeatherInfo);
            }
        }

    }
}
