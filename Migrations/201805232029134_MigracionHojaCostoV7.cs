namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpEnterPriceM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMediumPriceM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPremiumPriceM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPremiumPriceM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMediumPriceM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpEnterPriceM");
        }
    }
}
