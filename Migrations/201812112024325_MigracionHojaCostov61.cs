namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov61 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_FORMULA", "FoOrdenEjecucionN", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_FORMULA_PNP", "FoOrdenEjecucionN", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_FORMULA_PNP", "FoOrdenEjecucionN");
            DropColumn("dbo.TBL_FORMULA", "FoOrdenEjecucionN");
        }
    }
}
