using Padaria.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Repository.Repository
{
    public class UserRepository : DefaultRepository<Users>, IDisposable
    {
        public int Creates(Users user)
        {
            return base.Create(user);
        }
        public List<Users> GetAlls()
        {
            return base.GetAll();
        }
        void IDisposable.Dispose()
        {
            DbSet = null;
        }
    }
}
