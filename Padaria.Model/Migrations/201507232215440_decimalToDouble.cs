namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimalToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "SalePrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Product", "PurchasePrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Product", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Product", "PurchasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "SalePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
