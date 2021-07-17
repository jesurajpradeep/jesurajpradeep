using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using InterfaceCustomer;
using AbstractDAL;
using FactoryCustomer;
using IDal;
using System.Configuration;

namespace AdoDotnetDAL
{
    // Design Pattern : Template pattern : fixed sequence, but child classes  have the opportunity to override the methods
    // this is termed as template pattern


        // this class will be having the common code, which is very specific to ADO.net 
    public abstract class TemplateADO<AnyType> : AbstractDal<AnyType>
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;
        IUow uowObj = null;
        public TemplateADO(string _ConnectionString) : base(_ConnectionString)
        {


        }
        public override void SetUnitWork(IUow uow)
        {
            uowObj = uow;
            objConn = ((AdoUow)uow).Connection;
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
            objCommand.Transaction = ((AdoUow)uow).Transaction;
        }

        private void Open()
        {

            if(objConn == null) // if its having value, use UOW transaction
            {
                objConn = new SqlConnection(ConnectionString);
                objConn.Open();
                objCommand = new SqlCommand();
                objCommand.Connection = objConn;
            }
            
        }

        private void Close()
        {
            if (uowObj == null) // todo : findout why
            {
                objConn.Close();
            }
            
        }

        protected abstract void ExecuteCommand(AnyType obj); // child classes

        protected abstract List<AnyType> ExecuteCommand(); // child classes

        // Design Pattern : Template Pattern
        private void Execute(AnyType obj)  // fixed sequence for insert
        {
            Open();
            ExecuteCommand(obj);
            Close();
        }

        private List<AnyType> Execute()  // fixed sequence for select
        {
            List<AnyType> result = null;
            Open();
            result = ExecuteCommand();
            Close();
            return result;
        }

        public override List<AnyType> Search()
        {
            return Execute();
        }


        public override void Save()
        {
            foreach(AnyType o in AnyTypes)
            {
                Execute(o);
            }
        }
    }

    public class CustomerDAL : TemplateADO<CustomerBase>
    {
        public CustomerDAL(string _ConnectionString) : base(_ConnectionString)
        {
        }

       
        protected override List<CustomerBase> ExecuteCommand()
        {
            objCommand.CommandText = "select * from tblCustomer";
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();

            List<CustomerBase> custList = new List<CustomerBase>();
            while (dr.Read())
            {
                CustomerBase icust = Factory<CustomerBase>.CreateObject("Customer");
                icust.CustomerType = dr["CustomerType"].ToString();
                icust.CustomerName = dr["CustomerName"].ToString();
                icust.Address = dr["Address"].ToString();
                icust.PhoneNumber = dr["PhoneNumber"].ToString();

                icust.BillDate = Convert.ToDateTime(dr["BillDate"]);
                icust.BillAmount = Convert.ToDecimal(dr["BillAmount"]);


                custList.Add(icust);
            }

            return custList;
        }

        protected override void ExecuteCommand(CustomerBase custObj)
        {
            try
            {
                // child 
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "InsertCustomerProc";


                SqlParameter paramCustType = new SqlParameter
                {
                    ParameterName = "@CustomerType",
                    Value = custObj.CustomerType
                };
                objCommand.Parameters.Add(paramCustType);

                SqlParameter paramCustName = new SqlParameter
                {
                    ParameterName = "@CustomerName",
                    Value = custObj.CustomerName
                };
                objCommand.Parameters.Add(paramCustName);

                SqlParameter paramBillDate = new SqlParameter
                {
                    ParameterName = "@BillDate",
                    Value = custObj.BillDate
                };
                objCommand.Parameters.Add(paramBillDate);

                SqlParameter paramBillAmt = new SqlParameter
                {
                    ParameterName = "@BillAmount",
                    Value = custObj.BillAmount
                };
                objCommand.Parameters.Add(paramBillAmt);

                SqlParameter paramPhoneNumber = new SqlParameter
                {
                    ParameterName = "@PhoneNumber",
                    Value = custObj.PhoneNumber
                };
                objCommand.Parameters.Add(paramPhoneNumber);

                SqlParameter paramAddress = new SqlParameter
                {
                    ParameterName = "@Address",
                    Value = custObj.Address
                };
                objCommand.Parameters.Add(paramAddress);

                objCommand.ExecuteNonQuery();
            }

            catch(Exception ex)
            {

            }
            


        }
    }

    public class AdoUow : IUow
    {
        public SqlConnection Connection { get; set; }

        public SqlTransaction Transaction { get; set; }

        public AdoUow()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            Connection.Open();
            Transaction = Connection.BeginTransaction(); 
        }


        public void Committ()
        {
            Transaction.Commit();
            Connection.Close();
        }

        public void RollBack()  // Design Pattern : Object  Adapter pattern
        {
            Transaction.Rollback();
            Connection.Close();
        }
    }
}
