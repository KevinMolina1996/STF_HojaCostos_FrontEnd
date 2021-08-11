using AppWebHojaCosto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppWebHojaCosto.Context
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext()
            :base("bdHojaCostos")
        {

        }
        public DbSet<TBL_PARAM_PN> TBL_PARAM_PN { get; set; }
        public DbSet<TBL_PARAM_PNP> TBL_PARAM_PNP { get; set; }
        public DbSet<TBL_ALERTA> TBL_ALERTA { get; set; }
        public DbSet<TBL_FORMULA> TBL_FORMULA { get; set; }
        public DbSet<TBL_HOJA_COSTO_PN> TBL_HOJA_COSTO_PN { get; set; }
        public DbSet<TBL_CONSUMO_TELAS> TBL_CONSUMO_TELAS { get; set; }
        public DbSet<TBL_PROCESO> TBL_PROCESO { get; set; }
        public DbSet<TBL_INS_ACC> TBL_INS_ACC { get; set; }
        public DbSet<TBL_ETIQ_MAR_EMP> TBL_ETIQ_MAR_EMP { get; set; }
        public DbSet<TBL_MOD_CIF> TBL_MOD_CIF { get; set; }
        public DbSet<TBL_RES_GEN_COS_PRD> TBL_RES_GEN_COS_PRD { get; set; }
        public DbSet<TBL_RES_GAS_COS_DIS> TBL_RES_GAS_COS_DIS { get; set; }
        public DbSet<TBL_ANALISIS_PREC> TBL_ANALISIS_PREC { get; set; }
        public DbSet<TBL_HOJA_COSTO_PNP> TBL_HOJA_COSTO_PNP { get; set; }
        public DbSet<TBL_SIM_HOJA_COSTO_PNP> TBL_SIM_HOJA_COSTO_PNP { get; set; }
        //HOJA DE COSTO PRODUCIDO SIMULADA
        public DbSet<TBL_SIM_HOJA_COSTO_PN> TBL_SIM_HOJA_COSTO_PN { get; set; }
        public DbSet<TBL_SIM_CONSUMO_TELAS> TBL_SIM_CONSUMO_TELAS { get; set; }
        public DbSet<TBL_SIM_PROCESO> TBL_SIM_PROCESO { get; set; }
        public DbSet<TBL_SIM_INS_ACC> TBL_SIM_INS_ACC { get; set; }
        public DbSet<TBL_SIM_ETIQ_MAR_EMP> TBL_SIM_ETIQ_MAR_EMP { get; set; }
        public DbSet<TBL_SIM_MOD_CIF> TBL_SIM_MOD_CIF { get; set; }
        public DbSet<TBL_SIM_RES_GEN_COS_PRD> TBL_SIM_RES_GEN_COS_PRD { get; set; }
        public DbSet<TBL_SIM_RES_GAS_COS_DIS> TBL_SIM_RES_GAS_COS_DIS { get; set; }
        public DbSet<TBL_SIM_ANALISIS_PREC> TBL_SIM_ANALISIS_PREC { get; set; }
        //HOJA DE COSTO PRODUCIDO PRECOSTEO
        public DbSet<TBL_PRE_HOJA_COSTO_PN> TBL_PRE_HOJA_COSTO_PN { get; set; }
        public DbSet<TBL_PRE_CONSUMO_TELAS> TBL_PRE_CONSUMO_TELAS { get; set; }
        public DbSet<TBL_PRE_PROCESO> TBL_PRE_PROCESO { get; set; }
        public DbSet<TBL_PRE_INS_ACC> TBL_PRE_INS_ACC { get; set; }
        public DbSet<TBL_PRE_ETIQ_MAR_EMP> TBL_PRE_ETIQ_MAR_EMP { get; set; }
        public DbSet<TBL_PRE_MOD_CIF> TBL_PRE_MOD_CIF { get; set; }
        public DbSet<TBL_PRE_RES_GEN_COS_PRD> TBL_PRE_RES_GEN_COS_PRD { get; set; }
        public DbSet<TBL_PRE_RES_GAS_COS_DIS> TBL_PRE_RES_GAS_COS_DIS { get; set; }
        public DbSet<TBL_PRE_ANALISIS_PREC> TBL_PRE_ANALISIS_PREC { get; set; }
        //PARAMETRO DE ENTRADA DE LA FORMULA
        public DbSet<TBL_CAMPOS_FORMULAS> TBL_CAMPOS_FORMULAS { get; set; }
        public DbSet<TBL_OPERACIONES_FORMULAS> TBL_OPERACIONES_FORMULAS { get; set; }
        public DbSet<TBL_CAMPOS_FORMULAS_PRE> TBL_CAMPOS_FORMULAS_PRE { get; set; }
        public DbSet<TBL_OPERACIONES_FORMULAS_PRE> TBL_OPERACIONES_FORMULAS_PRE { get; set; }
        public DbSet<TBL_CAMPOS_FORMULAS_PNP> TBL_CAMPOS_FORMULAS_PNP { get; set; }
        public DbSet<TBL_FORMULA_PNP> TBL_FORMULA_PNP { get; set; }
        //TABLA GUARDAR FECHAS DASHBOARD LVL1
        public DbSet<TBL_FECHAS_DASHBOARD> TBL_FECHAS_DASHBOARD { get; set; }
        //TABLA REFERENCIAS A SINCRONIZAR EN PROCESO NOCTURNO
        public DbSet<TBL_REF_SINC> TBL_REF_SINC { get; set; }
        //TABLA COTIZACIONES
        public DbSet<TBL_CARGUE_COTIZACION_TELA> TBL_CARGUE_COTIZACION_TELA { get; set; }
        public DbSet<TBL_CARGUE_COTIZACION_INSUMO> TBL_CARGUE_COTIZACION_INSUMO { get; set; }
        //TABLA PARAMETRIZACION PRECOSTEO
        public DbSet<TBL_PARAM_PRE> TBL_PARAM_PRE { get; set; }
        public DbSet<TBL_FORMULA_PRE> TBL_FORMULA_PRE { get; set; }
    }
}