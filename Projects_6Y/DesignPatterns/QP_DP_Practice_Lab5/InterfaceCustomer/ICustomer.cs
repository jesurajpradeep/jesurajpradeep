using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace InterfaceCustomer
{
    public interface ICustomer
    {
        int Id { get; set; }
        string CustomerType { get; set; }
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
        string Address { get; set; }

        void Validate();
    }


    public class CustomerBase : ICustomer
    {
        private IValidation<ICustomer> validation = null;

        // below property represents uniqueness.
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }

        public string CustomerType
        {
            get; set;
        }


        public CustomerBase()
        {
            CustomerName = string.Empty;
            BillDate = DateTime.Now;
            BillAmount = 0;
            Address = string.Empty;
        }

        public CustomerBase(IValidation<ICustomer> obj)
        {
            validation = obj;
        }

        public virtual void Validate()
        {
            validation.Validate(this); ;
        }
    }
}
