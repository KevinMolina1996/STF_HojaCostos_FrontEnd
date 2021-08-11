namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov422 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TBL_PARAM_PN", "PpMayorUSDAdminF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_PARAM_PN", "PpMayorUSDAdminF", c => c.Double(nullable: false));
        }
    }
}
