namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov54 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TBL_HOJA_COSTO_PNP");
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpCodigoN", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TBL_HOJA_COSTO_PNP", new[] { "PnpCodigoN", "PnpReferenciaS" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TBL_HOJA_COSTO_PNP");
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpCodigoN", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TBL_HOJA_COSTO_PNP", "PnpCodigoN");
        }
    }
}
