namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfggfg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.R_Bathrooms",
                c => new
                    {
                        BathroomsId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BathroomsId);
            
            CreateTable(
                "dbo.R_Bedrooms",
                c => new
                    {
                        BedroomsId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BedroomsId);
            
            CreateTable(
                "dbo.R_Category",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.R_Condition",
                c => new
                    {
                        ConditionId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ConditionId);
            
            CreateTable(
                "dbo.R_Direction",
                c => new
                    {
                        DirectionId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DirectionId);
            
            CreateTable(
                "dbo.R_PostedBy",
                c => new
                    {
                        PostedById = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PostedById);
            
            CreateTable(
                "dbo.R_Type",
                c => new
                    {
                        TypeId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.R_Type");
            DropTable("dbo.R_PostedBy");
            DropTable("dbo.R_Direction");
            DropTable("dbo.R_Condition");
            DropTable("dbo.R_Category");
            DropTable("dbo.R_Bedrooms");
            DropTable("dbo.R_Bathrooms");
        }
    }
}
