namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov62 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_FORMULA", "FoTablaReferenciaN", c => c.String());
            AddColumn("dbo.TBL_FORMULA_PNP", "FoTablaReferenciaN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_FORMULA_PNP", "FoTablaReferenciaN");
            DropColumn("dbo.TBL_FORMULA", "FoTablaReferenciaN");
        }
    }
}
