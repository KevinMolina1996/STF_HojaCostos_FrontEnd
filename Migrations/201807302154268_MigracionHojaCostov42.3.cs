namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov423 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_PARAM_PNP", "PnEnterpriceM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PARAM_PNP", "PnMediumPriceM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PARAM_PNP", "PnPremiumPriceM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PARAM_PNP", "PnPinSeguridadF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnGastosOrigenF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnGastosFleteF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnArancelF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnSeguroIntF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnGastosDestF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnOtrosGastosF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnTRMF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnGastosEstimadoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnGastosRealesM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PARAM_PNP", "PnGastosRealesM");
            DropColumn("dbo.TBL_PARAM_PNP", "PnGastosEstimadoF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnTRMF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnOtrosGastosF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnGastosDestF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnSeguroIntF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnArancelF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnGastosFleteF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnGastosOrigenF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnPinSeguridadF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnPremiumPriceM");
            DropColumn("dbo.TBL_PARAM_PNP", "PnMediumPriceM");
            DropColumn("dbo.TBL_PARAM_PNP", "PnEnterpriceM");
        }
    }
}
