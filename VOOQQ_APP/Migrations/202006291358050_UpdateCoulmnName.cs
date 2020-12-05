namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCoulmnName : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Jobs");
            AddColumn("dbo.Jobs", "JobId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Jobs", "JobId");
            DropColumn("dbo.Jobs", "HotelRoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "HotelRoomId", c => c.Long(nullable: false, identity: true));
            DropPrimaryKey("dbo.Jobs");
            DropColumn("dbo.Jobs", "JobId");
            AddPrimaryKey("dbo.Jobs", "HotelRoomId");
        }
    }
}
