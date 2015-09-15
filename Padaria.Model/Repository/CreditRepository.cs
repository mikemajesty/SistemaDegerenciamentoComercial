using Padaria.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Repository.Repository
{
    public class CreditRepository : DefaultRepository<Credit>
    {

        public int Creates(Credit credit) => base.Create(credit);


    
        

    }
}
