
namespace Padaria.Repository.Entities
{
    public class SaleWithActiveControls
    {
        public int SaleWithActiveControlsID { get; set; }
        public int ProductID { get; set; }
        public int ControlsID { get; set; }
        public int Quantity { get; set; }
        public decimal FullPrice { get; set; }
        public virtual Controls Controls { get; set; }
        public virtual Product Product { get; set; }

    }
}
