namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEducation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationCategories",
                c => new
                    {
                        EducationCategoryId = c.Long(nullable: false, identity: true),
                        EducationCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.EducationCategoryId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        NameofInstitute = c.String(nullable: false, maxLength: 100),
                        EducationCategoryId = c.Long(nullable: false),
                        Address = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        LandPhone = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        About = c.String(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EducationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Educations");
            DropTable("dbo.EducationCategories");
        }
    }
}
