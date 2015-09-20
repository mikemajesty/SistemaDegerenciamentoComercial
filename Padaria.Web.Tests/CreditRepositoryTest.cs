using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Padaria.Web.Controllers;

namespace Padaria.Web.Tests
{
    [TestClass]
    [System.Runtime.InteropServices.Guid("A7A72FF6-3BD3-4B8F-866A-92E51430949A")]
    public class CreditRepositoryTest
    {
        [TestMethod]
        public void CreditController_Recieve_Sucess()
        {
            CreditController c = new CreditController();
            var list = c.Recieve();
        }
        [TestMethod]
        public void CreditController_FinishRecieve_Sucess()
        {
            CreditController c = new CreditController();
            var list = c.FinishRecieve(1,1);
        }
    }
}
