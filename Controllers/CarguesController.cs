using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class CarguesController : Controller
    {
        private CargueService _services;

        public CarguesController()
        {
            _services = new CargueService();
        }

        // GET: Cargues
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargueRubros(string TipoCargue, string TipoHoja, FormCollection formCollection)
        {
            List<ERRORES_CARGA> lstErrores = new List<ERRORES_CARGA>();
            ERRORES_CARGA Errores = new ERRORES_CARGA();
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["Fichier1"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    int data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    using (ExcelPackage package = new ExcelPackage(file.InputStream))
                    {
                        ExcelWorksheets currentSheet = package.Workbook.Worksheets;
                        ExcelWorksheet workSheet = currentSheet.First();
                        int noOfCol = workSheet.Dimension.End.Column;
                        int noOfRow = workSheet.Dimension.End.Row;
                        int Retorno = 0;
                        //Falta agregar el usuario que lo creo, cuando se implemente el login
                        for (int rowIterator = 3; rowIterator <= noOfRow; rowIterator++)
                        {
                            string Referencia = workSheet.Cells[rowIterator, 1].Value.ToString();
                            //if (TipoHoja.Equals("Estandar"))
                            //{
                            //    if (TipoCargue.Equals("CargueTelas"))
                            //    {
                            //        if (workSheet.Cells[rowIterator, 2].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 2].Value.ToString())
                            //                && workSheet.Cells[rowIterator, 3].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 3].Value.ToString())
                            //                && workSheet.Cells[rowIterator, 4].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 4].Value.ToString())
                            //                && workSheet.Cells[rowIterator, 5].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 5].Value.ToString())
                            //                && workSheet.Cells[rowIterator, 6].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 6].Value.ToString())
                            //                && workSheet.Cells[rowIterator, 7].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 7].Value.ToString()))
                            //        {
                            //            TBL_CARGUE_COTIZACION_TELA model = new TBL_CARGUE_COTIZACION_TELA();
                            //            if (workSheet.Cells[rowIterator, 5].Value.GetType() == Type.GetType("System.Double")
                            //                && workSheet.Cells[rowIterator, 6].Value.GetType() == Type.GetType("System.Double")
                            //                && workSheet.Cells[rowIterator, 7].Value.GetType() == Type.GetType("System.Double"))
                            //            {
                            //                model = new TBL_CARGUE_COTIZACION_TELA
                            //                {
                            //                    CtReferenciaS = Referencia,
                            //                    CtCodeS = workSheet.Cells[rowIterator, 2].Value.ToString(),
                            //                    CtFechaCreD = DateTime.Now,
                            //                    CtNombreS = workSheet.Cells[rowIterator, 3].Value.ToString(),
                            //                    CtColorS = workSheet.Cells[rowIterator, 4].Value.ToString(),
                            //                    CtCostoS = Convert.ToDouble(workSheet.Cells[rowIterator, 5].Value),
                            //                    CtConsumoS = float.Parse(workSheet.Cells[rowIterator, 6].Value.ToString()),
                            //                    CtTotalS = Convert.ToDouble(workSheet.Cells[rowIterator, 7].Value)
                            //                };
                            //                Retorno = Retorno + _services.InsertarCotizacionTelas(model);
                            //            }
                            //            else
                            //            {
                            //                Errores = new ERRORES_CARGA
                            //                {
                            //                    Referencia = Referencia,
                            //                    Detalle = "El tipo de dato es erróneo",
                            //                    LineaError = rowIterator.ToString()
                            //                };
                            //                lstErrores.Add(Errores);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            Errores = new ERRORES_CARGA
                            //            {
                            //                Referencia = Referencia,
                            //                Detalle = "Existen campos vacíos",
                            //                LineaError = rowIterator.ToString()
                            //            };
                            //            lstErrores.Add(Errores);
                            //        }
                            //    }
                            //    if (TipoCargue.Equals("CargueInsumos"))
                            //    {
                            //        if (workSheet.Cells[rowIterator, 2].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 2].Value.ToString())
                            //                && workSheet.Cells[rowIterator, 3].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 3].Value.ToString())
                            //                && workSheet.Cells[rowIterator, 4].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 4].Value.ToString())
                            //                && workSheet.Cells[rowIterator, 5].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 5].Value.ToString())
                            //                && workSheet.Cells[rowIterator, 6].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 6].Value.ToString())
                            //                && workSheet.Cells[rowIterator, 7].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 7].Value.ToString()))
                            //        {
                            //            TBL_CARGUE_COTIZACION_INSUMO model = new TBL_CARGUE_COTIZACION_INSUMO();
                            //            if (workSheet.Cells[rowIterator, 5].Value.GetType() == Type.GetType("System.Double")
                            //                && workSheet.Cells[rowIterator, 6].Value.GetType() == Type.GetType("System.Double")
                            //                && workSheet.Cells[rowIterator, 7].Value.GetType() == Type.GetType("System.Double"))
                            //            {
                            //                model = new TBL_CARGUE_COTIZACION_INSUMO
                            //                {
                            //                    CiReferenciaS = Referencia,
                            //                    CiCodeS = workSheet.Cells[rowIterator, 2].Value.ToString(),
                            //                    CiFechaCreD = DateTime.Now,
                            //                    CiNombreS = workSheet.Cells[rowIterator, 3].Value.ToString(),
                            //                    CiColorS = workSheet.Cells[rowIterator, 4].Value.ToString(),
                            //                    CiCostoS = Convert.ToDouble(workSheet.Cells[rowIterator, 5].Value),
                            //                    CiConsumoS = float.Parse(workSheet.Cells[rowIterator, 6].Value.ToString()),
                            //                    CiTotalS = Convert.ToDouble(workSheet.Cells[rowIterator, 7].Value)
                            //                };
                            //                Retorno = Retorno + _services.InsertarCotizacionInsumos(model);
                            //            }
                            //            else
                            //            {
                            //                Errores = new ERRORES_CARGA
                            //                {
                            //                    Referencia = Referencia,
                            //                    Detalle = "El tipo de dato es erróneo",
                            //                    LineaError = rowIterator.ToString()
                            //                };
                            //                lstErrores.Add(Errores);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            Errores = new ERRORES_CARGA
                            //            {
                            //                Referencia = Referencia,
                            //                Detalle = "Existen campos vacíos",
                            //                LineaError = rowIterator.ToString()
                            //            };
                            //            lstErrores.Add(Errores);
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            int Codigo = 0;
                            bool Existe = _services.ExisteReferencia(Referencia, ref Codigo);
                            if (Existe)
                            {
                                if (TipoCargue == "CargueTelas")
                                {
                                    if (workSheet.Cells[rowIterator, 3].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 3].Value.ToString())
                                        && workSheet.Cells[rowIterator, 4].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 4].Value.ToString())
                                        && workSheet.Cells[rowIterator, 5].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 5].Value.ToString())
                                        && workSheet.Cells[rowIterator, 6].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 6].Value.ToString())
                                        && workSheet.Cells[rowIterator, 7].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 7].Value.ToString()))
                                    {
                                        TBL_PRE_CONSUMO_TELAS model = new TBL_PRE_CONSUMO_TELAS();
                                        if (workSheet.Cells[rowIterator, 5].Value.GetType() == Type.GetType("System.Double")
                                            && workSheet.Cells[rowIterator, 6].Value.GetType() == Type.GetType("System.Double")
                                            && workSheet.Cells[rowIterator, 7].Value.GetType() == Type.GetType("System.Double"))
                                        {
                                            model = new TBL_PRE_CONSUMO_TELAS
                                            {
                                                PreHcCodigoN = Codigo,
                                                PreCtFecCreD = DateTime.Now,
                                                PreCtNombreS = workSheet.Cells[rowIterator, 3].Value.ToString(),
                                                PreCtColorS = workSheet.Cells[rowIterator, 4].Value.ToString(),
                                                PreCtCtsxMtD = Convert.ToDecimal(workSheet.Cells[rowIterator, 5].Value),
                                                PreCtConF = float.Parse(workSheet.Cells[rowIterator, 6].Value.ToString()),
                                                PreCtTotalD = Convert.ToDecimal(workSheet.Cells[rowIterator, 7].Value)
                                            };
                                            Retorno = Retorno + _services.InsertarTelas(model);
                                        }
                                        else
                                        {
                                            Errores = new ERRORES_CARGA
                                            {
                                                Referencia = Referencia,
                                                Detalle = "El tipo de dato es erróneo",
                                                LineaError = rowIterator.ToString()
                                            };
                                            lstErrores.Add(Errores);
                                        }
                                    }
                                    else
                                    {
                                        Errores = new ERRORES_CARGA
                                        {
                                            Referencia = Referencia,
                                            Detalle = "Existen campos vacíos",
                                            LineaError = rowIterator.ToString()
                                        };
                                        lstErrores.Add(Errores);
                                    }
                                }
                                if (TipoCargue == "CargueInsumos")
                                {
                                    if (workSheet.Cells[rowIterator, 3].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 3].Value.ToString())
                                       && workSheet.Cells[rowIterator, 4].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 4].Value.ToString())
                                       && workSheet.Cells[rowIterator, 5].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 5].Value.ToString())
                                       && workSheet.Cells[rowIterator, 6].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 6].Value.ToString())
                                       && workSheet.Cells[rowIterator, 7].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 7].Value.ToString()))
                                    {
                                        TBL_PRE_INS_ACC model = new TBL_PRE_INS_ACC();
                                        if (workSheet.Cells[rowIterator, 5].Value.GetType() == Type.GetType("System.Double")
                                            && workSheet.Cells[rowIterator, 6].Value.GetType() == Type.GetType("System.Double")
                                            && workSheet.Cells[rowIterator, 7].Value.GetType() == Type.GetType("System.Double"))
                                        {
                                            model = new TBL_PRE_INS_ACC
                                            {
                                                PreHcCodigoN = Codigo,
                                                PreIaFecCreD = DateTime.Now,
                                                PreIaNombreS = workSheet.Cells[rowIterator, 3].Value.ToString(),
                                                PreIaColorS = workSheet.Cells[rowIterator, 4].Value.ToString(),
                                                PreIaCtsxMtD = Convert.ToDecimal(workSheet.Cells[rowIterator, 5].Value),
                                                PreIaConF = float.Parse(workSheet.Cells[rowIterator, 6].Value.ToString()),
                                                PreIaTotalD = Convert.ToDecimal(workSheet.Cells[rowIterator, 7].Value)
                                            };
                                            Retorno = Retorno + _services.InsertarInsumos(model);
                                        }
                                        else
                                        {
                                            Errores = new ERRORES_CARGA
                                            {
                                                Referencia = Referencia,
                                                Detalle = "El tipo de dato es erróneo",
                                                LineaError = rowIterator.ToString()
                                            };
                                            lstErrores.Add(Errores);
                                        }
                                    }
                                    else
                                    {
                                        Errores = new ERRORES_CARGA
                                        {
                                            Referencia = Referencia,
                                            Detalle = "Existen campos vacíos",
                                            LineaError = rowIterator.ToString()
                                        };
                                        lstErrores.Add(Errores);
                                    }
                                }
                                if (TipoCargue == "CargueMarquillas")
                                {
                                    if (workSheet.Cells[rowIterator, 3].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 3].Value.ToString())
                                       && workSheet.Cells[rowIterator, 5].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 5].Value.ToString())
                                       && workSheet.Cells[rowIterator, 6].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 6].Value.ToString())
                                       && workSheet.Cells[rowIterator, 7].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 7].Value.ToString()))
                                    {
                                        TBL_PRE_ETIQ_MAR_EMP model = new TBL_PRE_ETIQ_MAR_EMP();
                                        if (workSheet.Cells[rowIterator, 5].Value.GetType() == Type.GetType("System.Double")
                                            && workSheet.Cells[rowIterator, 6].Value.GetType() == Type.GetType("System.Double")
                                            && workSheet.Cells[rowIterator, 7].Value.GetType() == Type.GetType("System.Double"))
                                        {
                                            model = new TBL_PRE_ETIQ_MAR_EMP
                                            {
                                                PreHcCodigoN = Codigo,
                                                PreEmeFecCreD = DateTime.Now,
                                                PreEmeNombreS = workSheet.Cells[rowIterator, 3].Value.ToString(),
                                                PreEmeCtsxMtD = Convert.ToDecimal(workSheet.Cells[rowIterator, 5].Value),
                                                PreEmeConF = float.Parse(workSheet.Cells[rowIterator, 6].Value.ToString()),
                                                PreEmeTotalD = Convert.ToDecimal(workSheet.Cells[rowIterator, 7].Value)
                                            };
                                            Retorno = Retorno + _services.InsertarMarquillas(model);
                                        }
                                        else
                                        {
                                            Errores = new ERRORES_CARGA
                                            {
                                                Referencia = Referencia,
                                                Detalle = "El tipo de dato es erróneo",
                                                LineaError = rowIterator.ToString()
                                            };
                                            lstErrores.Add(Errores);
                                        }
                                    }
                                    else
                                    {
                                        Errores = new ERRORES_CARGA
                                        {
                                            Referencia = Referencia,
                                            Detalle = "Existen campos vacíos",
                                            LineaError = rowIterator.ToString()
                                        };
                                        lstErrores.Add(Errores);
                                    }
                                }
                                if (TipoCargue == "CargueProcesos")
                                {
                                    if (workSheet.Cells[rowIterator, 8].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 8].Value.ToString())
                                       && workSheet.Cells[rowIterator, 9].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 9].Value.ToString()))
                                    {
                                        TBL_PRE_PROCESO model = new TBL_PRE_PROCESO();
                                        if (workSheet.Cells[rowIterator, 9].Value.GetType() == Type.GetType("System.Double"))
                                        {
                                            model = new TBL_PRE_PROCESO
                                            {
                                                PreHcCodigoN = Codigo,
                                                PrePrFecCreD = DateTime.Now,
                                                PrePrDetalleS = workSheet.Cells[rowIterator, 8].Value.ToString(),
                                                PrePrCostoM = Convert.ToDecimal(workSheet.Cells[rowIterator, 9].Value)
                                            };
                                            Retorno = Retorno + _services.InsertarProcesos(model);
                                        }
                                        else
                                        {
                                            Errores = new ERRORES_CARGA
                                            {
                                                Referencia = Referencia,
                                                Detalle = "El tipo de dato es erróneo",
                                                LineaError = rowIterator.ToString()
                                            };
                                            lstErrores.Add(Errores);
                                        }
                                    }
                                    else
                                    {
                                        Errores = new ERRORES_CARGA
                                        {
                                            Referencia = Referencia,
                                            Detalle = "Existen campos vacíos",
                                            LineaError = rowIterator.ToString()
                                        };
                                        lstErrores.Add(Errores);
                                    }
                                }
                                if (TipoCargue == "MOD")
                                {
                                    if (workSheet.Cells[rowIterator, 10].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 10].Value.ToString())
                                       && workSheet.Cells[rowIterator, 11].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 11].Value.ToString()))
                                    {
                                        TBL_PRE_MOD_CIF model = new TBL_PRE_MOD_CIF();
                                        if (workSheet.Cells[rowIterator, 10].Value.GetType() == Type.GetType("System.Double")
                                            && workSheet.Cells[rowIterator, 11].Value.GetType() == Type.GetType("System.Double"))
                                        {
                                            model = new TBL_PRE_MOD_CIF
                                            {
                                                PreHcCodigoN = Codigo,
                                                PreMcFecCreD = DateTime.Now,
                                                PreMcCostoManoObraD = Convert.ToDecimal(workSheet.Cells[rowIterator, 10].Value),
                                                PreMcCostoIndirectosD = Convert.ToDecimal(workSheet.Cells[rowIterator, 11].Value)
                                            };
                                            Retorno = Retorno + _services.InsertarMODCIF(model);
                                        }
                                        else
                                        {
                                            Errores = new ERRORES_CARGA
                                            {
                                                Referencia = Referencia,
                                                Detalle = "El tipo de dato es erróneo",
                                                LineaError = rowIterator.ToString()
                                            };
                                            lstErrores.Add(Errores);
                                        }
                                    }
                                    else
                                    {
                                        Errores = new ERRORES_CARGA
                                        {
                                            Referencia = Referencia,
                                            Detalle = "Existen campos vacíos",
                                            LineaError = rowIterator.ToString()
                                        };
                                        lstErrores.Add(Errores);
                                    }
                                }
                            }
                            else
                            {
                                Errores = new ERRORES_CARGA
                                {
                                    Referencia = Referencia,
                                    Detalle = "La referencia no existe en UNOEE",
                                    LineaError = rowIterator.ToString()
                                };
                                lstErrores.Add(Errores);
                            }
                            //}
                        }
                        ViewBag.exito = "Proceso completado correctamente, numero de columnas afectadas: " + Retorno;
                    }
                }
            }
            ViewBag.Errores = lstErrores;
            return View("Index");
        }
    }
}