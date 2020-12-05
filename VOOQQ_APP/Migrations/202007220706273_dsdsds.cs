namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsdsds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CabsTaxis", "About", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CabsTaxis", "About");
        }
    }
}
