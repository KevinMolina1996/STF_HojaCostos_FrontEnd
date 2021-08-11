namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpImgMarcaS", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpImgMarcaS");
        }
    }
}
