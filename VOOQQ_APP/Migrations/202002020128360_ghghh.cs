namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghghh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealEstates", "Image1", c => c.String());
            AddColumn("dbo.RealEstates", "Image2", c => c.String());
            AddColumn("dbo.RealEstates", "Image3", c => c.String());
            AddColumn("dbo.RealEstates", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.RealEstates", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RealEstates", "Image", c => c.String());
            DropColumn("dbo.RealEstates", "Date");
            DropColumn("dbo.RealEstates", "Image3");
            DropColumn("dbo.RealEstates", "Image2");
            DropColumn("dbo.RealEstates", "Image1");
        }
    }
}
