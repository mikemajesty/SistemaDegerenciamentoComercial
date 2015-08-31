using Padaria.Repository.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Padaria.Repository.Repository
{
    public class SaleWithActiveControlsRepository : DefaultRepository<SaleWithActiveControls>
    {
        public DbSet<SaleWithActiveControls> DataContext => base.DbSet;
        public int Creates(SaleWithActiveControls saleWithActiveControls) => base.Create(saleWithActiveControls);
        public int Deletes(SaleWithActiveControls saleWithActiveControls) => base.Delete(saleWithActiveControls);
        public int Edits(SaleWithActiveControls saleWithActiveControls) => base.Edit(saleWithActiveControls);
        public SaleWithActiveControls GetByIds(SaleWithActiveControls saleWithActiveControls) => base.GetByID(saleWithActiveControls.SaleWithActiveControlsID);
        public List<SaleWithActiveControls> GetAlls() => base.GetAll();
        public int GetQuantitys() => base.GetQuantity();
    }
}
