namespace Dictionary.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GalleryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Galleries");
        }
    }
}
