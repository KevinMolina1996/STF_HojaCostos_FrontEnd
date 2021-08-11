namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov58 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_CONSUMO_TELAS", "CtCodeS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_ETIQ_MAR_EMP", "EmeCodeS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_INS_ACC", "IaCodeS", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_INS_ACC", "IaCodeS");
            DropColumn("dbo.TBL_ETIQ_MAR_EMP", "EmeCodeS");
            DropColumn("dbo.TBL_CONSUMO_TELAS", "CtCodeS");
        }
    }
}
