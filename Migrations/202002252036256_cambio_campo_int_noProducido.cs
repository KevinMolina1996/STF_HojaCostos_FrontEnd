namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio_campo_int_noProducido : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_PARAM_PNP", "PnDivisorResiduoF", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_PARAM_PNP", "PnDivisorResiduoF", c => c.Double(nullable: false));
        }
    }
}
