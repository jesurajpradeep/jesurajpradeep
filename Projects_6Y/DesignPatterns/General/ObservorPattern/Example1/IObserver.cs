using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservorPattern.Example1
{
    interface IObserver
    {
        void update(string strImpWeatherInfo);
    }
}
