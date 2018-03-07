using OA.EFDAL;
using OA.EFModel;
using OA.InterfaceSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL
{
    public class BaseService<T,D> where T: class
                                  where D: class
    {
        IBaseDAL<T> DAL = new BaseDAL<T>();
        public virtual List<T> ShowData()
        {
            IEnumerable<T> list = DAL.Requery(u=>true);
            List<T> result = list.ToList();
            return result;
        }

        public virtual T Add(T item)
        {
            DAL.Add(item);
            DBSession.SaveChanges();
            return item;
        }

        public virtual bool Delete(T item)
        {
            DAL.Delete(item);
            DBSession.SaveChanges();
            return true;
        }

        public virtual bool Edit(T item)
        {
            DAL.Edit(item);
            DBSession.SaveChanges();
            return true;
        }
    }
}
