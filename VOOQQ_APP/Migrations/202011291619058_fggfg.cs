namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fggfg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auditoriums", "Prime", c => c.Boolean(nullable: false));
            AddColumn("dbo.Businesses", "Prime", c => c.Boolean(nullable: false));
            AddColumn("dbo.CabsTaxis", "Prime", c => c.Boolean(nullable: false));
            AddColumn("dbo.Doctors", "Prime", c => c.Boolean(nullable: false));
            AddColumn("dbo.Educations", "Prime", c => c.Boolean(nullable: false));
            AddColumn("dbo.Forsales", "Prime", c => c.Boolean(nullable: false));
            AddColumn("dbo.HotelRooms", "Prime", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "Prime", c => c.Boolean(nullable: false));
            AddColumn("dbo.Matrimonies", "Prime", c => c.Boolean(nullable: false));
            AddColumn("dbo.RepairMechanics", "Prime", c => c.Boolean(nullable: false));
            AddColumn("dbo.Services", "Prime", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Prime");
            DropColumn("dbo.RepairMechanics", "Prime");
            DropColumn("dbo.Matrimonies", "Prime");
            DropColumn("dbo.Jobs", "Prime");
            DropColumn("dbo.HotelRooms", "Prime");
            DropColumn("dbo.Forsales", "Prime");
            DropColumn("dbo.Educations", "Prime");
            DropColumn("dbo.Doctors", "Prime");
            DropColumn("dbo.CabsTaxis", "Prime");
            DropColumn("dbo.Businesses", "Prime");
            DropColumn("dbo.Auditoriums", "Prime");
        }
    }
}
