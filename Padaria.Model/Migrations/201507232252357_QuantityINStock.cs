namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuantityINStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stock", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stock", "Quantity");
        }
    }
}
