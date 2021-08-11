namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov44 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_FORMULA", "FoConsultaSQLiteS", c => c.String());
            DropColumn("dbo.TBL_FORMULA", "FoFormulaExcelS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_FORMULA", "FoFormulaExcelS", c => c.String());
            DropColumn("dbo.TBL_FORMULA", "FoConsultaSQLiteS");
        }
    }
}
