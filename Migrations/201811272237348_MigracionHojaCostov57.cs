namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov57 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TBL_REF_SINC");
            AlterColumn("dbo.TBL_REF_SINC", "RsReferenciaS", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.TBL_REF_SINC", "RsReferenciaS");
            DropColumn("dbo.TBL_REF_SINC", "RsCodigoN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_REF_SINC", "RsCodigoN", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.TBL_REF_SINC");
            AlterColumn("dbo.TBL_REF_SINC", "RsReferenciaS", c => c.String(maxLength: 20));
            AddPrimaryKey("dbo.TBL_REF_SINC", "RsCodigoN");
        }
    }
}
