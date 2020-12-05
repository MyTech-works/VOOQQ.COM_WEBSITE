namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hghghg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M_AgeCategory",
                c => new
                    {
                        M_AgeCategoryId = c.Long(nullable: false, identity: true),
                        M_AgeCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.M_AgeCategoryId);
            
            CreateTable(
                "dbo.M_BodySkinTone",
                c => new
                    {
                        M_BodySkinToneId = c.Long(nullable: false, identity: true),
                        M_BodySkinToneName = c.String(),
                    })
                .PrimaryKey(t => t.M_BodySkinToneId);
            
            CreateTable(
                "dbo.M_MaritalStatus",
                c => new
                    {
                        M_MaritalStatusId = c.Long(nullable: false, identity: true),
                        M_MaritalStatusName = c.String(),
                    })
                .PrimaryKey(t => t.M_MaritalStatusId);
            
            CreateTable(
                "dbo.M_PhysicalStatus",
                c => new
                    {
                        M_PhysicalStatusId = c.Long(nullable: false, identity: true),
                        M_PhysicalStatusName = c.String(),
                    })
                .PrimaryKey(t => t.M_PhysicalStatusId);
            
            AddColumn("dbo.Matrimonies", "M_AgeCategoryId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "M_MaritalStatusId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "M_PhysicalStatusId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "M_BodySkinToneId", c => c.Long(nullable: false));
            DropColumn("dbo.Matrimonies", "MaritalStatusId");
            DropColumn("dbo.Matrimonies", "PhysicalStatusId");
            DropColumn("dbo.Matrimonies", "BodySkinToneId");
            DropTable("dbo.M_Category");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.M_Category",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Matrimonies", "BodySkinToneId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "PhysicalStatusId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "MaritalStatusId", c => c.Long(nullable: false));
            DropColumn("dbo.Matrimonies", "M_BodySkinToneId");
            DropColumn("dbo.Matrimonies", "M_PhysicalStatusId");
            DropColumn("dbo.Matrimonies", "M_MaritalStatusId");
            DropColumn("dbo.Matrimonies", "M_AgeCategoryId");
            DropTable("dbo.M_PhysicalStatus");
            DropTable("dbo.M_MaritalStatus");
            DropTable("dbo.M_BodySkinTone");
            DropTable("dbo.M_AgeCategory");
        }
    }
}
