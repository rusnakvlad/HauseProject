using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;

namespace DataAccesLayer.Repositories
{
    /// <summary>
    /// // CRUD Operation
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private AppDBContext context;
        public GenericRepository(AppDBContext context) => this.context = context;

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entityToDelete = context.Set<TEntity>().Find(id);
            context.Set<TEntity>().Remove(entityToDelete);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
