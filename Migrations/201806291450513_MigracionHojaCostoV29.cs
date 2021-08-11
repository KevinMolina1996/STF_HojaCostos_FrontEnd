namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV29 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TBL_PARAM_PN", "PpMayorUSDUtilF");
            DropColumn("dbo.TBL_PARAM_PN", "PpAlmacenLineaAdminF");
            DropColumn("dbo.TBL_PARAM_PN", "PpAlmacenLineaFinanF");
            DropColumn("dbo.TBL_PARAM_PN", "PpMayorUSDFinanF");
            DropColumn("dbo.TBL_PARAM_PN", "PpAlmacenLineaMercadeoF");
            DropColumn("dbo.TBL_PARAM_PN", "PpMayorUSDMercadeoF");
            DropColumn("dbo.TBL_PARAM_PN", "PpAlmacenLineaVntsF");
            DropColumn("dbo.TBL_PARAM_PN", "PpMayorUSDVntsF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_PARAM_PN", "PpMayorUSDVntsF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpAlmacenLineaVntsF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpMayorUSDMercadeoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpAlmacenLineaMercadeoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpMayorUSDFinanF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpAlmacenLineaFinanF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpAlmacenLineaAdminF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpMayorUSDUtilF", c => c.Double(nullable: false));
        }
    }
}
