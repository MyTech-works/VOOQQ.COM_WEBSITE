namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsdsd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Image1", c => c.String());
            AddColumn("dbo.Jobs", "Image2", c => c.String());
            AddColumn("dbo.Jobs", "Image3", c => c.String());
            AddColumn("dbo.Jobs", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "Views", c => c.Double(nullable: false));
            AddColumn("dbo.Jobs", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Jobs", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Image", c => c.String(nullable: false));
            DropColumn("dbo.Jobs", "Status");
            DropColumn("dbo.Jobs", "Views");
            DropColumn("dbo.Jobs", "Date");
            DropColumn("dbo.Jobs", "Image3");
            DropColumn("dbo.Jobs", "Image2");
            DropColumn("dbo.Jobs", "Image1");
        }
    }
}
