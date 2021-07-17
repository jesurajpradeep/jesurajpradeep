using CommonDAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using Employee.Infrastructure;
using InterfaceDAL;

namespace AdoDotnetDAL
{
    public abstract class TemplateADO<AnyType> : AbstractDal<AnyType>
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;
        public TemplateADO(string _ConnectionString)
            : base(_ConnectionString)
        {


        }

        [System.Obsolete]
        private void Open()
        {
            objConn = new SqlConnection(ConnectionString);
            objConn.Open();
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
        }
        protected abstract void ExecuteCommand(AnyType obj); // Child classes 
        protected abstract List<AnyType> ExecuteCommand(); // Child classes 
        private void Close()
        {
            objConn.Close();
        }
        // Design pattern :- Template pattern
        public void Execute(AnyType obj) // Fixed Sequence Insert
        {
            Open();
            ExecuteCommand(obj);
            Close();
        }
        public List<AnyType> Execute() // Fixed Sequence select
        {
            List<AnyType> objTypes = null;
            Open();
            objTypes = ExecuteCommand();
            Close();
            return objTypes;
        }
        public override void Save()
        {
            foreach (AnyType o in AnyTypes)
            {
                Execute(o);
            }
        }
        public override List<AnyType> Search()
        {
            return Execute();
        }
    }

    public class EmployeeDAL : TemplateADO<EmployeeDetails>, IDal<EmployeeDetails>
    {
        public EmployeeDAL(string _ConnectionString)
            : base(_ConnectionString)
        {

        }
        protected override List<EmployeeDetails> ExecuteCommand()
        {
             objCommand.CommandText = "select * from tblEmployee";
             SqlDataReader dr = null;
             dr = objCommand.ExecuteReader();
             List<EmployeeDetails> emplList = new List<EmployeeDetails>();
             while (dr.Read())
             {
                //EmployeeDetails icust = Factory<EmployeeDetails>.Create("Customer");
                EmployeeDetails emp = new EmployeeDetails();
                 emp.EmployeeID = dr["EmployeeID"].ToString();
                 emp.EmployeeName = dr["EmployeeName"].ToString();
                 emp.Sex = dr["Sex"].ToString();

                emplList.Add(emp);
             }
             return emplList;
        }

        protected override void ExecuteCommand(EmployeeDetails obj)
        {
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "spInsertEmployee";

            SqlParameter paramEmpID = new SqlParameter
            {
                ParameterName = "@EmployeeID",
                Value = obj.EmployeeID
            };

            objCommand.Parameters.Add(paramEmpID);

            SqlParameter paramEmpName = new SqlParameter
            {
                ParameterName = "@EmployeeName",
                Value = obj.EmployeeName
            };

            objCommand.Parameters.Add(paramEmpName);

            SqlParameter paramempSex = new SqlParameter
            {
                ParameterName = "@Sex",
                Value = obj.Sex
            };

            objCommand.Parameters.Add(paramempSex);

            objCommand.ExecuteNonQuery();

        }
    }

}
