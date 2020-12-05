namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Businesses", "UserId", c => c.Long(nullable: false));
            AddColumn("dbo.Businesses", "LandPhone", c => c.String());
            AddColumn("dbo.Businesses", "Email", c => c.String());
            AddColumn("dbo.Businesses", "Website", c => c.String());
            AddColumn("dbo.Forsales", "UserId", c => c.Long(nullable: false));
            AddColumn("dbo.Forsales", "Email", c => c.String());
            DropColumn("dbo.Businesses", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Businesses", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Forsales", "Email");
            DropColumn("dbo.Forsales", "UserId");
            DropColumn("dbo.Businesses", "Website");
            DropColumn("dbo.Businesses", "Email");
            DropColumn("dbo.Businesses", "LandPhone");
            DropColumn("dbo.Businesses", "UserId");
        }
    }
}
