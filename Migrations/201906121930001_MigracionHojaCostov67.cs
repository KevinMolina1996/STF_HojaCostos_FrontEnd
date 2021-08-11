namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov67 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_FORMULA_PRE",
                c => new
                    {
                        FoCodigoN = c.Int(nullable: false, identity: true),
                        FoCampoS = c.String(),
                        FoNombreS = c.String(),
                        FoOperacionS = c.String(),
                        FoConsultaS = c.String(),
                        FoConsultaSQLiteS = c.String(),
                        FoCampoReferenciaS = c.String(),
                        FoOrdenEjecucionN = c.Int(nullable: false),
                        FoTablaReferenciaN = c.String(),
                        FoFecCreD = c.DateTime(nullable: false),
                        FoFecActD = c.DateTime(),
                    })
                .PrimaryKey(t => t.FoCodigoN);
            
            CreateTable(
                "dbo.TBL_PARAM_PRE",
                c => new
                    {
                        PreCodigoN = c.Int(nullable: false, identity: true),
                        PreColeccionS = c.String(),
                        PreMarcaS = c.String(),
                        PreLineaS = c.String(),
                        PreSubLineaS = c.String(),
                        PreFactorS = c.String(),
                        PreGastosAdminF = c.Double(nullable: false),
                        PreGastosFinanF = c.Double(nullable: false),
                        PreGastosMercadeoF = c.Double(nullable: false),
                        PreIvaF = c.Double(nullable: false),
                        PreAdminxFinanF = c.Double(nullable: false),
                        PreMercadeoF = c.Double(nullable: false),
                        PreVntsxCanalLineaF = c.Double(nullable: false),
                        PreAlmacenLineaCanalF = c.Double(nullable: false),
                        PreTopeCostoF = c.Double(nullable: false),
                        PreFactorRentabilidadMaxF = c.Double(nullable: false),
                        PreFactorRentabilidadMinF = c.Double(nullable: false),
                        PreEnterPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreMediumPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrePremiumPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreCocienteDivisorF = c.Double(nullable: false),
                        PreCocienteDivisor2F = c.Double(nullable: false),
                        PreResiduoDivisorF = c.Double(nullable: false),
                        PreTopePrecioMilesF = c.Double(nullable: false),
                        PrePrecioMinimoF = c.Double(nullable: false),
                        PrePrecioMaximoF = c.Double(nullable: false),
                        PreTerminoPrecioF = c.Double(nullable: false),
                        PreParticipacionAdminF = c.Double(nullable: false),
                        PreParticipacionFinanF = c.Double(nullable: false),
                        PreParticipacionMercadeoF = c.Double(nullable: false),
                        PreFactorInsumoF = c.Double(nullable: false),
                        PreFactorTelaF = c.Double(nullable: false),
                        PreFecCreD = c.DateTime(nullable: false),
                        PreFecActD = c.DateTime(),
                        PreUsuActS = c.String(),
                    })
                .PrimaryKey(t => t.PreCodigoN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBL_PARAM_PRE");
            DropTable("dbo.TBL_FORMULA_PRE");
        }
    }
}
