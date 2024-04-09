namespace Dictionary.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEmailForAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Email");
        }
    }
}
