namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddsdsd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auditoriums", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auditoriums", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auditoriums", "EndDate");
            DropColumn("dbo.Auditoriums", "StratDate");
        }
    }
}
