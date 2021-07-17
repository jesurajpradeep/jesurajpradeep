using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceCustomer
{
    // Point of creating a Generic interface, is to map to any kind of validation.

    //Design Pattern : Strategy Pattern. helps to choose algorithms dynamically.
    public interface IValidation<AnyType>
    {
        void Validate(AnyType customer);
    }
}
