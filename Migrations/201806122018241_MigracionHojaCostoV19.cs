namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcImgMarcaS", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcImgMarcaS");
        }
    }
}
