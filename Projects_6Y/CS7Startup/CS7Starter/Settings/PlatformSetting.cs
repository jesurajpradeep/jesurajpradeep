using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS7Starter.Settings
{
    [Serializable]
    public class PlatformSetting
    {
        public PlatformSetting.LoginDomainSetting LoginDomain;

        public PlatformSetting() { }

        public bool DisplayLoginWhenUnlock { get; set; }
        public string Locale { get; set; }
        public double MonitorTimeOfSplashWindow { get; set; }
        public bool WindowActivateMode { get; set; }

        public class LoginDomainSetting
        {
            public LoginDomainSetting() { }

            public string DomainName { get; set; }
            public int ViewID { get; set; }
            public string WindowTitle { get; set; }
        }
    }

    [Serializable]
    public class ScreenInfo
    {
        public string Mode { get; set; }
    }
}
