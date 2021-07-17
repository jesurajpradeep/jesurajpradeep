using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservorPattern.Example2
{
    public delegate void SampleDelegate();

    class ExposureScreen : ISubject
    {

        void registerObserver(IObserver newObserver) 
        { 

        }
        void removeObserver(IObserver existingObserver)
        { 
        
        }
        void notifyObservers(string strImpWeatherInfo)
        {

        }
    }
}
