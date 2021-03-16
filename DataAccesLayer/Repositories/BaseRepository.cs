using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using System.Linq;
using DataAccesLayer.EF;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.Repositories
{
    public class BaseRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDBContext context;
        protected readonly DbSet<T> entity;
        
        public BaseRepository(AppDBContext context)
        {
            this.context = context;
            this.entity = context.Set<T>();
        }
        //----------------------------------------- Create ---------------------------------------------//
        public T Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this.entity.Add(entity);
            context.SaveChanges();
            return entity;
        }
        //----------------------------------------- Delete ---------------------------------------------//
        public bool Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (this.entity.Contains(entity))
            {
                this.entity.Remove(entity);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        //----------------------------------------- GetAll ---------------------------------------------//
        public IQueryable<T> GetAll()
        {
            return entity;
        }
        //----------------------------------------- GetById ---------------------------------------------//
        public T GetById(int id)
        {
            return entity.Find(id);
        }
        //----------------------------------------- Save ---------------------------------------------//
        public void Save()
        {
            throw new NotImplementedException();
        }
        //----------------------------------------- Update ---------------------------------------------//
        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }
}
