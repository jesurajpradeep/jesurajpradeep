using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDal;
using System.Data.Entity; //DbContext
using InterfaceCustomer;
using MiddleLayer;
namespace EfDal
{
    // Design Pattern :- Adapter pattern (Class adapter pattern)
    // Here adapter pattern is part of the respository pattern
    public class EfDalAbstract<AnyType> : IRepository<AnyType>
        where AnyType : class
    {
        DbContext dbcontext = null;
        public EfDalAbstract() //: base("name=Conn") Connection string is initialized in UOW
        {
            dbcontext = new Euow(); // self contained transaction
        }

        public void Add(AnyType obj)
        {
            dbcontext.Set<AnyType>().Add(obj); // in memory commit
        }

        public void Save()
        {
            dbcontext.SaveChanges(); // EF Function -  Physical commit
        }

        public List<AnyType> Search()
        {
            return dbcontext.Set<AnyType>().
                AsQueryable<AnyType>().
                ToList<AnyType>();
        }

        public void SetUnitWork(IUow uow)
        {
            dbcontext = ((Euow)uow); // global transaction
        }

        public void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }
    }

    #region commented moved to UOW

    /*
    public class EfCustomerDal : EfDalAbstract<CustomerBase>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // mapping code
            // CustomerBase is an abstract class
            // interface is not supported here.
            modelBuilder.Entity<CustomerBase>().ToTable("tblCustomer");


            //since customerbase is an abstract class, we can't create objects. hence
            // we need to map it with the corresponding derived class.
            //Thats the reason why middle layer is added as a reference here in this project
            modelBuilder.Entity<CustomerBase>()
                .Map<Customer>(m => m.Requires("Customertype").HasValue("Customer"))
                .Map<LeadCustomer>(m => m.Requires("Customertype").HasValue("Lead"));
            modelBuilder.Entity<CustomerBase>().Ignore(t => t.CustomerType);


            /*
             * If we want to remove the middle layer from EF DAL, we can remove the class as abstract 
             * 
             * */
    /*
            }
        }

        */
    #endregion

    public class Euow : DbContext, IUow
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerBase>().ToTable("tblCustomer");

            modelBuilder.Entity<CustomerBase>()
                .Map<Customer>(m => m.Requires("Customertype").HasValue("Customer"))
                .Map<LeadCustomer>(m => m.Requires("Customertype").HasValue("Lead"));
            modelBuilder.Entity<CustomerBase>().Ignore(t => t.CustomerType);
        }
        public Euow() : base("name=Conn")
        {
        }
        public void Committ()
        {
            SaveChanges();
        }

        public void RollBack()
        {
            Dispose();
        }
    }

}

