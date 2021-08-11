using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;

namespace AppWebHojaCosto.Services
{
    public class FormulaService
    {
        #region "Funciones TBL_FORMULA";


        public List<TBL_FORMULA> obtenerFormulas()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_FORMULA.Where(x => x.FoTablaReferenciaN != null).ToList();
            }
        }

        public List<TBL_FORMULA> obtenerFormulasPrecosteo()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_FORMULA.Where(x => x.FoTablaReferenciaN != null).ToList();
            }
        }

        public string actualizarFormula(TBL_FORMULA param)
        {
            string strMensaje = String.Empty;
            try
            {
                using (var db = new DataBaseContext())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_FORMULA.Attach(param);
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

            //try
            //{
            //    using (SQLiteConnection con = new SQLiteConnection("Data Source=" + filename + ";Version=3;"))
            //    {
            //        con.Open();

            //        string stm = "SELECT CAST(" + query + " AS VARCHAR)";

            //        using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
            //        {
            //            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            //            {
            //                while (rdr.Read())
            //                {
            //                    valor = rdr.GetString(0);
            //                }
            //            }
            //        }

            //        con.Close();
            //    }
            //    return valor;
            //}
            //catch(Exception ex)
            //{
            //    return "Error al realizar el calculo.";
            //}
            System.Data.DataTable dt = new System.Data.DataTable();
            Double value = 0;
            string conStr = ConfigurationManager.ConnectionStrings["bdHojaCostos"].ConnectionString;
            string sqlCommand = @"SELECT " + query;
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(sqlCommand, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    if (con.State != System.Data.ConnectionState.Open)
                    {
                        con.Open();
                    }
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        value = Convert.ToDouble(dt.Rows[0][0].ToString());
                    }
                    return value.ToString();
                }
            }
            catch (Exception ex)
            {
                mensaje = "La formula presenta errores logicos";
                throw new Exception(ex.Message);
            }
        }

        public string testFormulaSQLLite(String query, String url, ref string mensaje)
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
                return "Error al realizar el calculo.";
            }
        }

        #endregion;

        #region "Funciones TBL_OPERACIONES_FORMULA";

        public List<TBL_OPERACIONES_FORMULAS> obtenerOpeFormulas()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_OPERACIONES_FORMULAS.OrderBy(s => s.OfOrderN).ToList();
            }
        }

        #endregion;

        #region "Functiones TBL_CAMPOS_FORMULAS";

        public List<TBL_CAMPOS_FORMULAS> obtenerCamFormulas()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_CAMPOS_FORMULAS.OrderBy(s => s.CfGroupS).ToList();
            }
        }
        #endregion;

        #region "Funciones TBL_FORMULA_PNP";

        public List<TBL_FORMULA_PNP> obtenerFormulasPNP()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_FORMULA_PNP.Where(x => x.FoTablaReferenciaN != null).OrderBy(x => x.FoOrdenEjecucionN).ToList();
            }
        }

        public string actualizarFormulaPNP(TBL_FORMULA_PNP param)
        {
            string strMensaje = String.Empty;
            try
            {
                using (var db = new DataBaseContext())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_FORMULA_PNP.Attach(param);
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

        public string testFormulaPNP(String query, String url, ref string mensaje)
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
                return "Error al realizar el calculo.";
            }
        }

        #endregion "TBL_FORMULA_PNP";

        #region "Funciones TBL_CAMPOS_FORMULA_PNP";
        public List<TBL_CAMPOS_FORMULAS_PNP> obtenerCamFormulasPNP()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_CAMPOS_FORMULAS_PNP.OrderBy(s => s.CfGroupS).ToList();
            }
        }
        #endregion "TBL_CAMPOS_FORMULA_PNP";

    }
}