namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pppp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                  "dbo.R_Bedrooms",
                  c => new
                  {
                      BedroomsId = c.Long(nullable: false, identity: true),
                      Name = c.String(),
                  })
                  .PrimaryKey(t => t.BedroomsId);

           
        }
        
        public override void Down()
        {
           
        }
    }
}
