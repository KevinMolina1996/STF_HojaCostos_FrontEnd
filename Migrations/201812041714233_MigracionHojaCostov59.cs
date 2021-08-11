namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov59 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_HOJA_COSTO_PN", "HcDisenadorS", c => c.String(maxLength: 50));
            AlterColumn("dbo.TBL_HOJA_COSTO_PN", "HcPatronistaS", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_HOJA_COSTO_PN", "HcPatronistaS", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.TBL_HOJA_COSTO_PN", "HcDisenadorS", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
