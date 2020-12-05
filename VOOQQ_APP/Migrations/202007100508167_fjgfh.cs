namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fjgfh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HotelRooms", "Image1", c => c.String());
            AddColumn("dbo.HotelRooms", "Image2", c => c.String());
            AddColumn("dbo.HotelRooms", "Image3", c => c.String());
            AddColumn("dbo.HotelRooms", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.HotelRooms", "Views", c => c.Double(nullable: false));
            AddColumn("dbo.HotelRooms", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.HotelRooms", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HotelRooms", "Image", c => c.String(nullable: false));
            DropColumn("dbo.HotelRooms", "Status");
            DropColumn("dbo.HotelRooms", "Views");
            DropColumn("dbo.HotelRooms", "Date");
            DropColumn("dbo.HotelRooms", "Image3");
            DropColumn("dbo.HotelRooms", "Image2");
            DropColumn("dbo.HotelRooms", "Image1");
        }
    }
}
