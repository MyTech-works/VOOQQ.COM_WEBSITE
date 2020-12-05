namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Availability",
                c => new
                    {
                        T_AvailabilityId = c.Long(nullable: false, identity: true),
                        T_AvailabilityName = c.String(),
                    })
                .PrimaryKey(t => t.T_AvailabilityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_Availability");
        }
    }
}
