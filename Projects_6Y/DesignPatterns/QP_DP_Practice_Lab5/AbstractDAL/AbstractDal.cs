using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDal;

namespace AbstractDAL
{
    /// <summary>
    /// AbstractDal - Commmon Generic interface for all DA layers, Common code for all kinds of da layers
    /// </summary>
    /// <typeparam name="Anytype"></typeparam>
    public abstract class AbstractDal<Anytype> : IRepository<Anytype>
    {
        protected string ConnectionString = "";

        protected List<Anytype> AnyTypes = new List<Anytype>();

        public AbstractDal(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        public virtual void Add(Anytype obj)
        {
            AnyTypes.Add(obj); 
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }

        public virtual List<Anytype> Search()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(Anytype obj)
        {
            throw new NotImplementedException();
        }

        public virtual void SetUnitWork(IUow uow)
        {
            throw new NotImplementedException();
        }
    }
}
