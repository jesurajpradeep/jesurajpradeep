using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiddleLayer;
using InterfaceCustomer;
using Microsoft.Practices.Unity;
//using ValidationAlgorithm;
using AdoDotnetDAL;
using IDal;
using EfDal;

namespace FactoryDAL
{
    public static class FactoryDALLayer<AnyType>
    {
        //private static Dictionary<string, ICustomer> customerCollection = new Dictionary<string, ICustomer>();
        private static IUnityContainer ObjectsOfOurProjects = null;

        static FactoryDALLayer()
        {
            // Design Pattern : centralization of object creation, simple factory pattern

        }

        public static AnyType CreateObject(string TypeOfOject)
        {
            if (ObjectsOfOurProjects == null) // automated manual factory pattern.
            {
                ObjectsOfOurProjects = new UnityContainer();
                ObjectsOfOurProjects.RegisterType<IRepository<CustomerBase>,
                    CustomerDAL>("ADODal");

                ObjectsOfOurProjects.RegisterType<IRepository<CustomerBase>,
                    EfDalAbstract<CustomerBase>>("EfDal");

                ObjectsOfOurProjects.RegisterType<IUow,AdoUow>("AdoUOW");
                ObjectsOfOurProjects.RegisterType<IUow, Euow>("EfUOW");
            }

            return ObjectsOfOurProjects.Resolve<AnyType>(TypeOfOject,
                new ResolverOverride[]
                {
                    new ParameterOverride("_ConnectionString",@"Data Source=JESUSOFI-PC\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True")
                }
                ); ;
            // todo: above code of linking connection string needs to be modified

        }

    }
}
