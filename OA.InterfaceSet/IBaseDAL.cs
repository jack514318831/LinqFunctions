using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.InterfaceSet
{
    public interface IBaseDAL<T>
    {
        T Add(T user);
        bool Delete(T user);
        bool Edit(T user);
        IEnumerable<T> Requery(Expression<Func<T,bool>> where);
    }
}
