using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiddleLayer;
using InterfaceCustomer;
using Microsoft.Practices.Unity;
using ValidationAlgorithm;

namespace FactoryCustomer
{
    public static class Factory<AnyType>
    {
        //private static Dictionary<string, ICustomer> customerCollection = new Dictionary<string, ICustomer>();
        private static IUnityContainer ObjectsOfOurProjects = null;

        static Factory()
        {
            // Design Pattern : centralization of object creation, simple factory pattern

        }

        public static AnyType CreateObject(string TypeOfOject)
        {
            /*
            if (customerCollection.Count == 0)
            {
                customerCollection.Add("Customer", (ICustomer)new Customer());
                customerCollection.Add("LeadCustomer", (ICustomer)new LeadCustomer());
            }

            */
            // Design Pattern : Getting rid of if condition, by using polymorphism is termed as RIP pattern.
            // Replace if with polymorphism. 

            //Design Pattern : Automated factory design pattern
            if (ObjectsOfOurProjects == null) // automated manual factory pattern.
            {
                ObjectsOfOurProjects = new UnityContainer();
                ObjectsOfOurProjects.RegisterType<CustomerBase, Customer>("Customer", new InjectionConstructor(new CustomerValidationAll()));
                // Dependency Injection :  Plug and Play
                ObjectsOfOurProjects.RegisterType<CustomerBase, LeadCustomer>("LeadCustomer", new InjectionConstructor(new LeadCustomerValidation()));
            }

            return ObjectsOfOurProjects.Resolve<AnyType>(TypeOfOject);
        }

        // todo: above code of linking connection string needs to be modified

    }

}

