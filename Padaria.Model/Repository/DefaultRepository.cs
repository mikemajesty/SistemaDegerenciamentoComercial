using Padaria.Repository.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Padaria.Repository.Repository
{
    public class DefaultRepository<T> where T : class
    {
        private readonly DataContext _dataContext = null;
        protected DbSet<T> DbSet { get;  set; }
        protected DefaultRepository()
        {          
            DbSet = (_dataContext = new DataContext()).Set<T>();
        }
        protected List<T> GetAll()
        {
            return DbSet.ToList();
        }
        protected T GetByID(int ID)
        {
            return DbSet.Find(ID);
        }
        protected int Edit(T entity)
        {
           
            _dataContext.Entry<T>(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        protected  int Create(T entity)
        {
            DbSet.Add(entity);
            return SaveChanges();
        }
        protected int Delete(T entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
            return SaveChanges();
        }
        protected int GetQuantity()
        {
            return DbSet.ToList().Count();
        }
        private int SaveChanges()
        {            
            return _dataContext.SaveChanges();
        }
    
        

    }
}
