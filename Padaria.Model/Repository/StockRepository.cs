using Padaria.Repository.Data;
using Padaria.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Padaria.Repository.Repository
{
    public class StockRepository : DefaultRepository<Stock>
    {
        private DataContext _dataContext = null;
        public int Creates(Stock stock)
        {
            return Create(stock);
        }
        public Stock GetByIDs(int ID)
        {
            return GetByID(ID);
        }
        public int Update(Stock stock)
        {
            using (_dataContext = new DataContext())
            {
                _dataContext.Entry(stock).State = EntityState.Modified;
                return _dataContext.SaveChanges();
            }
        }

    }
}
