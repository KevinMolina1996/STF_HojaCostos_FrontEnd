namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion_Finakl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Coleccion", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Linea", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Sublinea", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Coleccion", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Linea", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Sublinea", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Coleccion", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Linea", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Sublinea", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Coleccion", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Linea", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Sublinea", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Coleccion", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Linea", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Sublinea", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Sublinea");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Linea");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Coleccion");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Sublinea");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Linea");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Coleccion");
            DropColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Sublinea");
            DropColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Linea");
            DropColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Coleccion");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Sublinea");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Linea");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Coleccion");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Sublinea");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Linea");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Coleccion");
        }
    }
}
