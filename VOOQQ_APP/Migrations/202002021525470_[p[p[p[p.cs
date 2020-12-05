namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pppp : DbMigration
    {
        public override void Up()
        {
           
           
            DropColumn("dbo.R_Bedrooms", "SquareFeetId");
        }
        
        public override void Down()
        {
           
        }
    }
}
