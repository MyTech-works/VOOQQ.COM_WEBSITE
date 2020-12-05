namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorPage : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Doctors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        AuditoriumId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        DoctorCategoryId = c.Long(nullable: false),
                        Location = c.String(nullable: false),
                        YearsofExperience = c.Long(nullable: false),
                        Mobile = c.String(nullable: false),
                        LandPhone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AuditoriumId);
            
        }
    }
}
