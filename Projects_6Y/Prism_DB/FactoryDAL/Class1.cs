using AdoDotnetDAL;
using Employee.Infrastructure;
using InterfaceDAL;
using Microsoft.Practices.Unity;

namespace FactoryDAL
{
    public static class FactoryDalLayer<AnyType> // Design pattern :- Simple factory pattern
    {
        private static IUnityContainer ObjectsofOurProjects = null;


        public static AnyType Create(string Type)
        {
            // Design pattern :- Lazy loading. Eager loading
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();

                ObjectsofOurProjects.RegisterType<IDal<EmployeeDetails>,
                    EmployeeDAL>("ADODal");
                /*ObjectsofOurProjects.RegisterType<IDal<EmployeeDetails>,
                    EfCustomerDal>("EFDal");*/
            }
            //Design pattern :-  RIP Replace If with Poly
            return ObjectsofOurProjects.Resolve<AnyType>(Type,
                                new ResolverOverride[]
                                {
                                       new ParameterOverride("_ConnectionString",
                                        @"Data Source=DS-PB02PSK6\SQL;Initial Catalog=TestDB;Integrated Security=True")
                                }); ;

            //Data Source=DS-PB02PSK6\SQL;Initial Catalog=TestDB;Integrated Security=True

        }
    }
}

