namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCatVoqq : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Long(nullable: false, identity: true),
                        VooqCategoryId = c.Long(nullable: false),
                        PlanTypeId = c.Long(nullable: false),
                        PlanTypeName = c.String(nullable: false),
                        Duration = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPrime = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId);
            
            CreateTable(
                "dbo.VooqCategories",
                c => new
                    {
                        RefId = c.Long(nullable: false, identity: true),
                        VooqCategoryId = c.Long(nullable: false),
                        CategoryName = c.String(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RefId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VooqCategories");
            DropTable("dbo.Plans");
        }
    }
}
