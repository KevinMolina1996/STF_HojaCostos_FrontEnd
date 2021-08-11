namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionFinPnp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpUsuCostoS", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpUsuCostoS", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
