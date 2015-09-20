using Padaria.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Repository.Repository
{
    public class CreditRepository : DefaultRepository<Credit>
    {
        public DbSet<Credit> DataContext() => base.DbSet;
            
        public int Creates(Credit credit) => base.Create(credit);
        public List<Credit> GetAlls() => base.GetAll();

        public int Deletes(Credit credit) => base.Delete(credit);
    
    }
}
