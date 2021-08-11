namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov442 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_FORMULA_PNP", "FoConsultaSQLiteS", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_FORMULA_PNP", "FoConsultaSQLiteS");
        }
    }
}
