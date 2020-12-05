namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matrimony : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodySkinTones",
                c => new
                    {
                        BodySkinToneId = c.Long(nullable: false, identity: true),
                        BodySkinToneName = c.String(),
                    })
                .PrimaryKey(t => t.BodySkinToneId);
            
            CreateTable(
                "dbo.MaritalStatus",
                c => new
                    {
                        MaritalStatusId = c.Long(nullable: false, identity: true),
                        MaritalStatusName = c.String(),
                    })
                .PrimaryKey(t => t.MaritalStatusId);
            
            CreateTable(
                "dbo.Matrimonies",
                c => new
                    {
                        MatrimonyId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                        MatrimonyCategoryId = c.Long(nullable: false),
                        MaritalStatusId = c.Long(nullable: false),
                        PhysicalStatusId = c.Long(nullable: false),
                        BodySkinToneId = c.Long(nullable: false),
                        ReligionId = c.Long(nullable: false),
                        Community = c.String(),
                        SubCommunity = c.String(),
                        Nakshatra = c.String(),
                        Job = c.String(),
                        Qualification = c.String(),
                        Languages = c.String(),
                        Email = c.String(),
                        Description = c.String(nullable: false),
                        LandPhone = c.String(),
                        Mobile = c.String(),
                        Location = c.String(nullable: false),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Date = c.DateTime(nullable: false),
                        Views = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MatrimonyId);
            
            CreateTable(
                "dbo.MatrimonyCategories",
                c => new
                    {
                        MatrimonyCategoryId = c.Long(nullable: false, identity: true),
                        MatrimonyCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.MatrimonyCategoryId);
            
            CreateTable(
                "dbo.PhysicalStatus",
                c => new
                    {
                        PhysicalStatusId = c.Long(nullable: false, identity: true),
                        PhysicalStatusName = c.String(),
                    })
                .PrimaryKey(t => t.PhysicalStatusId);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        ReligionId = c.Long(nullable: false, identity: true),
                        ReligionName = c.String(),
                    })
                .PrimaryKey(t => t.ReligionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Religions");
            DropTable("dbo.PhysicalStatus");
            DropTable("dbo.MatrimonyCategories");
            DropTable("dbo.Matrimonies");
            DropTable("dbo.MaritalStatus");
            DropTable("dbo.BodySkinTones");
        }
    }
}
