namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleType1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleCategories",
                c => new
                    {
                        VehicleCategoryId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.VehicleCategoryId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.VehicleTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.VehicleCategories");
        }
    }
}
