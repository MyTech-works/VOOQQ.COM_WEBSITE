namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hghghghgh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educations", "Image1", c => c.String());
            AddColumn("dbo.Educations", "Image2", c => c.String());
            AddColumn("dbo.Educations", "Image3", c => c.String());
            AddColumn("dbo.Educations", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Educations", "Views", c => c.Double(nullable: false));
            AddColumn("dbo.Educations", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Educations", "Email", c => c.String());
            AlterColumn("dbo.Educations", "Website", c => c.String());
            AlterColumn("dbo.Educations", "About", c => c.String());
            DropColumn("dbo.Educations", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Educations", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Educations", "About", c => c.String(nullable: false));
            AlterColumn("dbo.Educations", "Website", c => c.String(nullable: false));
            AlterColumn("dbo.Educations", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Educations", "Status");
            DropColumn("dbo.Educations", "Views");
            DropColumn("dbo.Educations", "Date");
            DropColumn("dbo.Educations", "Image3");
            DropColumn("dbo.Educations", "Image2");
            DropColumn("dbo.Educations", "Image1");
        }
    }
}
