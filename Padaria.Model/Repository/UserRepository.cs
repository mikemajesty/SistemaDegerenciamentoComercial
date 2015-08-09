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
        public int Creates(Users user) => base.Create(user);
      
        public List<Users> GetAlls() => base.GetAll();
       
        public Users GetByIDs(int userID) => base.GetByID(userID);

        public int Deletes(Users user) => base.Delete(user);

        public int Updates(Users user) => base.Edit(user);

        void IDisposable.Dispose() => DbSet = null;
        
        
    }
}
