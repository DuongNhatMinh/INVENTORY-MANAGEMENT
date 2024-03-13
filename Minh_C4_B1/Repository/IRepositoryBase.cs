using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    interface IRepositoryBase<T>
    {
        int Length();

        List<T> Gets();
        T GetByIndex(int index);
        void Add(T entity);
    }
}
