namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Image1", c => c.String());
            AddColumn("dbo.Services", "Image2", c => c.String());
            AddColumn("dbo.Services", "Image3", c => c.String());
            AddColumn("dbo.Services", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Services", "Views", c => c.Double(nullable: false));
            AddColumn("dbo.Services", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Services", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Photo", c => c.String(nullable: false));
            DropColumn("dbo.Services", "Status");
            DropColumn("dbo.Services", "Views");
            DropColumn("dbo.Services", "Date");
            DropColumn("dbo.Services", "Image3");
            DropColumn("dbo.Services", "Image2");
            DropColumn("dbo.Services", "Image1");
        }
    }
}
