namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov68 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_CAMPOS_FORMULAS_PRE",
                c => new
                    {
                        CfCogidoN = c.Int(nullable: false, identity: true),
                        CfNomBdS = c.String(maxLength: 100),
                        CfNomViewS = c.String(maxLength: 100),
                        CfDescS = c.String(maxLength: 100),
                        CfFecCreD = c.DateTime(nullable: false),
                        CfClaseS = c.String(maxLength: 100),
                        CfOrderN = c.Int(nullable: false),
                        CfGroupS = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CfCogidoN);
            
            CreateTable(
                "dbo.TBL_OPERACIONES_FORMULAS_PRE",
                c => new
                    {
                        OfCodigoN = c.Int(nullable: false, identity: true),
                        OfNombreS = c.String(maxLength: 100),
                        OfDescS = c.String(maxLength: 100),
                        OfColorS = c.String(maxLength: 100),
                        OfFecCreD = c.DateTime(nullable: false),
                        OfClaseS = c.String(maxLength: 100),
                        OfOrderN = c.Int(nullable: false),
                        OfGroupS = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.OfCodigoN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBL_OPERACIONES_FORMULAS_PRE");
            DropTable("dbo.TBL_CAMPOS_FORMULAS_PRE");
        }
    }
}
