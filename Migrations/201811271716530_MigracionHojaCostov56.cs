namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov56 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_REF_SINC", "RsReferenciaS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_REF_SINC", "RsTipoInventarioS", c => c.String(maxLength: 20));
            DropColumn("dbo.TBL_REF_SINC", "RsColeccionS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_REF_SINC", "RsColeccionS", c => c.String(maxLength: 20));
            DropColumn("dbo.TBL_REF_SINC", "RsTipoInventarioS");
            DropColumn("dbo.TBL_REF_SINC", "RsReferenciaS");
        }
    }
}
