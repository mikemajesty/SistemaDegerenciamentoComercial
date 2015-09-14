using Padaria.Repository.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Padaria.Repository.Repository
{
    public class CustomerRepository : DefaultRepository<Customer>
    {

        public DbSet<Customer> DataContext() => base.DbSet;

        public int Creates(Customer customer) => base.Create(customer);

        public int Updates(Customer customer) => base.Edit(customer);

        public int Deletes(Customer customer) => base.Delete(customer);

        public List<Customer> GetAlls() => base.GetAll();

        public Customer GetByIDs(int CustomerID) => base.GetByID(CustomerID);


        

    }
}
