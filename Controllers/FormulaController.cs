using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using System;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class FormulaController : Controller
    {
        private FormulaService _services;

        public FormulaController()
        {
            _services = new FormulaService();
        }

        // GET: Formula
        public ActionResult Index()
        {
            ViewBag.tbl_campos_formula = _services.obtenerCamFormulas();
            ViewBag.tbl_operaciones_formula = _services.obtenerOpeFormulas();
            return View(_services.obtenerFormulas());
        }

        public PartialViewResult Formulador()
        {
            return PartialView("_Formulas");
        }

        [HttpPost]
        public ActionResult EjecutarFormula(String formula)
        {
            String mensaje = String.Empty;
            try
            {
                //Valido que la compilacion de la formula en SQL Server sea correcta
                string resultQuery = "0";
                String query = creacionQuery(formula);
                string url = HttpContext.Request.MapPath("~");
                resultQuery = _services.testFormulaSQL(query, url, ref mensaje);
                if (!String.IsNullOrEmpty(mensaje))
                {
                    return Json(new { error = "X", mensaje }, JsonRequestBehavior.AllowGet);
                }
                //Fin

                //Valido que la compilacion de la formula en Excel sea correcta
                //Double resultExcel = 0;
                //String excel = creacionFormulaExcel(formula);
                //resultExcel = _services.testFormulaExcel(excel, ref mensaje);
                //if (resultExcel.ToString().Contains("-"))
                //{
                //    return Json(new { error = "X", mensaje = "La formula presenta errores logicos" }, JsonRequestBehavior.AllowGet);
                //}
                return Json(new { mensaje = resultQuery }, JsonRequestBehavior.AllowGet);
                //Fin
            }
            catch (Exception ex)
            {
                return Json(new { error = "X", mensaje = mensaje }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GuardarFormula(String formula, Int32 codigo, String nombre, String fecha)
        {
            TBL_FORMULA param = new TBL_FORMULA();
            try
            {

                formula = formula.TrimEnd('|').Replace("\n", "");
                String query = creacionQuery(formula);
                String SQLite = creacionQuerySQLite(formula);

                param.FoCodigoN = codigo;
                param.FoNombreS = nombre;
                param.FoFecCreD = Convert.ToDateTime(fecha);
                param.FoFecActD = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                param.FoOperacionS = formula;
                param.FoConsultaS = query;
                param.FoConsultaSQLiteS = SQLite;
                String result = _services.actualizarFormula(param);

                formula = formula.Replace("~", " ").Replace("#", " ").Replace("|", " ");

                return Json(new { mensaje = result, formula = formula }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = "Ocurrio un error al procesar la información" }, JsonRequestBehavior.AllowGet);
            }
        }

        public string creacionQuery(String formula)
        {
            String consulta = String.Empty;
            formula = formula.Replace("~", "").Replace("#", "");
            String[] split = formula.Split('|');
            foreach (string val in split)
            {
                if (val == "SI") { consulta = consulta + "CASE WHEN "; }
                else if (val == "ENTONCES") { consulta = consulta + "THEN "; }
                else if (val == "SINO") { consulta = consulta + "ELSE "; }
                else if (val == "FIN SI") { consulta = consulta + "END "; }
                //else if (val == "COCIENTE") { consulta = consulta + "CONVERT(INT, "; }
                else if (val == "COCIENTE") { consulta = consulta + "CAST( "; }
                else if (val == ";") { consulta = consulta + "/ "; }
                else if (val == ":") { consulta += "% "; }
                else if (val == "FIN COCIENTE") { consulta = consulta + " AS INT) "; }
                //else if (val == "RESIDUO") { consulta = consulta + "CONVERT(INT, "; }
                else if (val == "RESIDUO") { consulta = consulta + "CAST( "; }
                /*else if (val == "FIN RESIDUO") { consulta = consulta + " % 10 ) "; }*/
                else if (val == "FIN RESIDUO") { consulta += " AS INT) "; }
                else if (val == "CONCATENAR") { consulta = consulta + "CAST( "; }
                else if (val == "FIN CONCATENAR") { consulta = consulta + " AS VARCHAR) + "; }
                else consulta = consulta + val + " ";
            }
            consulta = consulta.TrimEnd(' ').TrimEnd('+');
            //consulta = consulta.Replace("< ", "");
            //consulta = consulta.Replace("> ", "");
            return consulta;
        }

        public string creacionQuerySQLite(String formula)
        {
            String consulta = String.Empty;
            formula = formula.Replace("~", "").Replace("#", "");
            String[] split = formula.Split('|');
            foreach (string val in split)
            {
                if (val == "SI") { consulta = consulta + "CASE WHEN "; }
                else if (val == "ENTONCES") { consulta = consulta + "THEN "; }
                else if (val == "SINO") { consulta = consulta + "ELSE "; }
                else if (val == "FIN SI") { consulta = consulta + "END "; }
                //else if (val == "COCIENTE") { consulta = consulta + "CONVERT(INT, "; }
                else if (val == "COCIENTE") { consulta = consulta + "CAST( "; }
                else if (val == ";") { consulta = consulta + "/ "; }
                else if (val == ":") { consulta += "% "; }
                else if (val == "FIN COCIENTE") { consulta = consulta + " AS INT) "; }
                //else if (val == "RESIDUO") { consulta = consulta + "CONVERT(INT, "; }
                else if (val == "RESIDUO") { consulta = consulta + "CAST( "; }
                /*else if (val == "FIN RESIDUO") { consulta = consulta + " % 10 ) "; }*/
                else if (val == "FIN RESIDUO") { consulta += " AS INT) "; }
                else if (val == "CONCATENAR") { consulta = consulta + "CAST( "; }
                else if (val == "FIN CONCATENAR") { consulta = consulta + " AS VARCHAR) || "; }
                else consulta = consulta + val + " ";
            }
            consulta = consulta.TrimEnd(' ').TrimEnd('|');
            consulta = consulta.TrimEnd(' ').TrimEnd('|');
            consulta = consulta.Replace(" =", "=");
            return consulta;
        }

        //public string creacionFormulaExcel(String formula)
        //{
        //    String consulta = String.Empty;
        //    formula = formula.Replace("~", "").Replace("#", "");
        //    String[] split = formula.Split('|');
        //    foreach (string val in split)
        //    {
        //        if (val == "SI") { consulta = consulta + "IF( "; }
        //        else if (val == "ENTONCES") { consulta = consulta + ", "; }
        //        else if (val == "SINO") { consulta = consulta + ", "; }
        //        else if (val == "FIN SI") { consulta = consulta + ") "; }
        //        else if (val == "COCIENTE") { consulta = consulta + "QUOTIENT( "; }
        //        else if (val == ";") { consulta = consulta + ", "; }
        //        else if (val == "FIN COCIENTE") { consulta = consulta + ") "; }
        //        else if (val == "RESIDUO") { consulta = consulta + "MOD( "; }
        //        else if (val == ":") { consulta += ", "; }
        //        /*else if (val == "FIN RESIDUO") { consulta = consulta + " % 10 ) "; }*/
        //        else if (val == "FIN RESIDUO") { consulta += ") "; }
        //        else if (val == "CONCATENAR") { consulta = consulta + "CONCATENATE( "; }
        //        else if (val == "FIN CONCATENAR") { consulta = consulta + ") & "; }
        //        else consulta = consulta + val + " ";
        //    }
        //    consulta = consulta.TrimEnd(' ').TrimEnd('&');
        //    consulta = consulta.Replace(" ", "");
        //    return consulta;
        //}
    }
}