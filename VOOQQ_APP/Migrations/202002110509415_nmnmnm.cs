namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nmnmnm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M_Category",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.M_Type",
                c => new
                    {
                        TypeId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.M_Type");
            DropTable("dbo.M_Category");
        }
    }
}
