using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Management;
namespace ProcessCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processlist = Process.GetProcesses();
            bool flag = true;

            foreach(Process theprocess in processlist)
            {
                if(theprocess.ProcessName.Contains("svc") == false)
                {
                   // string fullPath = theprocess.MainModule.FileName;
                    string fullPath = GetMainModuleFilepath(theprocess.Id);
                    
                    if (fullPath != null && fullPath.Contains(@"C:\KonicaMinolta"))
                    {
                        flag = false;
                        Console.WriteLine("Process Name: {0} Proces Path {1} Killed", theprocess.ProcessName, fullPath);
                        theprocess.Kill();
                    }
                }
            }
            if (flag == true)
            {
                Console.WriteLine("No process related to KM is running");
                Console.ReadLine();
            }
       }

        /// <summary>
        /// GetMainModuleFilepath
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        public static string GetMainModuleFilepath(int processId)
        {
            string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {
                    ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                    if (mo != null)
                    {
                        return (string)mo["ExecutablePath"];
                    }
                }
            }
            return string.Empty;
        }

    }
}
