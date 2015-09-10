using Padaria.Repository.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace Padaria.Repository.Repository
{
    public class SaleWithActiveControlsRepository : DefaultRepository<SaleWithActiveControls>
    {
        public DbSet<SaleWithActiveControls> DataContext => base.DBSet;
        public int Creates(SaleWithActiveControls saleWithActiveControls) => base.Create(saleWithActiveControls);

        public int Deletes(List<Controls> controlList)
        {
            List<SaleWithActiveControls> salePaid = null;
            int returning = 0;
            foreach (var item in controlList)
            {
                salePaid = DataContext.Where(c => c.Controls.Code == item.Code).ToList();
            }
            if (salePaid != null)
            {
                foreach (var item in salePaid)
                {
                    returning = base.Delete(item);

                }
            }
            return returning;
           
        }
            
        
            
            
        public int Edits(SaleWithActiveControls saleWithActiveControls) => base.Edit(saleWithActiveControls);
        public SaleWithActiveControls GetByIds(SaleWithActiveControls saleWithActiveControls) => base.GetByID(saleWithActiveControls.SaleWithActiveControlsID);
        public List<SaleWithActiveControls> GetAlls() => base.GetAll();
        public int GetQuantitys() => base.GetQuantity();

    }
}
