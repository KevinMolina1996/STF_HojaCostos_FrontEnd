namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionFinal_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_PARAM_PN", "ID_Coleccion", c => c.Int());
            AddColumn("dbo.TBL_PARAM_PN", "ID_Linea", c => c.Int());
            AddColumn("dbo.TBL_PARAM_PN", "ID_Sublinea", c => c.Int());
            AddColumn("dbo.TBL_PARAM_PNP", "ID_Coleccion", c => c.Int());
            AddColumn("dbo.TBL_PARAM_PNP", "ID_Linea", c => c.Int());
            AddColumn("dbo.TBL_PARAM_PNP", "ID_Sublinea", c => c.Int());
            AddColumn("dbo.TBL_PARAM_PRE", "ID_Coleccion", c => c.Int());
            AddColumn("dbo.TBL_PARAM_PRE", "ID_Linea", c => c.Int());
            AddColumn("dbo.TBL_PARAM_PRE", "ID_Sublinea", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_PARAM_PRE", "ID_Sublinea");
            DropColumn("dbo.TBL_PARAM_PRE", "ID_Linea");
            DropColumn("dbo.TBL_PARAM_PRE", "ID_Coleccion");
            DropColumn("dbo.TBL_PARAM_PNP", "ID_Sublinea");
            DropColumn("dbo.TBL_PARAM_PNP", "ID_Linea");
            DropColumn("dbo.TBL_PARAM_PNP", "ID_Coleccion");
            DropColumn("dbo.TBL_PARAM_PN", "ID_Sublinea");
            DropColumn("dbo.TBL_PARAM_PN", "ID_Linea");
            DropColumn("dbo.TBL_PARAM_PN", "ID_Coleccion");
        }
    }
}
