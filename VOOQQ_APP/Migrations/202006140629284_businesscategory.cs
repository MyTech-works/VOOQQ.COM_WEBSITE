namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class businesscategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessCategories",
                c => new
                    {
                        BusinessCategoryId = c.Long(nullable: false, identity: true),
                        BusinessCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.BusinessCategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BusinessCategories");
        }
    }
}
