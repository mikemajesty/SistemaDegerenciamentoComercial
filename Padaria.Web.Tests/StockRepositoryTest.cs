using Microsoft.VisualStudio.TestTools.UnitTesting;
using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Web.Tests
{
    [TestClass]
    public class StockRepositoryTest
    {
        [TestMethod]
        public void StockRepositoryTest_CreateStock_1()
        {
            StockRepository stoqueRepository = new StockRepository();
            int actual = stoqueRepository.Creates(new Stock { ManageStock = true, MaximunQuantity = 20, MinimunQuantity = 100, ProductID = 2, Quantity = 50 });
            Assert.AreEqual(expected: 1, actual: actual);
        }
        [TestMethod]
        public void StockRepositoryTest_UpdateStock_1()
        {
            StockRepository stoqueRepository = new StockRepository();
            int actual = stoqueRepository.Update(new Stock { ManageStock = true, MaximunQuantity = 20, MinimunQuantity = 100, ProductID = 3, Quantity = 50 });
            Assert.AreEqual(expected: 1, actual: actual, message: "Fail");
        }
        [TestMethod]
        public void StockRepositoryTest_AddStock_Sucess()
        {
            try
            {
                StockRepository stoqueRepository = new StockRepository();
                Stock stock = stoqueRepository.GetByIDs(1);             
                stock.Quantity = 10;
                int actual = stoqueRepository.AddStock(stock);
                Assert.AreEqual(1, actual);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
