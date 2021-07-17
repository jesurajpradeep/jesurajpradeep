using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservorPattern.Example1
{
    class TVStation : IObserver
    {
        public void update(string strImpWeatherInfo)
        {
            System.Console.WriteLine("TV Station Weather Report: " + strImpWeatherInfo);
        }
    }
}
