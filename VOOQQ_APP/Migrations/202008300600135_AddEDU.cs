namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEDU : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairMechanics", "YearsOfExperiance", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RepairMechanics", "YearsOfExperiance");
        }
    }
}
