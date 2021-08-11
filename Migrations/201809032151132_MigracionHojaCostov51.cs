namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov51 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdFechasS", c => c.String());
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdTipoInventarioS");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdUsuarioS");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana1S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana2S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana3S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana4S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana5S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana6S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana7S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana8S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana9S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana10S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas1S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas2S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas3S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas4S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas5S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas6S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas7S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas8S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas9S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas10S");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas10S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas9S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas8S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas7S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas6S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas5S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas4S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas3S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas2S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdRefAprobadas1S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana10S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana9S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana8S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana7S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana6S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana5S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana4S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana3S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana2S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana1S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdUsuarioS", c => c.String(nullable: false));
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdTipoInventarioS", c => c.String(nullable: false));
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdFechasS");
        }
    }
}
