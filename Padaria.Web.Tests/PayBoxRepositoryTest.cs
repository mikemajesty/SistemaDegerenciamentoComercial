using Microsoft.VisualStudio.TestTools.UnitTesting;
using Padaria.Repository.Data;
using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using Padaria.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Web.Tests
{
    [TestClass]
    public class PayBoxRepositoryTest
    {
        [TestMethod]
        public void PayBoxRepositoryTest_ClosePayBox_Success()
        {
            //PayBoxController padaria = new PayBoxController();
            //padaria.ClosePayBox();
            //Assert.AreEqual(0, pb.Value);
        }

        [TestMethod]
        public void PayBoxRepositoryTest_GetValue_Equals0()
        {
            PayBoxRepository payBox = new PayBoxRepository();
            PayBox pb = payBox.GetByIDs(8);
            Assert.AreEqual(0,pb.Value);
        }
        [TestMethod]
        public void PayBoxRepositoryTest_GetQuantity_Equals1()
        {
            PayBoxRepository payBox = new PayBoxRepository();
            int actual = payBox.GetQuantitys();
            Assert.AreEqual(1,actual);
        }
        [TestMethod]
        public void PayBoxRepositoryTest_UpdatePayBox_Equals1()
        {
            //PayBoxRepository payBox = new PayBoxRepository();
            //PayBox pb = payBox._dataContext.PayBox.Find(8);
            //pb.Value = 10;
            //payBox.Update(pb);
            //Assert.AreEqual(20,pb.Value);
        }
    }
}
