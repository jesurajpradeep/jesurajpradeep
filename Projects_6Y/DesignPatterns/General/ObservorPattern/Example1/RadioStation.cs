using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservorPattern.Example1
{
    class RadioStation : IObserver
    {
        public void update(string strImpWeatherInfo)
        {
            System.Console.WriteLine("Radio Station Weather Report: " + strImpWeatherInfo);
        }

    }
}
