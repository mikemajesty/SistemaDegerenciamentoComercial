using Padaria.Repository.Data;
using Padaria.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Repository.Repository
{
    public class ProductRepository : DefaultRepository<Product>
    {
        public ProductRepository()
        {
            DataContext = new DataContext();
        }
        private DataContext _dataContext = null;
        public DataContext DataContext { get; set; }
        public int Creates(Product product)
        {
            return base.Create(product);
        }
        public int Updates(Product product)
        {
            using (_dataContext = new DataContext())
            {
                _dataContext.Entry(product).State = EntityState.Modified;
                return SaveChanges();
            }
        }
        public List<Product> GetAlls()
        {
            return GetAll();
        }
        public Product GetByIds(int ID)
        {
            return GetByID(ID);
        }
        private int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }
        public int Deletes(Product product)
        {
            return Delete(product);
        }
    }
}
