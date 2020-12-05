namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fdfffdfdfdfd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Gender",
                c => new
                    {
                        GenderId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.T_QualifiedLevels",
                c => new
                    {
                        QualifiedTeachinglevelsId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.QualifiedTeachinglevelsId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        QualifiedTeachinglevelsId = c.Long(nullable: false),
                        GenderId = c.Long(nullable: false),
                        YearsOfExperience = c.String(),
                        LandPhone = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        Location = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Date = c.DateTime(nullable: false),
                        Views = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
            DropTable("dbo.T_QualifiedLevels");
            DropTable("dbo.T_Gender");
        }
    }
}
