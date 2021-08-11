namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracioHojaCostov48 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcMaquilaF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcDespieceF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcMaquilaF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcDespieceF", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcDespieceF");
            DropColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcMaquilaF");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcDespieceF");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcMaquilaF");
        }
    }
}
