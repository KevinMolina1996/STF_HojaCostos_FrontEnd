namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV36 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TBL_PARAM_PNP", "PnGastosEstimadoF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnGastosRealesM");
            DropColumn("dbo.TBL_PARAM_PNP", "PnTRMF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_PARAM_PNP", "PnTRMF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnGastosRealesM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PARAM_PNP", "PnGastosEstimadoF", c => c.Double(nullable: false));
        }
    }
}
