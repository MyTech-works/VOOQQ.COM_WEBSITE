namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RealEstates",
                c => new
                    {
                        RealEstateId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Category = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Condition = c.String(nullable: false),
                        SquareFeet = c.String(nullable: false),
                        Bedrooms = c.String(nullable: false),
                        Bathrooms = c.String(nullable: false),
                        Direction = c.String(nullable: false),
                        PostedBy = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 3000),
                        Mobile = c.String(),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RealEstateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RealEstates");
        }
    }
}
