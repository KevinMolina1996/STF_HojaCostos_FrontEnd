namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov63 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_CARGUE_COTIZACION_INSUMO",
                c => new
                    {
                        CiCodigoN = c.Int(nullable: false, identity: true),
                        CiReferenciaS = c.String(),
                        CiCodeS = c.String(),
                        CiNombreS = c.String(),
                        CiColorS = c.String(),
                        CiCostoS = c.Double(nullable: false),
                        CiConsumoS = c.Double(nullable: false),
                        CiTotalS = c.Double(nullable: false),
                        CiFechaCreD = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CiCodigoN);
            
            CreateTable(
                "dbo.TBL_CARGUE_COTIZACION_TELA",
                c => new
                    {
                        CtCodigoN = c.Int(nullable: false, identity: true),
                        CtReferenciaS = c.String(),
                        CtCodeS = c.String(),
                        CtNombreS = c.String(),
                        CtColorS = c.String(),
                        CtCostoS = c.Double(nullable: false),
                        CtConsumoS = c.Double(nullable: false),
                        CtTotalS = c.Double(nullable: false),
                        CtFechaCreD = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CtCodigoN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBL_CARGUE_COTIZACION_TELA");
            DropTable("dbo.TBL_CARGUE_COTIZACION_INSUMO");
        }
    }
}
