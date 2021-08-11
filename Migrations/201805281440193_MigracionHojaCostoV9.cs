namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "PnpCodigoN", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "PnpCodigoN");
        }
    }
}
