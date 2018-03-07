using OA.EFModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA.EFDAL
{
    public class DBSession
    {
        public static LinqFunctionsDBEntities Current { get; set; }

        public static LinqFunctionsDBEntities GetDbContext()
        {
            Current = CallContext.GetData("Current") as LinqFunctionsDBEntities;
            if (Current == null)
            {
                Current = new LinqFunctionsDBEntities();
                CallContext.SetData("Current", Current);
            }
            return Current;
        }

        public static void SaveChanges()
        {
            Current.SaveChanges();
        }
    }
}
