using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptorPattern
{
    /* Purpose --> 
     * Allow a system to use classes of another system that is incompatible with it.
        Allow communication between new and already existing system which are independent to each other
        Ado.Net SqlAdapter, OracleAdapter, MySqlAdapter are best example of Adapter Pattern.
     * */
    interface IAdaptor // Interface for connecting to Adaptee
    {
        List<string> GetEmployeeList();
    }

    public class ThirdPartBillingSystem // Client
    {
        private IAdaptor empSource;

        internal ThirdPartBillingSystem(IAdaptor target)
        {
            this.empSource = target;
        }

        internal void ShowEmployeeList()
        {
            List<string> empList = empSource.GetEmployeeList();

            foreach (var item in empList)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class HRSystem   //Adaptee
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal string[][] GetEmployees()
        {
            string[][] employees = new string[4][];
            
            employees[0] = new string[] {"100","jj","chennai"};
            employees[1] = new string[] { "2100", "sss", "asdfsadf" };
            employees[2] = new string[] { "3100", "aaa", "333ds" };
            employees[3] = new string[] { "1", "aqqaa", "yy" };

            return employees;
        }
    }



    class EmployeeAdaptor : HRSystem, IAdaptor // Adaptor class
    {
        public List<string> GetEmployeeList()
        {
            string[][] employees = GetEmployees();
            List<string> empList = new List<string>();
            foreach (string[] emp in employees)
            {
                empList.Add(emp[0]);
                empList.Add(",");
                empList.Add(emp[1]);
                empList.Add(",");
                empList.Add(emp[2]);
                empList.Add(",");
            }
            return empList;
        }
    }

    
}
