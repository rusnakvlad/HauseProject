using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccesLayer.Interfaces
{
    interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        void Save();
    }
}
