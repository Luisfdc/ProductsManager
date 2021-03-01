using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsManager.Interfaces
{
    public interface InterfaceGeneric<T> where T : class
    {
        void Add(T Entity);
        void Update(T Entity);
        void Delete(int Id);
        T GetEntity(int Id);
        List<T> List();
    }
}
