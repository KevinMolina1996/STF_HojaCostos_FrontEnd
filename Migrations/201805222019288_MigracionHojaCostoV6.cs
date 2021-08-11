namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpEstadoS", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpUsuCostoS", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpOrdenCompraS", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpOrdenCompraS");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpUsuCostoS");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpEstadoS");
        }
    }
}
