using Padaria.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Repository.Repository
{
    public class SaleRepository : DefaultRepository<Sale>
    {
        public int Creates(Sale sale) => base.Create(sale);
    }
}
