namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSaravananColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pets", "Saravanan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "Saravanan", c => c.String());
        }
    }
}
