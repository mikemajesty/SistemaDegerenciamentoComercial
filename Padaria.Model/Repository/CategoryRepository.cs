using Padaria.Repository.BusinessObject;
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
    public class CategoryRepository : DefaultRepository<Category>
    {
        // private DataContext _dataContext = null;
        private CategoryBO _categoryBO = null;
        private const bool notExists = true;
        private const int notCreate = 0;
        public CategoryRepository()
        {
            DataContext = new DataContext();
        }
        private void InstantiateCategoryBO()
        {
            _categoryBO = new CategoryBO();
        }
        public DataContext DataContext { get; set; }
        public IQueryable<Category> GetByNames(string name)
        {
            return DbSet.Where(a => a.Name.Contains(name));
        }
        public int Creates(Category category)
        {
            InstantiateCategoryBO();
            if (_categoryBO.VerifyIfAlreadyExistsInCreates(category) == notExists)
            {
                return Create(category);
            }
            return notCreate;
        }
        public List<Category> GetAlls()
        {
            return GetAll();
        }
        public Category GetByIDs(int ID)
        {
            return GetByID(ID);
        }
        public int Deletes(Category category)
        {
            InstantiateCategoryBO();
            if (_categoryBO.VerifyIfAlreadyExistsInProduct(category) == notExists)
            {
                return Delete(category);
            }
            return notCreate;

        }
        public int Update(Category category)
        {
            InstantiateCategoryBO();
            int returning = 0;
            if (_categoryBO.VerifyIfAlreadyExistsInUpdates(category) == notExists)
            {
                returning = base.Edit(category);             
            }
            return returning;
        }
        private int SaveChanges()
        {
            return DataContext.SaveChanges();
        }




    }
}
