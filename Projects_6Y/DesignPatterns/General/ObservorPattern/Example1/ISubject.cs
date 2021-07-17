using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservorPattern.Example1
{
    interface ISubject
    {
        void registerObserver(IObserver newObserver);
        void removeObserver(IObserver existingObserver);
        void notifyObservers(string strImpWeatherInfo);
    }
}
