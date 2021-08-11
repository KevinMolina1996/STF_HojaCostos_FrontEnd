namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV38 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_PARAM_PNP", "PnDivisorCocienteDosF", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PARAM_PNP", "PnDivisorCocienteDosF");
        }
    }
}
