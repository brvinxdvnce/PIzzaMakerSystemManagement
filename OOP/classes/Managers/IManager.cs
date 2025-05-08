using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.classes.Managers
{
    internal interface IManager<T>
    {
        void print();
        void processing();
        void addElem(T o);
        void deleteElem(T o);
        void changeElem(T o1, T o2);
    }
}
