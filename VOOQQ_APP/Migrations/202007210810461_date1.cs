namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HotelRooms", "CheckIn", c => c.String());
            AlterColumn("dbo.HotelRooms", "CheckOut", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HotelRooms", "CheckOut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HotelRooms", "CheckIn", c => c.DateTime(nullable: false));
        }
    }
}
