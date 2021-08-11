namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImgMarcaS", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImgMarcaS");
        }
    }
}
