namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HotelRooms", "ClassTypeId", c => c.Long(nullable: false));
            DropColumn("dbo.HotelRooms", "ClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HotelRooms", "ClassId", c => c.Long(nullable: false));
            DropColumn("dbo.HotelRooms", "ClassTypeId");
        }
    }
}
