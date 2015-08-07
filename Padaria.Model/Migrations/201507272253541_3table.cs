namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PayBox",
                c => new
                    {
                        PayBoxID = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PayBoxID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        PassWord = c.String(nullable: false, maxLength: 20),
                        PermissionID = c.Int(nullable: false),
                        LastAccess = c.DateTime(nullable: false),
                        FullName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Permission", t => t.PermissionID, cascadeDelete: true)
                .Index(t => t.PermissionID);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        PermissionID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.PermissionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PayBox", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "PermissionID", "dbo.Permission");
            DropIndex("dbo.Users", new[] { "PermissionID" });
            DropIndex("dbo.PayBox", new[] { "UserID" });
            DropTable("dbo.Permission");
            DropTable("dbo.Users");
            DropTable("dbo.PayBox");
        }
    }
}
