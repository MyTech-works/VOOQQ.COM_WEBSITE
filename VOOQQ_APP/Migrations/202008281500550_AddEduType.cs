namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEduType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationTypes",
                c => new
                    {
                        EducationTypeId = c.Long(nullable: false, identity: true),
                        EducationTypeName = c.String(),
                    })
                .PrimaryKey(t => t.EducationTypeId);
            
            AddColumn("dbo.Educations", "EducationTypeId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Educations", "EducationTypeId");
            DropTable("dbo.EducationTypes");
        }
    }
}
