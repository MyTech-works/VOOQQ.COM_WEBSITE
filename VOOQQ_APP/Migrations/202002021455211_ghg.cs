namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.R_SquareFeet",
                c => new
                    {
                        SquareFeetId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SquareFeetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.R_SquareFeet");
        }
    }
}
