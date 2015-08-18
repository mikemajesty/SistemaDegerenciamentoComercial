using Padaria.Repository.Data;
using Padaria.Repository.Entities;
using System.Linq;

namespace Padaria.Repository.Repository
{
    public class LoginRepository
    {
        private DataContext _dataContext {  get; }
        private const bool NonExits = false, Exists = true;

        public LoginRepository()
        {
            _dataContext = new DataContext();
        }
        public bool Log(Login login)
        {
            return _dataContext.Users.FirstOrDefault(c => c.UserName.Equals(login.UserName)
                && c.PassWord.Equals(login.PassWord)) == null ? NonExits : Exists;
        }
       


    }
}
