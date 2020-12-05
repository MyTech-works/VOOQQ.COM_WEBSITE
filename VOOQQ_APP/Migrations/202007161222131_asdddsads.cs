namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdddsads : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auditoriums", "UserId", c => c.String());
            AlterColumn("dbo.Businesses", "UserId", c => c.String());
            AlterColumn("dbo.CabsTaxis", "UserId", c => c.String());
            AlterColumn("dbo.Doctors", "UserId", c => c.String());
            AlterColumn("dbo.Educations", "UserId", c => c.String());
            AlterColumn("dbo.Forsales", "UserId", c => c.String());
            AlterColumn("dbo.HotelRooms", "UserId", c => c.String());
            AlterColumn("dbo.Jobs", "UserId", c => c.String());
            AlterColumn("dbo.Matrimonies", "UserId", c => c.String());
            AlterColumn("dbo.Pets", "UserId", c => c.String());
            AlterColumn("dbo.RepairMechanics", "UserId", c => c.String());
            AlterColumn("dbo.Services", "UserId", c => c.String());
            AlterColumn("dbo.Teachers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Services", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.RepairMechanics", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Pets", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Matrimonies", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Jobs", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.HotelRooms", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Forsales", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Educations", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Doctors", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.CabsTaxis", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Businesses", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Auditoriums", "UserId", c => c.Long(nullable: false));
        }
    }
}
