namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio_campo_int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_PARAM_PN", "PpResiduoDivisorF", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_PARAM_PN", "PpResiduoDivisorF", c => c.Double(nullable: false));
        }
    }
}
