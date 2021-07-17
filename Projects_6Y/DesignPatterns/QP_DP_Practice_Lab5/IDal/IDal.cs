 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    // Design Pattern : Generic Repository pattern
    public interface IRepository<AnyType>
    {
        void Add(AnyType obj);

        void Update(AnyType obj);

        List<AnyType> Search();

        void Save();

        void SetUnitWork(IUow uow);
    }

    // Design Pattern : Unit of Work pattern
    public interface IUow
    {
        void Committ();
        void RollBack();
    }
}
