namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHotelRoom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelRoomClassTypes",
                c => new
                    {
                        ClassTypeId = c.Long(nullable: false, identity: true),
                        ClassTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ClassTypeId);
            
            CreateTable(
                "dbo.HotelRoomInternetTypes",
                c => new
                    {
                        InternetTypeId = c.Long(nullable: false, identity: true),
                        InternetTypeName = c.String(),
                    })
                .PrimaryKey(t => t.InternetTypeId);
            
            CreateTable(
                "dbo.HotelRoomPropertyTypes",
                c => new
                    {
                        PropertyTypeId = c.Long(nullable: false, identity: true),
                        PropertyTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PropertyTypeId);
            
            CreateTable(
                "dbo.HotelRooms",
                c => new
                    {
                        HotelRoomId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        PropertyTypeId = c.Long(nullable: false),
                        ClassId = c.Long(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        InternetTypeID = c.Long(nullable: false),
                        IsParking = c.Boolean(nullable: false),
                        IsBreakfast = c.Boolean(nullable: false),
                        IsEscalator = c.Boolean(nullable: false),
                        IsRoomService = c.Boolean(nullable: false),
                        IsRestaurant = c.Boolean(nullable: false),
                        IsBar = c.Boolean(nullable: false),
                        IsSpaMassage = c.Boolean(nullable: false),
                        IsSwimmingPool = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                        LandPhone = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HotelRoomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HotelRooms");
            DropTable("dbo.HotelRoomPropertyTypes");
            DropTable("dbo.HotelRoomInternetTypes");
            DropTable("dbo.HotelRoomClassTypes");
        }
    }
}
