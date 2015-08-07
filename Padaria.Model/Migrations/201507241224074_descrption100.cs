namespace Padaria.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class descrption100 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Description", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Description", c => c.String());
        }
    }
}
