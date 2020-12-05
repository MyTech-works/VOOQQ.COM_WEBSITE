namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CabsTaxipageCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CabsTaxis",
                c => new
                    {
                        CabTaxiId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        VehicleCategoryId = c.Long(nullable: false),
                        VehicleTypeId = c.Long(nullable: false),
                        Location = c.String(nullable: false),
                        DriverAge = c.Long(nullable: false),
                        YearofExperience = c.Long(nullable: false),
                        VehicleBrand = c.String(),
                        VehicleModelName = c.String(),
                        VehicleYear = c.Long(nullable: false),
                        SeatingCapacity = c.Long(nullable: false),
                        MinimumCharge = c.Long(nullable: false),
                        MobileNumber = c.Long(nullable: false),
                        LandPhone = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CabTaxiId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CabsTaxis");
        }
    }
}
