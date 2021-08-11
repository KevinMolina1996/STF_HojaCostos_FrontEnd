namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcDescripcionS", c => c.String(maxLength: 200));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcUsuCostoS", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcUsuCostoS");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcDescripcionS");
        }
    }
}
