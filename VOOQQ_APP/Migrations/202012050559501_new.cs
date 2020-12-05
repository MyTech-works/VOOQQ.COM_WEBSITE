namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanMasters",
                c => new
                    {
                        PlanMastersId = c.Long(nullable: false, identity: true),
                        VId = c.Long(nullable: false),
                        PlanType = c.String(),
                        PlanName = c.String(),
                        PlanDays = c.Int(nullable: false),
                        NewPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Feaures1 = c.String(),
                        Feaures2 = c.String(),
                        Feaures3 = c.String(),
                        Feaures4 = c.String(),
                        Feaures5 = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlanMastersId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlanMasters");
        }
    }
}
