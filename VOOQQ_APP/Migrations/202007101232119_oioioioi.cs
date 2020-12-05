namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oioioioi : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.M_Category");
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
            
            AddColumn("dbo.M_Category", "Ma_CategoryId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.M_Category", "Ma_CategoryName", c => c.String());
            AddColumn("dbo.Matrimonies", "M_CategoryId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "M_AgeCategoryId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "M_MaritalStatusId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "M_PhysicalStatusId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "M_BodySkinToneId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.M_Category", "Ma_CategoryId");
            DropColumn("dbo.M_Category", "CategoryId");
            DropColumn("dbo.M_Category", "Name");
            DropColumn("dbo.Matrimonies", "MatrimonyCategoryId");
            DropColumn("dbo.Matrimonies", "MaritalStatusId");
            DropColumn("dbo.Matrimonies", "PhysicalStatusId");
            DropColumn("dbo.Matrimonies", "BodySkinToneId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matrimonies", "BodySkinToneId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "PhysicalStatusId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "MaritalStatusId", c => c.Long(nullable: false));
            AddColumn("dbo.Matrimonies", "MatrimonyCategoryId", c => c.Long(nullable: false));
            AddColumn("dbo.M_Category", "Name", c => c.String());
            AddColumn("dbo.M_Category", "CategoryId", c => c.Long(nullable: false, identity: true));
            DropPrimaryKey("dbo.M_Category");
            DropColumn("dbo.Matrimonies", "M_BodySkinToneId");
            DropColumn("dbo.Matrimonies", "M_PhysicalStatusId");
            DropColumn("dbo.Matrimonies", "M_MaritalStatusId");
            DropColumn("dbo.Matrimonies", "M_AgeCategoryId");
            DropColumn("dbo.Matrimonies", "M_CategoryId");
            DropColumn("dbo.M_Category", "Ma_CategoryName");
            DropColumn("dbo.M_Category", "Ma_CategoryId");
            DropTable("dbo.M_PhysicalStatus");
            DropTable("dbo.M_MaritalStatus");
            DropTable("dbo.M_BodySkinTone");
            DropTable("dbo.M_AgeCategory");
            AddPrimaryKey("dbo.M_Category", "CategoryId");
        }
    }
}
