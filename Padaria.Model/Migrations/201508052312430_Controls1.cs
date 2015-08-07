namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Controls1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Control",
                c => new
                    {
                        ControlID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ControlID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Control");
        }
    }
}
