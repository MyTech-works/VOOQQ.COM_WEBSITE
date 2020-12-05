namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        JobCategoryId = c.Long(nullable: false, identity: true),
                        JobCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.JobCategoryId);
            
            CreateTable(
                "dbo.JobLookingfors",
                c => new
                    {
                        JobLookingforId = c.Long(nullable: false, identity: true),
                        JobLookingforName = c.String(),
                    })
                .PrimaryKey(t => t.JobLookingforId);
            
            CreateTable(
                "dbo.JobPostedBies",
                c => new
                    {
                        JobPostedById = c.Long(nullable: false, identity: true),
                        JobPostedByName = c.String(),
                    })
                .PrimaryKey(t => t.JobPostedById);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        HotelRoomId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        JobCategoryId = c.Long(nullable: false),
                        Salary = c.Double(nullable: false),
                        PostedById = c.Long(nullable: false),
                        StatusId = c.Long(nullable: false),
                        LookingforId = c.Long(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        LandPhone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HotelRoomId);
            
            CreateTable(
                "dbo.JobStatus",
                c => new
                    {
                        JobStatusId = c.Long(nullable: false, identity: true),
                        JobStatusName = c.String(),
                    })
                .PrimaryKey(t => t.JobStatusId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobStatus");
            DropTable("dbo.Jobs");
            DropTable("dbo.JobPostedBies");
            DropTable("dbo.JobLookingfors");
            DropTable("dbo.JobCategories");
        }
    }
}
