using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure
{
    public class EmployeeDetails
    {
        public string EmployeeName { get; set; }

        public string EmployeeID { get; set; }

        public string Sex { get; set; }

    }

    public class MsgAddedEvent : PubSubEvent<EmployeeDetails>
    {
    }
}
