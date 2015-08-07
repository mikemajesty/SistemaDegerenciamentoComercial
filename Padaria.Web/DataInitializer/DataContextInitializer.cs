using Padaria.Repository.Data;
using Padaria.Repository.Entities;
using System.Data.Entity;
using System.Transactions;
namespace Padaria.Web.DataInitializer
{
    public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
    {
        /*public override void InitializeDatabase(DataContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
          , string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }
        protected override void Seed(DataContext context)
        {

            context.TypeOfRegistration.Add(new TypeOfRegistration { Name = "Unity" });
            context.Category.Add(new Category { Name = "Bread" });
            context.Product.Add(new Product { Name = "Choco IceCream", TypeOfRegistrationID = 1, CategoryID = 1, Code = "200", PurchasePrice = 1, SalePrice = 2, Stock = new Stock { ManageStock = true, MaximunQuantity = 200, MinimunQuantity = 20 } });
            context.SaveChanges();
            base.Seed(context);
        }*/

    }
}