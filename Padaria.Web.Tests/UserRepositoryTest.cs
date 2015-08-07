using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Padaria.Repository.Repository;
using Padaria.Repository.Entities;
namespace Padaria.Web.Tests
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void UserRepositoryTest_CreateUser_Success()
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                int  actual = userRepository.Creates(new Users { UserName = "adminim", FullName = "Mike rodrigues de lima", PassWord = "admin", ConPassWord = "admin", PermissionID = 1, LastAccess = DateTime.Today });
                Assert.AreEqual(1, actual);
                
            }
            catch (Exception erro)
            {

                Console.WriteLine(erro.Message);
            }
           
        }
        [TestMethod]
        public void UserRepositoryTest_GetAll_Success()
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                int actual = userRepository.GetAlls().Count();
                Assert.AreEqual(5,actual);
               
            }
            catch (Exception erro)
            {

                Console.WriteLine(erro.Message);
            }

        }
    }
}
