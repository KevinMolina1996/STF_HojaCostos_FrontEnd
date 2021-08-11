namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV375 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_PARAM_PNP", "PnPorcGastosF", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PARAM_PNP", "PnPorcGastosF");
        }
    }
}
