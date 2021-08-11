namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_ALERTA", "AlLeidoS", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_ALERTA", "AlLeidoS");
        }
    }
}
