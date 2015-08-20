namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typeOfPaymentWithoutPluralizarion : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TypeOfPayments", newName: "TypeOfPayment");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TypeOfPayment", newName: "TypeOfPayments");
        }
    }
}
