namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ppp : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.R_Bedrooms");
            AddColumn("dbo.R_Bedrooms", "BedroomsId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.R_Bedrooms", "BedroomsId");
            DropColumn("dbo.R_Bedrooms", "SquareFeetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.R_Bedrooms", "SquareFeetId", c => c.Long(nullable: false, identity: true));
            DropPrimaryKey("dbo.R_Bedrooms");
            DropColumn("dbo.R_Bedrooms", "BedroomsId");
            AddPrimaryKey("dbo.R_Bedrooms", "SquareFeetId");
        }
    }
}
