namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForesale : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Forsales", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Forsales", "Description", c => c.String(nullable: false));
        }
    }
}
