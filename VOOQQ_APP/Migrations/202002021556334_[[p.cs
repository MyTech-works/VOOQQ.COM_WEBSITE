namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class p : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealEstates", "SquareFeet", c => c.String(nullable: false));
            DropColumn("dbo.RealEstates", "SquareFeetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RealEstates", "SquareFeetId", c => c.Long(nullable: false));
            DropColumn("dbo.RealEstates", "SquareFeet");
        }
    }
}
