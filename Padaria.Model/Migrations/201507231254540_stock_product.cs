namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock_product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Code = c.String(nullable: false, maxLength: 20),
                        CategoryID = c.Int(nullable: false),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        MinimunQuantity = c.Int(nullable: false),
                        MaximunQuantity = c.Int(nullable: false),
                        ManageStock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Category");
            DropIndex("dbo.Stocks", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Stocks");
            DropTable("dbo.Products");
        }
    }
}
