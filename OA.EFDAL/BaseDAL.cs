using OA.EFModel;
using OA.InterfaceSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.EFDAL
{
    public class BaseDAL<T>:IBaseDAL<T> where T:class
    {
        LinqFunctionsDBEntities DBcontext =DBSession.GetDbContext();
        public virtual T Add(T item)
        {
            DBcontext.Set<T>().Add(item);
            return item;
        }

        public virtual bool Delete(T item)
        {
            DBcontext.Set<T>().Attach(item);
            DBcontext.Entry<T>(item).State = System.Data.Entity.EntityState.Deleted;
            return true;
        }

        public virtual bool Edit(T item)
        {
            DBcontext.Set<T>().Attach(item);
            DBcontext.Entry<T>(item).State = System.Data.Entity.EntityState.Modified;
            return true;
        }

        public virtual IEnumerable<T> Requery(Expression<Func<T,bool>> where)
        {
           return  DBcontext.Set<T>().Where(where).AsEnumerable();
        }
    }
}
