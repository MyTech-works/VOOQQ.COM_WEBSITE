namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyStoredProcedure : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            CREATE PROCEDURE dbo.RealEstates
            AS
            SELECT * FROM RealEstates");
        }
        
        public override void Down()
        {
            Sql("DROP PROCEDURE dbo.RealEstates");
        }
    }
}
