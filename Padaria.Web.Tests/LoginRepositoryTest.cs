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
    public class LoginRepositoryTest
    {
        [TestMethod]
        public void LoginRepositoryTest_Login_Entry()
        {
            LoginRepository loginRepository = new LoginRepository();
            bool actual = loginRepository.Log(new Login { UserName="admin", PassWord="admin   " });
            Assert.IsTrue(actual);
        }
    }
}
