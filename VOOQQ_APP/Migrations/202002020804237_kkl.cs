namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealEstates", "VId", c => c.Long(nullable: false));
            AddColumn("dbo.RealEstates", "CategoryId", c => c.Long(nullable: false));
            AddColumn("dbo.RealEstates", "TypeId", c => c.Long(nullable: false));
            AddColumn("dbo.RealEstates", "ConditionId", c => c.Long(nullable: false));
            AddColumn("dbo.RealEstates", "SquareFeetId", c => c.Long(nullable: false));
            AddColumn("dbo.RealEstates", "BedroomsId", c => c.Long(nullable: false));
            AddColumn("dbo.RealEstates", "PostedById", c => c.Long(nullable: false));
            AlterColumn("dbo.RealEstates", "Direction", c => c.Long(nullable: false));
            DropColumn("dbo.RealEstates", "Category");
            DropColumn("dbo.RealEstates", "Type");
            DropColumn("dbo.RealEstates", "Condition");
            DropColumn("dbo.RealEstates", "SquareFeet");
            DropColumn("dbo.RealEstates", "Bedrooms");
            DropColumn("dbo.RealEstates", "PostedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RealEstates", "PostedBy", c => c.String(nullable: false));
            AddColumn("dbo.RealEstates", "Bedrooms", c => c.String(nullable: false));
            AddColumn("dbo.RealEstates", "SquareFeet", c => c.String(nullable: false));
            AddColumn("dbo.RealEstates", "Condition", c => c.String(nullable: false));
            AddColumn("dbo.RealEstates", "Type", c => c.String(nullable: false));
            AddColumn("dbo.RealEstates", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.RealEstates", "Direction", c => c.String(nullable: false));
            DropColumn("dbo.RealEstates", "PostedById");
            DropColumn("dbo.RealEstates", "BedroomsId");
            DropColumn("dbo.RealEstates", "SquareFeetId");
            DropColumn("dbo.RealEstates", "ConditionId");
            DropColumn("dbo.RealEstates", "TypeId");
            DropColumn("dbo.RealEstates", "CategoryId");
            DropColumn("dbo.RealEstates", "VId");
        }
    }
}
