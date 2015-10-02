using Padaria.Repository.Data;
using Padaria.Repository.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace Padaria.Repository.Repository
{
    public class StockRepository : DefaultRepository<Stock>
    {
        private DataContext _dataContext = null;
        public int Creates(Stock stock) => Create(stock);

        public Stock GetByIDs(int ID) => GetByID(ID);

        public int AddStock(Stock stock)
        {
            using (_dataContext = new DataContext())
            {
                Stock st = _dataContext.Stock.Find(stock.ProductID);
                stock.Quantity += st.Quantity;
                return base.Edit(stock);
            }
        }
        public int RemoveStock(Stock stock)
        {
            using (_dataContext = new DataContext())
            {
                Stock st = _dataContext.Stock.Find(stock.ProductID);
                st.Quantity -= stock.Quantity;
                stock.Quantity = st.Quantity;
                return base.Edit(stock);
            }
        }
        public int Update(Stock stock) => base.Edit(stock = stock.ManageStock == false ? new Stock
        {
            ProductID = stock.ProductID
        } : stock);

        public List<Stock> GetAlls() => base.GetAll().Where(c => c.ManageStock == true).ToList<Stock>();

    }
}
