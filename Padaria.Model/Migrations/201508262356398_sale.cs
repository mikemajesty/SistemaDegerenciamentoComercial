namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        FullSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FullIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        TypeOfPaymentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.TypeOfPayment", t => t.TypeOfPaymentID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.TypeOfPaymentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "UserID", "dbo.Users");
            DropForeignKey("dbo.Sales", "TypeOfPaymentID", "dbo.TypeOfPayment");
            DropIndex("dbo.Sales", new[] { "TypeOfPaymentID" });
            DropIndex("dbo.Sales", new[] { "UserID" });
            DropTable("dbo.Sales");
        }
    }
}
