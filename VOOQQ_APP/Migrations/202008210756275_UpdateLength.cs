namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auditoriums", "PropertyName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Businesses", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Businesses", "Description", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.CabsTaxis", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Cars", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Forsales", "Description", c => c.String(nullable: false, maxLength: 3000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Forsales", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Cars", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CabsTaxis", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Businesses", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Businesses", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Auditoriums", "PropertyName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
