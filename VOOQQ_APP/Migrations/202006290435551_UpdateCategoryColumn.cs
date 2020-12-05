namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategoryColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleCategories", "VehicleCategoryName", c => c.String());
            AddColumn("dbo.VehicleTypes", "VehicleTypeName", c => c.String());
            DropColumn("dbo.VehicleCategories", "Name");
            DropColumn("dbo.VehicleTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleTypes", "Name", c => c.String());
            AddColumn("dbo.VehicleCategories", "Name", c => c.String());
            DropColumn("dbo.VehicleTypes", "VehicleTypeName");
            DropColumn("dbo.VehicleCategories", "VehicleCategoryName");
        }
    }
}
