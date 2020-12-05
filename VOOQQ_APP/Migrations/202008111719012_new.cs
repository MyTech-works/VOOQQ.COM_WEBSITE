namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Businesses", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Businesses", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CabsTaxis", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CabsTaxis", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Educations", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Educations", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Forsales", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Forsales", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HotelRooms", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HotelRooms", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matrimonies", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matrimonies", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RepairMechanics", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RepairMechanics", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Services", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Services", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teachers", "StratDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teachers", "EndDate", c => c.DateTime(nullable: false));
            DropTable("dbo.Mobiles");
            DropTable("dbo.Pets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        UserId = c.String(),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        Email = c.String(),
                        Mobilenumber = c.String(),
                        Location = c.String(nullable: false),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Date = c.DateTime(nullable: false),
                        Views = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PetId);
            
            CreateTable(
                "dbo.Mobiles",
                c => new
                    {
                        MobilesId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        CategoryId = c.Long(nullable: false),
                        TypeId = c.Long(nullable: false),
                        ConditionId = c.Long(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(nullable: false, maxLength: 3000),
                        Mobile = c.String(),
                        Location = c.String(nullable: false),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Date = c.DateTime(nullable: false),
                        Views = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MobilesId);
            
            DropColumn("dbo.Teachers", "EndDate");
            DropColumn("dbo.Teachers", "StratDate");
            DropColumn("dbo.Services", "EndDate");
            DropColumn("dbo.Services", "StratDate");
            DropColumn("dbo.RepairMechanics", "EndDate");
            DropColumn("dbo.RepairMechanics", "StratDate");
            DropColumn("dbo.Matrimonies", "EndDate");
            DropColumn("dbo.Matrimonies", "StratDate");
            DropColumn("dbo.Jobs", "EndDate");
            DropColumn("dbo.Jobs", "StratDate");
            DropColumn("dbo.HotelRooms", "EndDate");
            DropColumn("dbo.HotelRooms", "StratDate");
            DropColumn("dbo.Forsales", "EndDate");
            DropColumn("dbo.Forsales", "StratDate");
            DropColumn("dbo.Educations", "EndDate");
            DropColumn("dbo.Educations", "StratDate");
            DropColumn("dbo.Doctors", "EndDate");
            DropColumn("dbo.Doctors", "StratDate");
            DropColumn("dbo.CabsTaxis", "EndDate");
            DropColumn("dbo.CabsTaxis", "StratDate");
            DropColumn("dbo.Businesses", "EndDate");
            DropColumn("dbo.Businesses", "StratDate");
        }
    }
}
