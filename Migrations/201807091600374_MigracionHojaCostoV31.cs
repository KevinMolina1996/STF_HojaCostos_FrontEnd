namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_PARAM_PN", "PpParticipacionAdminF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpParticipacionFinanF", c => c.Double(nullable: false));
            AddColumn("dbo.TBL_PARAM_PN", "PpParticipacionMercadeoF", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PARAM_PN", "PpParticipacionMercadeoF");
            DropColumn("dbo.TBL_PARAM_PN", "PpParticipacionFinanF");
            DropColumn("dbo.TBL_PARAM_PN", "PpParticipacionAdminF");
        }
    }
}
