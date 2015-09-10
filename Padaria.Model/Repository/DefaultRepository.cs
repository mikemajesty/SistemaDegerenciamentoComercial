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
        protected DbSet<T> DBSet { get;  set; }
        protected DefaultRepository()
        {          
            DBSet = (_dataContext = new DataContext()).Set<T>();
        }
        protected List<T> GetAll()
        {
            return DBSet.ToList();
        }
        protected T GetByID(int ID)
        {
            return DBSet.Find(ID);
        }
        protected int Edit(T entity)
        {
           
            _dataContext.Entry<T>(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        protected virtual int Create(T entity)
        {
            DBSet.Add(entity);
            return SaveChanges();
        }
        protected int Delete(T entity)
        {
            DBSet.Attach(entity);
            DBSet.Remove(entity);
            return SaveChanges();
        }
        protected int GetQuantity()
        {
            return DBSet.ToList().Count();
        }
        private int SaveChanges()
        {            
            return _dataContext.SaveChanges();
        }
    
        

    }
}
