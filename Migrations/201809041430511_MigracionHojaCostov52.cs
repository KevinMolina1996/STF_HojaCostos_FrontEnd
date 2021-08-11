namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov52 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdMarcaS", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdColeccionS", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdTipoInventarioS", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana1S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana2S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana3S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana4S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana5S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana6S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana7S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana8S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana9S", c => c.String());
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana10S", c => c.String());
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdFechasS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_FECHAS_DASHBOARD", "FdFechasS", c => c.String());
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana10S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana9S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana8S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana7S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana6S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana5S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana4S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana3S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana2S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdSemana1S");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdTipoInventarioS");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdColeccionS");
            DropColumn("dbo.TBL_FECHAS_DASHBOARD", "FdMarcaS");
        }
    }
}
