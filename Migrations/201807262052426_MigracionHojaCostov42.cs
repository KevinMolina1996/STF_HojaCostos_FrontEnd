namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov42 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TBL_PARAM_PN", "PpMargenMinF");
            DropColumn("dbo.TBL_PARAM_PN", "PpMargenMaxF");
            DropColumn("dbo.TBL_PARAM_PN", "PpTasaColeccionF");
            DropColumn("dbo.TBL_PARAM_PN", "PpTasaEspecialF");
            DropColumn("dbo.TBL_PARAM_PN", "PpTasaCambioEURxUSDF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_PARAM_PN", "PpTasaCambioEURxUSDF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpTasaEspecialF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpTasaColeccionF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpMargenMaxF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpMargenMinF", c => c.Double(nullable: false));
        }
    }
}
