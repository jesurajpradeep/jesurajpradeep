using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservorPattern.Example1;

namespace ObservorPattern
{

    /*
 The Observer pattern defines a relationship between objects so that when one
 changes its state, all the others are notified accordingly.
     
 Eg: 1. Blogger - Subscriber to Blogs. 
     2. wheather station - Radio station and TV Station
      
    
     CS7 - Exposure screen - MultiCast delegates- After exposure of an image. 
    
     * Delegates - (problem statement before delgates, Heavy coupling --> delegate == decoupling
     
    *** Use the Observer pattern when…
    • There are aspects to an abstraction that can vary independently.
    • Changes in one object need to be propagated to a selection of other objects, not all of them.
    • The object sending the changes does not need to know about the receivers.
    
     * 
     */
    class Program
    {
        public delegate void SampleDelegate();
        static void Main(string[] args)
        {
            #region Example 1
            WeatherStation oWeatherStation = new WeatherStation();

            //Registering TV Station to Weather Stattion
            TVStation oTVStation = new TVStation();
            oWeatherStation.registerObserver(oTVStation);

            //Notify all subscribers on the Rain Forecast
            oWeatherStation.notifyObservers(" Rain Forcasted in the Morning");
            System.Console.WriteLine("\n\n");


            //Registering Radio Station to Weather Stattion
            RadioStation RadioStation = new RadioStation();
            oWeatherStation.registerObserver(RadioStation);

            //Notify all subscribers on the Snow Forecast
            oWeatherStation.notifyObservers(" Snow Forecasted in the Afternoon");
            System.Console.WriteLine("\n\n");

            //Unregistering TV Station to Weather Stattion
            oWeatherStation.removeObserver(oTVStation);

            //Notify all subscribers on the Storm Forecast
            oWeatherStation.notifyObservers("Storm Forecasted in the Night");
            System.Console.WriteLine("\n\n");

            System.Console.ReadLine();

            #endregion

            #region Sample Multi Cast Delegates

            Program obj = new Program();
            obj.sss();
            

            #endregion
        }


        public void sss()
        {
            SampleDelegate delObj = Test1;
            delObj += Test2;

            Delegate[] arr = delObj.GetInvocationList();
        }

        public void Test1()
        {
            Console.WriteLine("test1");
        }
        public void Test2()
        {
            Console.WriteLine("test2");
        }
    }
}
