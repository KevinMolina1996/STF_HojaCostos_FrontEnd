namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMarcaS", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpAvalS", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpAvalS");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMarcaS");
        }
    }
}
