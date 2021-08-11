namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov65 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpEstadoS", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpEstadoS", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
