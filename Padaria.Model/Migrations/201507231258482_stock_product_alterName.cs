namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock_product_alterName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.Stocks", newName: "Stock");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Stock", newName: "Stocks");
            RenameTable(name: "dbo.Product", newName: "Products");
        }
    }
}
