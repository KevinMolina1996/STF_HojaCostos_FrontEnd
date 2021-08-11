namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov60 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "SimHcDisenadorS", c => c.String(maxLength: 50));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "SimHcPatronistaS", c => c.String(maxLength: 50));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "SimHcUsuCostoS", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "SimHcUsuCostoS", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "SimHcPatronistaS", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "SimHcDisenadorS", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
