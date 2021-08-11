namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov691 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_PARAM_PN", "PpTrmF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PRE", "PreTrmF", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PARAM_PRE", "PreTrmF");
            DropColumn("dbo.TBL_PARAM_PN", "PpTrmF");
        }
    }
}
