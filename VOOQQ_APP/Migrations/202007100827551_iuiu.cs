namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iuiu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RCategories",
                c => new
                    {
                        RCategoryId = c.Long(nullable: false, identity: true),
                        EducationCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.RCategoryId);
            
            CreateTable(
                "dbo.RepairMechanics",
                c => new
                    {
                        RepairMechanicId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        RCategoryId = c.Long(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        LandPhone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Date = c.DateTime(nullable: false),
                        Views = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RepairMechanicId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RepairMechanics");
            DropTable("dbo.RCategories");
        }
    }
}
