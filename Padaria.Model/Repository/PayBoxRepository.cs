using Padaria.Repository.Data;
using Padaria.Repository.Entities;
using System.Linq;
using System;
using System.Data.Entity;

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
        public int GetQuantitys() => base.GetQuantity();

        public PayBox GetByIDs(int payBoxID) => base.GetByID(payBoxID);

        public int Update(PayBox payBox)
        {
            PayBox pB = null;
            int returning = 0;
            if ((pB = _dataContext.PayBox.FirstOrDefault()) != null)
            {
                payBox.PayBoxID = pB.PayBoxID;
                payBox.Value += pB.Value;
                returning = base.Edit(payBox);
            }
            return returning;

        }

        public decimal? GetValue()
        {
            PayBox paybox = _dataContext.PayBox.FirstOrDefault();
            return paybox.Value;
        }

        public int Close(PayBox payBox)
        {
            payBox.Value = 0;
            _dataContext.Entry<PayBox>(payBox).State = EntityState.Modified;
            return _dataContext.SaveChanges();
        }
    }
}
