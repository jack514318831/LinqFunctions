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
    public class ClassInfoService : BaseService<ClassInfo, IClassInfoDAL>, IClassInfoService
    {
        IClassInfoDAL DAL = Factory.GetClassInfoDal();
        public ClassInfo GetItemById(int Id)
        {
            return DAL.Requery(u => u.ClassId == Id).First();
        }
    }
}
