using OA.EFDAL;
using OA.InterfaceSet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL
{
    public class Factory
    {
        public static IUserInfoDAL GetUserInfoDal()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\bin\" + ConfigurationManager.AppSettings["InfoDAL"];
            Assembly asm = Assembly.LoadFile(path);
            Type DALtype = asm.GetType("OA.EFDAL.UserInfoDAL");
            ConstructorInfo contstrutor = DALtype.GetConstructor(new Type[] { });
            IUserInfoDAL DAL = contstrutor.Invoke(new object[] {}) as IUserInfoDAL;
            return DAL;
        }

        public static IClassInfoDAL GetClassInfoDal()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\bin\" + ConfigurationManager.AppSettings["InfoDAL"];
            Assembly asm = Assembly.LoadFile(path);
            Type DALtype = asm.GetType("OA.EFDAL.ClassInfoDAL");
            ConstructorInfo contstrutor = DALtype.GetConstructor(new Type[] { });
            IClassInfoDAL DAL = contstrutor.Invoke(new object[] { }) as IClassInfoDAL;
            return DAL;
        }
    }
}
