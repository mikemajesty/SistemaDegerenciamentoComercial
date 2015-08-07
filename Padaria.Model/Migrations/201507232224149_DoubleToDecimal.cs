namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoubleToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "PurchasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "SalePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "SalePrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Product", "PurchasePrice", c => c.Double(nullable: false));
        }
    }
}
