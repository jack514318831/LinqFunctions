using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.InterfaceSet
{
    public interface IBaseService<T>
    {
        T Add(T user);
        bool Delete(T user);
        bool Edit(T user);
        List<T> ShowData();
        T GetItemById(int Id);
    }
}
