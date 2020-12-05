namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.R_Category", "categoryName", c => c.String());
            AddColumn("dbo.R_Condition", "ConditionName", c => c.String());
            AddColumn("dbo.R_Type", "TypeName", c => c.String());
            DropColumn("dbo.R_Category", "Name");
            DropColumn("dbo.R_Condition", "Name");
            DropColumn("dbo.R_Type", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.R_Type", "Name", c => c.String());
            AddColumn("dbo.R_Condition", "Name", c => c.String());
            AddColumn("dbo.R_Category", "Name", c => c.String());
            DropColumn("dbo.R_Type", "TypeName");
            DropColumn("dbo.R_Condition", "ConditionName");
            DropColumn("dbo.R_Category", "categoryName");
        }
    }
}
