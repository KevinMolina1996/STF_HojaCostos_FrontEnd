namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov69 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_CONSUMO_TELAS", "CtUnidadS", c => c.String(maxLength: 10));
            AddColumn("dbo.TBL_CONSUMO_TELAS", "CtRendimientoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_INS_ACC", "IaUnidadS", c => c.String(maxLength: 10));
            AddColumn("dbo.TBL_INS_ACC", "IaRendimientoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpFactorInsumoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpFactorTelaF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PRE_CONSUMO_TELAS", "PreCtUnidadS", c => c.String(maxLength: 10));
            AddColumn("dbo.TBL_PRE_CONSUMO_TELAS", "PreCtRendimientoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PRE_INS_ACC", "PreIaUnidadS", c => c.String(maxLength: 10));
            AddColumn("dbo.TBL_PRE_INS_ACC", "PreIaRendimientoF", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PRE_INS_ACC", "PreIaRendimientoF");
            DropColumn("dbo.TBL_PRE_INS_ACC", "PreIaUnidadS");
            DropColumn("dbo.TBL_PRE_CONSUMO_TELAS", "PreCtRendimientoF");
            DropColumn("dbo.TBL_PRE_CONSUMO_TELAS", "PreCtUnidadS");
            DropColumn("dbo.TBL_PARAM_PN", "PpFactorTelaF");
            DropColumn("dbo.TBL_PARAM_PN", "PpFactorInsumoF");
            DropColumn("dbo.TBL_INS_ACC", "IaRendimientoF");
            DropColumn("dbo.TBL_INS_ACC", "IaUnidadS");
            DropColumn("dbo.TBL_CONSUMO_TELAS", "CtRendimientoF");
            DropColumn("dbo.TBL_CONSUMO_TELAS", "CtUnidadS");
        }
    }
}
