namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kjkkj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auditoriums", "Image1", c => c.String());
            AddColumn("dbo.Auditoriums", "Image2", c => c.String());
            AddColumn("dbo.Auditoriums", "Image3", c => c.String());
            AddColumn("dbo.Auditoriums", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auditoriums", "Views", c => c.Double(nullable: false));
            AddColumn("dbo.Auditoriums", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Auditoriums", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auditoriums", "Image", c => c.String());
            DropColumn("dbo.Auditoriums", "Status");
            DropColumn("dbo.Auditoriums", "Views");
            DropColumn("dbo.Auditoriums", "Date");
            DropColumn("dbo.Auditoriums", "Image3");
            DropColumn("dbo.Auditoriums", "Image2");
            DropColumn("dbo.Auditoriums", "Image1");
        }
    }
}
