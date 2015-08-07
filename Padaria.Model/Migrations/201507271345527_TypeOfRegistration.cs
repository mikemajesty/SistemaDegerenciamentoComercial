namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeOfRegistration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeOfRegistration",
                c => new
                    {
                        TypeOfRegistrationID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.TypeOfRegistrationID);
            
            AddColumn("dbo.Product", "TypeOfRegistration_TypeOfRegistrationID", c => c.Int());
            CreateIndex("dbo.Product", "TypeOfRegistration_TypeOfRegistrationID");
            AddForeignKey("dbo.Product", "TypeOfRegistration_TypeOfRegistrationID", "dbo.TypeOfRegistration", "TypeOfRegistrationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "TypeOfRegistration_TypeOfRegistrationID", "dbo.TypeOfRegistration");
            DropIndex("dbo.Product", new[] { "TypeOfRegistration_TypeOfRegistrationID" });
            DropColumn("dbo.Product", "TypeOfRegistration_TypeOfRegistrationID");
            DropTable("dbo.TypeOfRegistration");
        }
    }
}
