using Microsoft.VisualStudio.TestTools.UnitTesting;
using Padaria.Repository.Entities;
using Padaria.Repository.Repository;

namespace Padaria.Web.Tests
{
    [TestClass]
    public class ControlRepositoryTest
    {
        [TestMethod]
        public void ControlRepositoryTest_Create_Seccess()
        {
            var cr = ControlRepository();
            int actual = cr.Creates(new Controls { Code = "1000" });
            Assert.AreEqual(1, actual);
        }
        public ControlRepository ControlRepository() => new ControlRepository();
        [TestMethod]
        public void ControlRepositoryTest_Delete_Sucess()
        {
            var cr = ControlRepository();
            int actual = cr.Deletes(new Controls{ Code="1000", ControlID=1  });
            Assert.AreEqual(1,actual);
        }
        [TestMethod]
        public void ControlRepositoryTest_Update_Success()
        {
            var cr = ControlRepository();
            Controls control = new Controls { ControlID = 3 , Code= "3000"};
            int actual = cr.Updates(control);
            Assert.AreEqual(expected:1,actual:actual);
        }
    }
}
