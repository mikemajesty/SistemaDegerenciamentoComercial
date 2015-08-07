using Microsoft.VisualStudio.TestTools.UnitTesting;
using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System.Linq;

namespace Padaria.Web.Tests
{
    [TestClass]
    public class ProductRepositoryTest
    {

        [TestMethod]
        public void ProductRepository_CreateProduct_2IfCreate()
        {
            ProductRepository produtoRepository = new ProductRepository();
            int actual = produtoRepository.Creates(new Product { Name = "Choco IceCream", CategoryID = 1, Code = "200", PurchasePrice = 1, SalePrice = 2, Stock = new Stock { ManageStock = true, MaximunQuantity = 200, MinimunQuantity = 20 } });
           // ClearConnection();
            Assert.AreEqual(2, actual);
        }
        [TestMethod]
        public void ProductRepository_UpdateProduct_1IfUpdate()
        {
            ProductRepository produtoRepository = new ProductRepository();
            int actual = produtoRepository.Updates(new Product { ProductID = 1, Name = "Gurte IceCream", CategoryID = 1, Code = "200", PurchasePrice = 1, SalePrice = 2, Stock = new Stock { ProductID = 1, ManageStock = true, MaximunQuantity = 200, MinimunQuantity = 20 } });
            //ClearConnection();
            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        public void ProductRepository_GetAll_1()
        {
            ProductRepository produtoRepository = new ProductRepository();
            int actual = produtoRepository.GetAlls().Count();
            //ClearConnection();
            Assert.AreEqual(0, actual);
        }
        [TestMethod]
        public void ProductRepository_GetByID_GurteIceCream()
        {
            ProductRepository produtoRepository = new ProductRepository();
            Product actual = produtoRepository.GetByIds(1);
            //ClearConnection();
            Assert.AreEqual("Gurte IceCream",actual.Name);
        }
        //private void ClearConnection()
        //{
        //    SqlConnection.ClearAllPools();
        //}
    }
}
