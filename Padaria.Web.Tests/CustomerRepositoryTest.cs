using Microsoft.VisualStudio.TestTools.UnitTesting;
using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System.Linq;

namespace Padaria.Web.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private CustomerRepository _customerRepository = null;
        [TestMethod]
        public void CustomerRepository_Create_Success()
        {
            InstantiateCustomerRepository();
            Customer customer = new Customer { Name = "Mike rodrigues de lima", Phone = "15 32483712", CPF = "41288055803" };
            int actual = _customerRepository.Creates(customer);
            Assert.AreEqual(expected: 1, actual: actual);
        }
        [TestMethod]
        public void CustomerRepository_Update_Success()
        {
            InstantiateCustomerRepository();
            Customer customer = new Customer { CustomerID = 1, Name = "Natali", Phone = "15 32483712", CPF = "41288055803" };
            int actual = _customerRepository.Updates(customer);
            Assert.AreEqual(expected: 1, actual: actual);
        }
        [TestMethod]
        public void CustomerRepository_Delete_Success()
        {
            InstantiateCustomerRepository();
            Customer customer = new Customer { CustomerID = 2, Name = "Natali", Phone = "15 32483712", CPF = "41288055803" };
            int actual = _customerRepository.Deletes(customer);
            Assert.AreEqual(actual: actual, expected: 1);
        }
        [TestMethod]
        public void CustomerRepository_GetAll_Success()
        {
            InstantiateCustomerRepository();
            int actual = _customerRepository.GetAlls().Count();
            Assert.AreEqual(expected: 1, actual: actual);
        }
        private void InstantiateCustomerRepository() => _customerRepository = new CustomerRepository();

    }
}
