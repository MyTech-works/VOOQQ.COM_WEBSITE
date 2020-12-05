namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        CategoryId = c.Long(nullable: false),
                        TypeId = c.Long(nullable: false),
                        BrandId = c.Long(nullable: false),
                        FuelId = c.Long(nullable: false),
                        Year = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        DirectionId = c.Long(nullable: false),
                        KM = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(nullable: false, maxLength: 3000),
                        Mobile = c.String(),
                        Location = c.String(nullable: false),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Date = c.DateTime(nullable: false),
                        Views = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
