namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_ALERTA", "AlColeccionS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_ALERTA", "AlMarcaS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_ALERTA", "AlLineaS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_ALERTA", "AlReferenciaS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_ALERTA", "AlDescripcionS", c => c.String(maxLength: 300));
            AddColumn("dbo.TBL_ALERTA", "AlAreaS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_ALERTA", "AlFechaD", c => c.DateTime(nullable: false));
            AddColumn("dbo.TBL_ALERTA", "AlCambioS", c => c.String(maxLength: 100));
            AddColumn("dbo.TBL_ALERTA", "AlValorAnteriorM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_ALERTA", "AlValorActualM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_ALERTA", "AlVariacionM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.TBL_ALERTA", "AlEstadoS", c => c.String(maxLength: 10));
            AlterColumn("dbo.TBL_ALERTA", "AlUsuarioS", c => c.String(maxLength: 50));
            DropColumn("dbo.TBL_ALERTA", "AlMensajeS");
            DropColumn("dbo.TBL_ALERTA", "AlFecCreD");
            DropColumn("dbo.TBL_ALERTA", "AlTituloS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_ALERTA", "AlTituloS", c => c.String());
            AddColumn("dbo.TBL_ALERTA", "AlFecCreD", c => c.DateTime(nullable: false));
            AddColumn("dbo.TBL_ALERTA", "AlMensajeS", c => c.String());
            AlterColumn("dbo.TBL_ALERTA", "AlUsuarioS", c => c.String());
            AlterColumn("dbo.TBL_ALERTA", "AlEstadoS", c => c.String());
            DropColumn("dbo.TBL_ALERTA", "AlVariacionM");
            DropColumn("dbo.TBL_ALERTA", "AlValorActualM");
            DropColumn("dbo.TBL_ALERTA", "AlValorAnteriorM");
            DropColumn("dbo.TBL_ALERTA", "AlCambioS");
            DropColumn("dbo.TBL_ALERTA", "AlFechaD");
            DropColumn("dbo.TBL_ALERTA", "AlAreaS");
            DropColumn("dbo.TBL_ALERTA", "AlDescripcionS");
            DropColumn("dbo.TBL_ALERTA", "AlReferenciaS");
            DropColumn("dbo.TBL_ALERTA", "AlLineaS");
            DropColumn("dbo.TBL_ALERTA", "AlMarcaS");
            DropColumn("dbo.TBL_ALERTA", "AlColeccionS");
        }
    }
}
