namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionFinal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Coleccion", c => c.Int());
            AlterColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Linea", c => c.Int());
            AlterColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Sublinea", c => c.Int());
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Coleccion", c => c.Int());
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Linea", c => c.Int());
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Sublinea", c => c.Int());
            AlterColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Coleccion", c => c.Int());
            AlterColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Linea", c => c.Int());
            AlterColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Sublinea", c => c.Int());
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Coleccion", c => c.Int());
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Linea", c => c.Int());
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Sublinea", c => c.Int());
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Coleccion", c => c.Int());
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Linea", c => c.Int());
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Sublinea", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Sublinea", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Linea", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "ID_Coleccion", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Sublinea", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Linea", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PN", "ID_Coleccion", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Sublinea", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Linea", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "ID_Coleccion", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Sublinea", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Linea", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "ID_Coleccion", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Sublinea", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Linea", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_HOJA_COSTO_PN", "ID_Coleccion", c => c.Int(nullable: false));
        }
    }
}
