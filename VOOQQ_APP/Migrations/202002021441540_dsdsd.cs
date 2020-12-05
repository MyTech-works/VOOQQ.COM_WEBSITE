namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsdsd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealEstates", "BathroomsId", c => c.String(nullable: false));
            AddColumn("dbo.RealEstates", "DirectionId", c => c.Long(nullable: false));
            DropColumn("dbo.RealEstates", "Bathrooms");
            DropColumn("dbo.RealEstates", "Direction");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RealEstates", "Direction", c => c.Long(nullable: false));
            AddColumn("dbo.RealEstates", "Bathrooms", c => c.String(nullable: false));
            DropColumn("dbo.RealEstates", "DirectionId");
            DropColumn("dbo.RealEstates", "BathroomsId");
        }
    }
}
