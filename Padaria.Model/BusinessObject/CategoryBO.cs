using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System.Linq;

namespace Padaria.Repository.BusinessObject
{
    public class CategoryBO : CategoryRepository
    {
        private const bool Existe = true;
        private const Category notFound = null;


        public bool VerifyIfAlreadyExistsInCreates(Category category)
        {
            bool returning = false;
            returning = DbSet.FirstOrDefault(c => c.Name == category.Name) == notFound ? true : false;
            return returning;
        }
        public bool VerifyIfAlreadyExistsInUpdates(Category category)
        {
            bool returning = false;
            returning = DbSet.Any(c => c.Name == category.Name) 
                != Existe && DbSet.Find(category.CategoryID).Name 
                != category.Name ? true : false;
            return returning;

        }
        public bool VerifyIfAlreadyExistsInProduct(Category category)
        {
            bool returning = false;

            Product product = DataContext.Product.FirstOrDefault(c => c.CategoryID == category.CategoryID);

            int categoryID = product == null ? 0 : product.CategoryID;

            returning = category.CategoryID != categoryID ? true : false;

            return returning;

        }
    }
}
