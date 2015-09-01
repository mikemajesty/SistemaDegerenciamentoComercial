namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameControlID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleWithActiveControls", "Controls_ControlID", "dbo.Controls");
            DropIndex("dbo.SaleWithActiveControls", new[] { "Controls_ControlID" });
            RenameColumn(table: "dbo.SaleWithActiveControls", name: "Controls_ControlID", newName: "ControlID");
            AlterColumn("dbo.SaleWithActiveControls", "ControlID", c => c.Int(nullable: false));
            CreateIndex("dbo.SaleWithActiveControls", "ControlID");
            AddForeignKey("dbo.SaleWithActiveControls", "ControlID", "dbo.Controls", "ControlID", cascadeDelete: true);
            DropColumn("dbo.SaleWithActiveControls", "ControlsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaleWithActiveControls", "ControlsID", c => c.Int(nullable: false));
            DropForeignKey("dbo.SaleWithActiveControls", "ControlID", "dbo.Controls");
            DropIndex("dbo.SaleWithActiveControls", new[] { "ControlID" });
            AlterColumn("dbo.SaleWithActiveControls", "ControlID", c => c.Int());
            RenameColumn(table: "dbo.SaleWithActiveControls", name: "ControlID", newName: "Controls_ControlID");
            CreateIndex("dbo.SaleWithActiveControls", "Controls_ControlID");
            AddForeignKey("dbo.SaleWithActiveControls", "Controls_ControlID", "dbo.Controls", "ControlID");
        }
    }
}
