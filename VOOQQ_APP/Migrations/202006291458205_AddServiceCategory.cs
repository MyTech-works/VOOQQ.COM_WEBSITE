namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceCategories",
                c => new
                    {
                        ServiceCategoryId = c.Long(nullable: false, identity: true),
                        ServiceCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ServiceCategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceCategories");
        }
    }
}
