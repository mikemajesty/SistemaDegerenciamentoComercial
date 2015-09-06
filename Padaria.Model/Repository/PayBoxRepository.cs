using Padaria.Repository.Data;
using Padaria.Repository.Entities;
using System.Linq;


namespace Padaria.Repository.Repository
{
    public class PayBoxRepository : DefaultRepository<PayBox>
    {
        public DataContext _dataContext { get; }

        public PayBoxRepository()
        {
            _dataContext = new DataContext();
        }
        public int Creates(int userID = 0)
        {
            int returning = 0;
            if (this.GetQuantitys() == 0)
            {
                returning = base.Create(new PayBox { Value = 0, UserID = userID });
            }
            return returning;
        }
        public int GetQuantitys()
        {
            return base.GetQuantity();
        }
        public PayBox GetByIDs(int payBoxID)
        {
            return base.GetByID(payBoxID);
        }
        public int Update(PayBox payBox)
        {

            /*if (base.GetQuantity() == 0)
            {
                base.Create(payBox);
            }*/
            return base.Edit(payBox);
        }
        public decimal? GetValue()
        {
            PayBox paybox = _dataContext.PayBox.FirstOrDefault();
            return paybox.Value;
        }


    }
}
