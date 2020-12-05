namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RealEstateModels",
                c => new
                    {
                        RealEstateId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        Title = c.String(),
                        CategoryId = c.Long(nullable: false),
                        TypeId = c.Long(nullable: false),
                        ConditionId = c.Long(nullable: false),
                        SquareFeet = c.String(),
                        BedroomsId = c.Long(nullable: false),
                        BathroomsId = c.String(),
                        DirectionId = c.Long(nullable: false),
                        PostedById = c.Long(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        Mobile = c.String(),
                        Location = c.String(),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Date = c.DateTime(nullable: false),
                        Views = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RealEstateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RealEstateModels");
        }
    }
}
