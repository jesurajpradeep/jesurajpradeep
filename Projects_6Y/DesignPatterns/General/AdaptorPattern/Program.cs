using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptorPattern
{


    /*
     * 
     * class PluginAdapterAccessor
     * class PluginAdapter : IPluginCreator
     * IPluginCreator adapter = null;

			public PluginAdapter(IPluginCreator adapter)
			{
				this.adapter = adapter;

			}
     * */



    
    public class Adaptee
    {
        /// <summary>
        /// 
        /// </summary>
        internal void MethodB()
        {
            Console.WriteLine("Adaptee:: MethodB-Target Function");
        }
    }

    interface ITarget
    {
        void MethodA();

    }

    class Adaptor : Adaptee, ITarget
    {
        public int temp;
        public void MethodA()
        {
            Console.WriteLine("Adaptor Class-Function called");
            MethodB();
        }
    }

    class Client
    {
        private ITarget target;

        public Client(ITarget target)
        {
            this.target = target;
        }

        public void MakeRequest()
        {
            target.MethodA();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            #region Example - 1  Simple
            ITarget obj = new Adaptor();
            
            Client objClient = new Client(obj);
            objClient.MakeRequest();
            #endregion

            #region Example - 2
            /*
            IAdaptor adaptorObj = new EmployeeAdaptor();
            ThirdPartBillingSystem obj2 = new ThirdPartBillingSystem(adaptorObj);
            obj2.ShowEmployeeList();
            */
            #endregion



        }
    }
}

