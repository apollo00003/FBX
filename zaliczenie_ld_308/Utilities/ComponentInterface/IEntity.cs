using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaliczenie_ld_308
{
    interface IEntity<T>
    {
        T Create();
        T Show();
        List<T> ShowAll();
    }
}
