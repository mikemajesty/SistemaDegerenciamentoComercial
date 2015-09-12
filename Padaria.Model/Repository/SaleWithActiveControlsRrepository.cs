using Padaria.Repository.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace Padaria.Repository.Repository
{
    public class SaleWithActiveControlsRepository : DefaultRepository<SaleWithActiveControls>
    {
        public DbSet<SaleWithActiveControls> DataContext => base.DbSet;
        public int Creates(SaleWithActiveControls saleWithActiveControls) => base.Create(saleWithActiveControls);

        public int Deletes(List<Controls> controlList)
        {
            List<SaleWithActiveControls> salePaid = null;
            int returning = 0;

            controlList.ForEach(c => salePaid = DataContext.Where(d => d.Controls.Code == c.Code).ToList());
            
            salePaid?.ForEach(c => returning = base.Delete(c));
           
            return returning;

        }




        public int Edits(SaleWithActiveControls saleWithActiveControls) => base.Edit(saleWithActiveControls);
        public SaleWithActiveControls GetByIds(SaleWithActiveControls saleWithActiveControls) => base.GetByID(saleWithActiveControls.SaleWithActiveControlsID);
        public List<SaleWithActiveControls> GetAlls() => base.GetAll();
        public int GetQuantitys() => base.GetQuantity();

    }
}
