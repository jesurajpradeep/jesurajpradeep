using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
using System.Windows.Forms;

namespace ValidationAlgorithm
{
    public class CustomerValidationAll : IValidation<ICustomer>
    {
        public void Validate(ICustomer customer)
        {
            if (customer.CustomerName.Length == 0)
            {
                //throw new Exception("CustomerName required");
                MessageBox.Show("CustomerName required");
            }
            if (customer.PhoneNumber.Length == 0)
            {
                //throw new Exception("PhoneNumber required");
                MessageBox.Show("PhoneNumber required");
            }
            if (customer.BillAmount == 0)
            {
                //throw new Exception("BillAmount 0");
                MessageBox.Show("BillAmount 0");
            }

            if (customer.BillDate >= DateTime.Now)
            {
                //throw new Exception("BillDate 0");
                MessageBox.Show("BillDate Not valid");
            }

            if (customer.Address.Length == 0)
            {
                //throw new Exception("Address required");
                MessageBox.Show("Address required");
            }
        }
    }
    public class LeadCustomerValidation : IValidation<ICustomer>
    {
        public void Validate(ICustomer customer)
        {
            if (customer.CustomerName.Length == 0)
            {
                //throw new Exception("CustomerName required");
                MessageBox.Show("CustomerName required");

            }
            if (customer.PhoneNumber.Length == 0)
            {
                //throw new Exception("PhoneNumber required");
                MessageBox.Show("PhoneNumber required");
            }
        }
    }
}
