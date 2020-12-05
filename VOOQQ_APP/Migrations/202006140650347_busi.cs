namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class busi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        BusinessId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        BusinessCategoryId = c.Long(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(nullable: false),
                        Mobile = c.String(),
                        Location = c.String(nullable: false),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Date = c.DateTime(nullable: false),
                        Views = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Businesses");
        }
    }
}
