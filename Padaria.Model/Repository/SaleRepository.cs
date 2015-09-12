using Padaria.Repository.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Padaria.Repository.Repository
{
    public class SaleRepository : DefaultRepository<Sale>
    {
        public DbSet<Sale> DataContext() => base.DbSet;

        public int Creates(Sale sale) => base.Create(sale);
        public List<Sale> GetAlls() => base.GetAll();
      
        //private SelectList GetUser(int userID = 0)
        //{
        //    return new SelectList(_userRepository.GetAlls(), "UserID", "UserName", userID);
        //}
        //private SelectList GetTypeOfPayment(int typeOfPayment = 0)
        //{
        //    return new SelectList(_typeOfPaymentRepository.GetAlls(), "TypeOfPaymentID", "Type", typeOfPayment);
        //}


    }
}
