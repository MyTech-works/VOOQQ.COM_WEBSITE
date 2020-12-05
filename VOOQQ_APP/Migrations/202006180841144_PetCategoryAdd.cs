namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetCategoryAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "CategoryId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "CategoryId");
        }
    }
}
