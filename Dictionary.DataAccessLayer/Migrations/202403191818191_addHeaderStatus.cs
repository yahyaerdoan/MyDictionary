namespace Dictionary.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHeaderStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heads", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heads", "Status");
        }
    }
}
