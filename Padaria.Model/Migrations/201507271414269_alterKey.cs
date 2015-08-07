namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "TypeOfRegistration_TypeOfRegistrationID", "dbo.TypeOfRegistration");
            DropIndex("dbo.Product", new[] { "TypeOfRegistration_TypeOfRegistrationID" });
            RenameColumn(table: "dbo.Product", name: "TypeOfRegistration_TypeOfRegistrationID", newName: "TypeOfRegistrationID");
            AlterColumn("dbo.Product", "TypeOfRegistrationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "TypeOfRegistrationID");
            AddForeignKey("dbo.Product", "TypeOfRegistrationID", "dbo.TypeOfRegistration", "TypeOfRegistrationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "TypeOfRegistrationID", "dbo.TypeOfRegistration");
            DropIndex("dbo.Product", new[] { "TypeOfRegistrationID" });
            AlterColumn("dbo.Product", "TypeOfRegistrationID", c => c.Int());
            RenameColumn(table: "dbo.Product", name: "TypeOfRegistrationID", newName: "TypeOfRegistration_TypeOfRegistrationID");
            CreateIndex("dbo.Product", "TypeOfRegistration_TypeOfRegistrationID");
            AddForeignKey("dbo.Product", "TypeOfRegistration_TypeOfRegistrationID", "dbo.TypeOfRegistration", "TypeOfRegistrationID");
        }
    }
}
