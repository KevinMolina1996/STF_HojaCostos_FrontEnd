namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio_parametro_int_precosteo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_PARAM_PRE", "PreResiduoDivisorF", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_PARAM_PRE", "PreResiduoDivisorF", c => c.Double(nullable: false));
        }
    }
}
