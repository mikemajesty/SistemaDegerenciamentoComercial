using Padaria.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Controller.Repositories
{
    public class RepositoryDefault<T> where T : class
    {
        private DataContext _dataContext;

        private void InstantiateDataContext()
        {
            _dataContext = new DataContext();        
        }

      



        public int Register(T register)
        {
            return 0;
            /*using (resource)
            {
                
            }
            InstantiateDataContext();
            _dataContext.Category.s();*/
           
        }
    }
}
