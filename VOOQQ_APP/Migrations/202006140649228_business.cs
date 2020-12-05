namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class business : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Forsales", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Forsales", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Forsales", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Forsales", "Location", c => c.String());
            AlterColumn("dbo.Forsales", "Description", c => c.String());
            AlterColumn("dbo.Forsales", "Title", c => c.String());
        }
    }
}
