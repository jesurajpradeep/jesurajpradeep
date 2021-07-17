using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DependencyInjection
{
    //UI Layer
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer objcontainer = new UnityContainer();
            objcontainer.RegisterType<Customer>();
            objcontainer.RegisterType<IDal, SQLServerDAL>();
            objcontainer.RegisterType<IDal, OracleDAL>();

            Customer custObj = objcontainer.Resolve<Customer>(); // Resolve gives a new customer object
            custObj.CustomerName = "tt";
            custObj.Add();
        }
    }

    //Middle Layer
    public class Customer
    {
        /*
        private SQLServerDAL dal = new SQLServerDAL();
        private OracleDAL odal = new OracleDAL();
        */
        IDal dal;

        public string CustomerName { get; set; }

        public Customer(IDal obj)
        {
            dal = obj;
        }

        public void Add()
        {

        }
    }

    //SQL Server - DAL
    public class SQLServerDAL : IDal
    {
        public void Add()
        {
            Console.WriteLine("Sql server inserted");
        }
    }

    //Oracle DAL
    public class OracleDAL : IDal
    {
        public void Add()
        {
            Console.WriteLine("Sql server inserted");
        }
    }

    //IDAL
    public interface IDal
    {
        void Add();
    }

}
