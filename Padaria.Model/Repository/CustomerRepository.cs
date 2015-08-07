using Padaria.Repository.Entities;
using System.Collections.Generic;

namespace Padaria.Repository.Repository
{
    public class CustomerRepository : DefaultRepository<Customer>
    {
        public int Creates(Customer customer) => base.Create(customer);

        public int Updates(Customer customer) => base.Edit(customer);

        public int Deletes(Customer customer) => base.Delete(customer);

        public List<Customer> GetAlls() => base.GetAll();
    }
}
