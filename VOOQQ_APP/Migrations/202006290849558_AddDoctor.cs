namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctor : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Doctors");
            AddColumn("dbo.Doctors", "DoctorId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Doctors", "DoctorId");
            DropColumn("dbo.Doctors", "AuditoriumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "AuditoriumId", c => c.Long(nullable: false, identity: true));
            DropPrimaryKey("dbo.Doctors");
            DropColumn("dbo.Doctors", "DoctorId");
            AddPrimaryKey("dbo.Doctors", "AuditoriumId");
        }
    }
}
