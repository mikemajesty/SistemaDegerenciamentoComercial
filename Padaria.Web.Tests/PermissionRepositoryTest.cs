using Microsoft.VisualStudio.TestTools.UnitTesting;
using Padaria.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Web.Tests
{
    [TestClass]
    public class PermissionRepositoryTest
    {

        [TestMethod]
        public void PermissionRepositoryTest_GetAll_Success()
        {
            var permissionRepository = InstantiatePermissionRepositoryTest;
            int actual = permissionRepository.GetAlls().Count();
            Assert.AreEqual(3,actual);
        }

        private PermissionRepository InstantiatePermissionRepositoryTest
            => new PermissionRepository();
    }
}
