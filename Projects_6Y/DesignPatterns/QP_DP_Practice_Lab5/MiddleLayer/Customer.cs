using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;

namespace MiddleLayer
{

    public class LeadCustomer : CustomerBase
    {
        public LeadCustomer()
        {
            CustomerType = "Lead";
        }

        // When the data is going from client to the database, i want validation
        public LeadCustomer(IValidation<ICustomer> obj) : base(obj)
        {
        }
    }

    public class Customer : CustomerBase
    {
        public Customer()
        {
            CustomerType = "Customer";
        }
        // When the data is going from client to the database, i want validation
        public Customer(IValidation<ICustomer> obj) : base(obj)
        {
            // point of DI, is to inject the value from outside.
        }
    }
}
