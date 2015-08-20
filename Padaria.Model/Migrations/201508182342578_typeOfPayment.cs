namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typeOfPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeOfPayments",
                c => new
                    {
                        TypeOfPaymentID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TypeOfPaymentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypeOfPayments");
        }
    }
}
