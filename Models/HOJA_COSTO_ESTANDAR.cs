using System.Collections.Generic;

namespace AppWebHojaCosto.Models
{
    public class HOJA_COSTO_ESTANDAR
    {
        public List<TBL_HOJA_COSTO_PN> TBL_HOJA_COSTO_PN { get; set; }
        public List<TBL_CONSUMO_TELAS> TBL_CONSUMO_TELAS { get; set; }
        public List<TBL_PROCESO> TBL_PROCESO { get; set; }
        public List<TBL_INS_ACC> TBL_INS_ACC { get; set; }
        public List<TBL_ETIQ_MAR_EMP> TBL_ETIQ_MAR_EMP { get; set; }
        public List<TBL_MOD_CIF> TBL_MOD_CIF { get; set; }
        public List<TBL_RES_GEN_COS_PRD> TBL_RES_GEN_COS_PRD { get; set; }
        public List<TBL_RES_GAS_COS_DIS> TBL_RES_GAS_COS_DIS { get; set; }
        public List<TBL_ANALISIS_PREC> TBL_ANALISIS_PREC { get; set; }
    }

    public class HOJA_COSTO_SIMULADA
    {
        public TBL_SIM_HOJA_COSTO_PN TBL_SIM_HOJA_COSTO_PN { get; set; }
        public List<TBL_SIM_CONSUMO_TELAS> TBL_SIM_CONSUMO_TELAS { get; set; }
        public List<TBL_SIM_PROCESO> TBL_SIM_PROCESO { get; set; }
        public List<TBL_SIM_INS_ACC> TBL_SIM_INS_ACC { get; set; }
        public List<TBL_SIM_ETIQ_MAR_EMP> TBL_SIM_ETIQ_MAR_EMP { get; set; }
        public TBL_SIM_MOD_CIF TBL_SIM_MOD_CIF { get; set; }
        public TBL_SIM_RES_GEN_COS_PRD TBL_SIM_RES_GEN_COS_PRD { get; set; }
        public TBL_SIM_RES_GAS_COS_DIS TBL_SIM_RES_GAS_COS_DIS { get; set; }
        public TBL_SIM_ANALISIS_PREC TBL_SIM_ANALISIS_PREC { get; set; }
    }

    /// <summary>
    /// CLASE UTILIZADA PARA LA GENERACION DEL REPORTE
    /// </summary>
    public class LST_HOJA_COSTO_SIMULADA
    {
        public List<TBL_SIM_HOJA_COSTO_PN> TBL_SIM_HOJA_COSTO_PN { get; set; }
        public List<TBL_SIM_CONSUMO_TELAS> TBL_SIM_CONSUMO_TELAS { get; set; }
        public List<TBL_SIM_PROCESO> TBL_SIM_PROCESO { get; set; }
        public List<TBL_SIM_INS_ACC> TBL_SIM_INS_ACC { get; set; }
        public List<TBL_SIM_ETIQ_MAR_EMP> TBL_SIM_ETIQ_MAR_EMP { get; set; }
        public List<TBL_SIM_MOD_CIF> TBL_SIM_MOD_CIF { get; set; }
        public List<TBL_SIM_RES_GEN_COS_PRD> TBL_SIM_RES_GEN_COS_PRD { get; set; }
        public List<TBL_SIM_RES_GAS_COS_DIS> TBL_SIM_RES_GAS_COS_DIS { get; set; }
        public List<TBL_SIM_ANALISIS_PREC> TBL_SIM_ANALISIS_PREC { get; set; }
    }

    public class HOJA_COSTO_PRECOSTEO
    {
        public TBL_PRE_HOJA_COSTO_PN TBL_PRE_HOJA_COSTO_PN { get; set; }
        public List<TBL_PRE_CONSUMO_TELAS> TBL_PRE_CONSUMO_TELAS { get; set; }
        public List<TBL_PRE_PROCESO> TBL_PRE_PROCESO { get; set; }
        public List<TBL_PRE_INS_ACC> TBL_PRE_INS_ACC { get; set; }
        public List<TBL_PRE_ETIQ_MAR_EMP> TBL_PRE_ETIQ_MAR_EMP { get; set; }
        public TBL_PRE_MOD_CIF TBL_PRE_MOD_CIF { get; set; }
        public TBL_PRE_RES_GEN_COS_PRD TBL_PRE_RES_GEN_COS_PRD { get; set; }
        public TBL_PRE_RES_GAS_COS_DIS TBL_PRE_RES_GAS_COS_DIS { get; set; }
        public TBL_PRE_ANALISIS_PREC TBL_PRE_ANALISIS_PREC { get; set; }
    }

    /// <summary>
    /// CLASE UTILIZADA PARA LE GENERACION DEL REPORTE
    /// </summary>
    public class LST_HOJA_COSTO_PRECOSTEO
    {
        public List<TBL_PRE_HOJA_COSTO_PN> TBL_PRE_HOJA_COSTO_PN { get; set; }
        public List<TBL_PRE_CONSUMO_TELAS> TBL_PRE_CONSUMO_TELAS { get; set; }
        public List<TBL_PRE_PROCESO> TBL_PRE_PROCESO { get; set; }
        public List<TBL_PRE_INS_ACC> TBL_PRE_INS_ACC { get; set; }
        public List<TBL_PRE_ETIQ_MAR_EMP> TBL_PRE_ETIQ_MAR_EMP { get; set; }
        public List<TBL_PRE_MOD_CIF> TBL_PRE_MOD_CIF { get; set; }
        public List<TBL_PRE_RES_GEN_COS_PRD> TBL_PRE_RES_GEN_COS_PRD { get; set; }
        public List<TBL_PRE_RES_GAS_COS_DIS> TBL_PRE_RES_GAS_COS_DIS { get; set; }
        public List<TBL_PRE_ANALISIS_PREC> TBL_PRE_ANALISIS_PREC { get; set; }
    }
}