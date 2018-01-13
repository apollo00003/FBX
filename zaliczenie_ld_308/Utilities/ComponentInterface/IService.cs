using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaliczenie_ld_308.Entities;

namespace zaliczenie_ld_308
{
    interface IService<T>
    {
        bool Create(T entity);
        T Get(int id);
        T Get(string name);
        T Get(T entity);
        List<T> GetAll();
    }
}
