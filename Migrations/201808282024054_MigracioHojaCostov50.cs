namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracioHojaCostov50 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_FECHAS_DASHBOARD",
                c => new
                    {
                        FdCodigoN = c.Int(nullable: false, identity: true),
                        FdTipoInventarioS = c.String(nullable: false),
                        FdUsuarioS = c.String(nullable: false),
                        FdSemana1S = c.String(),
                        FdSemana2S = c.String(),
                        FdSemana3S = c.String(),
                        FdSemana4S = c.String(),
                        FdSemana5S = c.String(),
                        FdSemana6S = c.String(),
                        FdSemana7S = c.String(),
                        FdSemana8S = c.String(),
                        FdSemana9S = c.String(),
                        FdSemana10S = c.String(),
                        FdRefAprobadas1S = c.String(),
                        FdRefAprobadas2S = c.String(),
                        FdRefAprobadas3S = c.String(),
                        FdRefAprobadas4S = c.String(),
                        FdRefAprobadas5S = c.String(),
                        FdRefAprobadas6S = c.String(),
                        FdRefAprobadas7S = c.String(),
                        FdRefAprobadas8S = c.String(),
                        FdRefAprobadas9S = c.String(),
                        FdRefAprobadas10S = c.String(),
                    })
                .PrimaryKey(t => t.FdCodigoN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBL_FECHAS_DASHBOARD");
        }
    }
}
