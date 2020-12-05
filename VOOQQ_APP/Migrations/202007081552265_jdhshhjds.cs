namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jdhshhjds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Image1", c => c.String());
            AddColumn("dbo.Doctors", "Image2", c => c.String());
            AddColumn("dbo.Doctors", "Image3", c => c.String());
            AddColumn("dbo.Doctors", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "Views", c => c.Double(nullable: false));
            AddColumn("dbo.Doctors", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Doctors", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Image", c => c.String(nullable: false));
            DropColumn("dbo.Doctors", "Status");
            DropColumn("dbo.Doctors", "Views");
            DropColumn("dbo.Doctors", "Date");
            DropColumn("dbo.Doctors", "Image3");
            DropColumn("dbo.Doctors", "Image2");
            DropColumn("dbo.Doctors", "Image1");
        }
    }
}
