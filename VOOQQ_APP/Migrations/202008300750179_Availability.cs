namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Availability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Availability", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Availability");
        }
    }
}
