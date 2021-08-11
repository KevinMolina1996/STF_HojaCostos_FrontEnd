namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov66 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcPrecioD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcFechaAprobacionD", c => c.DateTime());
            AddColumn("dbo.TBL_PRE_CONSUMO_TELAS", "PreCtCodeS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_PRE_ETIQ_MAR_EMP", "PreEmeCodeS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_PRE_INS_ACC", "PreIaCodeS", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PRE_INS_ACC", "PreIaCodeS");
            DropColumn("dbo.TBL_PRE_ETIQ_MAR_EMP", "PreEmeCodeS");
            DropColumn("dbo.TBL_PRE_CONSUMO_TELAS", "PreCtCodeS");
            DropColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcFechaAprobacionD");
            DropColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcPrecioD");
        }
    }
}
