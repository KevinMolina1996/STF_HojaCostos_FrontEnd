namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio_parametro_aereo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_PARAM_PNP", "PnGastosFleteAereoF", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PARAM_PNP", "PnGastosFleteAereoF");
        }
    }
}
