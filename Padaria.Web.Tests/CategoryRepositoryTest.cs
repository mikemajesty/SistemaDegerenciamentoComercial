using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Padaria.Repository.Repository;
using Padaria.Repository.Entities;

namespace Padaria.Web.Tests
{
  
    [TestClass]
    public class CategoryRepositoryTest
    {
        [TestMethod]
        public void CategoryRepository_Create_1()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            int expected = categoryRepository.Creates(new Category { Name = "Soda" });
            Assert.AreEqual(1, expected);
        }
        [TestMethod]
        public void CategoryRepository_List_0()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Assert.AreEqual(0, categoryRepository.GetAlls().Count());
        }
        [TestMethod]
        public void CategoryRepository_ListForName_1()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Assert.AreEqual(1, categoryRepository.GetByNames("Drink").Count());
        }
        [TestMethod]
        public void CategoryRepository_Delete_1()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Category category = categoryRepository.GetByIDs(2);
            Assert.AreEqual(1, categoryRepository.Deletes(category));
        }
        [TestMethod]
        public void CategoryRepository_Update_1()
        {

            CategoryRepository categoryRepository = new CategoryRepository();
            Category category = categoryRepository.GetByIDs(1);
            category = new Category() { CategoryID=1, Name="Cake" };
            Assert.AreEqual(1, categoryRepository.Update(category));
        }
    }
}
