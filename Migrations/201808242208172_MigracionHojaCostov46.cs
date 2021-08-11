namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov46 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioD");
        }
    }
}
