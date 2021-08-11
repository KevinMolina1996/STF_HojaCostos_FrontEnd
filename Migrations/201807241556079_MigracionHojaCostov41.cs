namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_PARAM_PNP", "PnPorcGastosRealF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnPorcGastosEstimadoF", c => c.Double(nullable: false));
            DropColumn("dbo.TBL_PARAM_PNP", "PnPorcGastosF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_PARAM_PNP", "PnPorcGastosF", c => c.Double(nullable: false));
            DropColumn("dbo.TBL_PARAM_PNP", "PnPorcGastosEstimadoF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnPorcGastosRealF");
        }
    }
}
