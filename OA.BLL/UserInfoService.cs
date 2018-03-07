using OA.EFDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.InterfaceSet;
using OA.EFModel;

namespace OA.BLL
{
    public class UserInfoService : BaseService<UserInfoSet, IUserInfoDAL>, IUserService
    {
        IUserInfoDAL DAL = Factory.GetUserInfoDal();
        public UserInfoSet GetItemById(int Id)
        {
            return DAL.Requery(u => u.UserId == Id).First();
        }
    }
}
