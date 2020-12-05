namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aasa : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.R_Bedrooms");
            AddColumn("dbo.R_Bedrooms", "BedroomsId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.RealEstates", "SquareFeet", c => c.String(nullable: false));
            AddPrimaryKey("dbo.R_Bedrooms", "BedroomsId");
            DropColumn("dbo.R_Bedrooms", "SquareFeetId");
            DropColumn("dbo.RealEstates", "SquareFeetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RealEstates", "SquareFeetId", c => c.Long(nullable: false));
            AddColumn("dbo.R_Bedrooms", "SquareFeetId", c => c.Long(nullable: false, identity: true));
            DropPrimaryKey("dbo.R_Bedrooms");
            DropColumn("dbo.RealEstates", "SquareFeet");
            DropColumn("dbo.R_Bedrooms", "BedroomsId");
            AddPrimaryKey("dbo.R_Bedrooms", "SquareFeetId");
        }
    }
}
