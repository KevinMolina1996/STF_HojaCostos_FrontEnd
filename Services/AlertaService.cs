using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppWebHojaCosto.Services
{
    public class AlertaService
    {
        public ALERTA ConsultarAlertas(string FechaInicio, string FechaFin, string Coleccion, string Marca, string Linea, string Referencia)
        {
            ALERTA alerta = new ALERTA();
            using (var db = new DataBaseContext())
            {
                DateTime dtFechaIni = Convert.ToDateTime(FechaInicio);
                DateTime dtFechaFin = Convert.ToDateTime(FechaFin);
                if (!String.IsNullOrEmpty(Referencia))
                {
                    alerta.TBL_ALERTA = db.TBL_ALERTA.Where(x => x.AlFechaD >= dtFechaIni && x.AlFechaD <= dtFechaFin
                                                        || x.AlFechaD >= dtFechaIni && x.AlFechaD <= dtFechaFin && x.AlColeccionS == Coleccion && x.AlMarcaS == Marca && x.AlLineaS == Linea && x.AlReferenciaS == Referencia)
                    .ToList();
                }
                else
                {
                    alerta.TBL_ALERTA = db.TBL_ALERTA.Where(x => x.AlFechaD >= dtFechaIni && x.AlFechaD <= dtFechaFin
                                                        || x.AlFechaD >= dtFechaIni && x.AlFechaD <= dtFechaFin && x.AlColeccionS == Coleccion && x.AlMarcaS == Marca && x.AlLineaS == Linea)
                    .ToList();
                }
                alerta.FechaInicio = FechaInicio;
                alerta.FechaFin = FechaFin;
                alerta.Linea = Linea;
                alerta.Marca = Marca;
                alerta.Coleccion = Coleccion;
                alerta.Referencia = Referencia;
                return alerta;
            }
        }

        public string LeerAlerta(int codigo)
        {
            using(var db = new DataBaseContext())
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                TBL_ALERTA _model = new TBL_ALERTA { AlCodigoN = codigo, AlLeidoS = "X" };
                db.TBL_ALERTA.Attach(_model);
                db.Entry(_model).Property(e => e.AlLeidoS).IsModified = true;
                db.SaveChanges();

                return "Proceso completado.";
            }
        }

        public List<string> ObtenerMarcas()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_ALERTA
                    .Select(x => x.AlMarcaS).Distinct().ToList();
            }
        }

        public List<string> ObtenerColeccion(string Marca)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_ALERTA.Where(x => x.AlMarcaS == Marca)
                    .Select(x => x.AlColeccionS).Distinct().ToList();
            }
        }

        public List<string> ObtenerLinea(string Marca, string Coleccion)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_ALERTA.Where(x => x.AlMarcaS == Marca && x.AlColeccionS == Coleccion)
                    .Select(x => x.AlLineaS).Distinct().ToList();
            }
        }

        public List<string> ObtenerReferencia(string Marca, string Coleccion, string Linea)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_ALERTA.Where(x => x.AlMarcaS == Marca && x.AlColeccionS == Coleccion && x.AlLineaS == Linea)
                    .Select(x => x.AlReferenciaS).Distinct().ToList();
            }
        }
    }
}