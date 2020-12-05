namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForesale1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Forsales", "Title", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Forsales", "Title", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
