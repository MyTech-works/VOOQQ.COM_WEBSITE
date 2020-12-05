namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neqwww : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Mobilenumber", c => c.String());
            AddColumn("dbo.Pets", "Saravanan", c => c.String());
            DropColumn("dbo.Pets", "Mobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "Mobile", c => c.String());
            DropColumn("dbo.Pets", "Saravanan");
            DropColumn("dbo.Pets", "Mobilenumber");
        }
    }
}
