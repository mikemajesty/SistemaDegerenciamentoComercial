namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleWithActiveControls : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Control", newName: "Controls");
            RenameTable(name: "dbo.Sales", newName: "Sale");
            CreateTable(
                "dbo.SaleWithActiveControls",
                c => new
                    {
                        SaleWithActiveControlsID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ControlsID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        FullPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Controls_ControlID = c.Int(),
                    })
                .PrimaryKey(t => t.SaleWithActiveControlsID)
                .ForeignKey("dbo.Controls", t => t.Controls_ControlID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.Controls_ControlID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleWithActiveControls", "ProductID", "dbo.Product");
            DropForeignKey("dbo.SaleWithActiveControls", "Controls_ControlID", "dbo.Controls");
            DropIndex("dbo.SaleWithActiveControls", new[] { "Controls_ControlID" });
            DropIndex("dbo.SaleWithActiveControls", new[] { "ProductID" });
            DropTable("dbo.SaleWithActiveControls");
            RenameTable(name: "dbo.Sale", newName: "Sales");
            RenameTable(name: "dbo.Controls", newName: "Control");
        }
    }
}
