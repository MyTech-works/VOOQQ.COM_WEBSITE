namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Educations", "NameofInstitute", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.HotelRooms", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Jobs", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Matrimonies", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.RealEstates", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.RepairMechanics", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Services", "Tiltle", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Teachers", "Title", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Services", "Tiltle", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.RepairMechanics", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.RealEstates", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Matrimonies", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Jobs", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.HotelRooms", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Educations", "NameofInstitute", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Doctors", "Title", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
