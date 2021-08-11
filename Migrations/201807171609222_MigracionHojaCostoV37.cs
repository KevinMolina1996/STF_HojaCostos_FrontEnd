namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV37 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_PARAM_PNP", "PnDivisorCocienteF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnDivisorResiduoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnTopeMinimoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnTopeMaximoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnValorVerdaderoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnValorFalsoF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PNP", "PnRedondeoF", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PARAM_PNP", "PnRedondeoF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnValorFalsoF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnValorVerdaderoF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnTopeMaximoF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnTopeMinimoF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnDivisorResiduoF");
            DropColumn("dbo.TBL_PARAM_PNP", "PnDivisorCocienteF");
        }
    }
}
