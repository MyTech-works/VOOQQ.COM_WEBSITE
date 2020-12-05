namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mobiles",
                c => new
                    {
                        MobilesId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        CategoryId = c.Long(nullable: false),
                        TypeId = c.Long(nullable: false),
                        ConditionId = c.Long(nullable: false),
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
                .PrimaryKey(t => t.MobilesId);
            
            AddColumn("dbo.RealEstates", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RealEstates", "Price");
            DropTable("dbo.Mobiles");
        }
    }
}
