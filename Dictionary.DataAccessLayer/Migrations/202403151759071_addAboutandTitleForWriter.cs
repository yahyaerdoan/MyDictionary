namespace Dictionary.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAboutandTitleForWriter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "About", c => c.String());
            AddColumn("dbo.Writers", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "Title");
            DropColumn("dbo.Writers", "About");
        }
    }
}
