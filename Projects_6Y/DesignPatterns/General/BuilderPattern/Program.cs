using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPattern
{
    /*
     * Builds a complex object by using a step by step approach
    When to use it?--->
    1. Need to create an object in several steps (a step by step approach).
    2. The creation of objects should be independent from the way the object's parts are assembled.
    3. Runtime control over the creation process is required
    */

    public enum ScreenType
    {
        ScreenType_TOUCH_CAPACITIVE,
        ScreenType_TOUCH_RESISTIVE,
        ScreenType_NON_TOUCH
    };

    public enum Battery
    {
        MAH_1000,
        MAH_1500,
        MAH_2000
    };

    public enum OperatingSystem
    {
        ANDROID,
        WINDOWS_MOBILE,
        WINDOWS_PHONE,
        SYMBIAN
    };

    public enum Stylus
    {
        YES,
        NO
    };

    class Program
    {
        static void Main(string[] args)
        {
            Manufacturer manufactObj = new Manufacturer();
            IPhoneBuilder phoneBuilder = null;

            phoneBuilder = new AndroidPhoneBuilder();
            manufactObj.Construct(phoneBuilder);

            AndroidPhoneBuilder temp = phoneBuilder as AndroidPhoneBuilder; 
            Console.WriteLine("A new Phone built:\n\n{0}", temp.ToString());
            
            phoneBuilder = new WindowsPhoneBuilder();
            WindowsPhoneBuilder temp2 = phoneBuilder as WindowsPhoneBuilder; 
            manufactObj.Construct(phoneBuilder);
            Console.WriteLine("A new Phone built:\n\n{0}", temp2.ToString());

        }
    }
}
