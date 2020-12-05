namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fgf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CabsTaxis", "Image1", c => c.String());
            AddColumn("dbo.CabsTaxis", "Image2", c => c.String());
            AddColumn("dbo.CabsTaxis", "Image3", c => c.String());
            AddColumn("dbo.CabsTaxis", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.CabsTaxis", "Views", c => c.Double(nullable: false));
            AddColumn("dbo.CabsTaxis", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CabsTaxis", "Status");
            DropColumn("dbo.CabsTaxis", "Views");
            DropColumn("dbo.CabsTaxis", "Date");
            DropColumn("dbo.CabsTaxis", "Image3");
            DropColumn("dbo.CabsTaxis", "Image2");
            DropColumn("dbo.CabsTaxis", "Image1");
        }
    }
}
