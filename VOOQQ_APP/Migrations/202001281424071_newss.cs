namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealEstates", "Image", c => c.String());
            AddColumn("dbo.RealEstates", "Views", c => c.Double(nullable: false));
            AddColumn("dbo.RealEstates", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RealEstates", "Status");
            DropColumn("dbo.RealEstates", "Views");
            DropColumn("dbo.RealEstates", "Image");
        }
    }
}
