namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditoriumAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditoriumCategories",
                c => new
                    {
                        AuditoriumCategoryId = c.Long(nullable: false, identity: true),
                        AuditoriumCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.AuditoriumCategoryId);
            
            CreateTable(
                "dbo.Auditoriums",
                c => new
                    {
                        AuditoriumId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        PropertyName = c.String(nullable: false, maxLength: 100),
                        AuditoriumCategoryId = c.Long(nullable: false),
                        Location = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        SeatingCapacity = c.String(),
                        DiningCapacity = c.String(),
                        ParkingCapacity = c.String(),
                        AuditoriumTypeId = c.Long(nullable: false),
                        MobileNumber = c.String(),
                        LandPhone = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        About = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.AuditoriumId);
            
            CreateTable(
                "dbo.AuditoriumTypes",
                c => new
                    {
                        AuditoriumTypeId = c.Long(nullable: false, identity: true),
                        AuditoriumTypeName = c.String(),
                    })
                .PrimaryKey(t => t.AuditoriumTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuditoriumTypes");
            DropTable("dbo.Auditoriums");
            DropTable("dbo.AuditoriumCategories");
        }
    }
}
