namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lkkl : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.R_Bedrooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.R_Bedrooms",
                c => new
                    {
                        SquareFeetId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SquareFeetId);
            
        }
    }
}
