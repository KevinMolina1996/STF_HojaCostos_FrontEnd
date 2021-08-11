using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace AppWebHojaCosto.Services
{
    public class FormulaPrecosteoService
    {
        #region "Funciones TBL_FORMULA";


        public List<TBL_FORMULA_PRE> obtenerFormulas()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_FORMULA_PRE.ToList();
            }
        }

        public List<TBL_FORMULA_PRE> obtenerFormulasPrecosteo()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_FORMULA_PRE.Where(x => !x.FoNombreS.Contains("Real")).ToList();
            }
        }

        public string actualizarFormula(TBL_FORMULA_PRE param)
        {
            string strMensaje = String.Empty;
            try
            {
                using (var db = new DataBaseContext())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_FORMULA_PRE.Attach(param);
                    db.Entry(param).Property(x => x.FoNombreS).IsModified = true;
                    db.Entry(param).Property(x => x.FoFecCreD).IsModified = true;
                    db.Entry(param).Property(x => x.FoFecActD).IsModified = true;
                    db.Entry(param).Property(x => x.FoOperacionS).IsModified = true;
                    db.Entry(param).Property(x => x.FoConsultaS).IsModified = true;
                    db.Entry(param).Property(x => x.FoConsultaSQLiteS).IsModified = true;
                    db.SaveChanges();
                    strMensaje = "Registro actualizado correctamente";
                    return strMensaje;
                }
            }
            catch (Exception ex)
            {
                return strMensaje = ex.Message;
            }
        }

        public string testFormulaSQL(String query, String url, ref string mensaje)
        {
            string filename = url + "HojaCostos.sqlite";
            string valor = "0";

            try
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=" + filename + ";Version=3;"))
                {
                    con.Open();

                    string stm = "SELECT CAST(" + query + " AS VARCHAR)";

                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                valor = rdr.GetString(0);
                            }
                        }
                    }

                    con.Close();
                }
                return valor;
            }
            catch (Exception ex)
            {
                return "Error al realizar el calculo. " + ex.Message;
            }
        }

        #endregion;

        #region "Funciones TBL_OPERACIONES_FORMULA";

        public List<TBL_OPERACIONES_FORMULAS_PRE> obtenerOpeFormulas()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_OPERACIONES_FORMULAS_PRE.OrderBy(s => s.OfOrderN).ToList();
            }
        }

        #endregion;

        #region "Functiones TBL_CAMPOS_FORMULAS";

        public List<TBL_CAMPOS_FORMULAS_PRE> obtenerCamFormulas()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_CAMPOS_FORMULAS_PRE.OrderBy(s => s.CfGroupS).ToList();
            }
        }
        #endregion;

    }
}