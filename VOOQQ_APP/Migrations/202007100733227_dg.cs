namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            AddColumn("dbo.Teachers", "SubjectId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "SubjectId");
            DropTable("dbo.Subjects");
        }
    }
}
