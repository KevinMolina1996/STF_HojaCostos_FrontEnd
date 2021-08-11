using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class ParametrosPreController : Controller
    {
        private ParametrosPrecosteoService _services;

        public ParametrosPreController()
        {
            _services = new ParametrosPrecosteoService();
        }

        // GET: Parametros
        public ActionResult Consulta()
        {
            PARAMETROS_PRE model = new PARAMETROS_PRE();
            model.Marcas = GetSelectListItems(new List<string>());
            model.Colecciones = GetSelectListItems(new List<string>());
            model.Lineas = GetSelectListItems(new List<string>());
            model.Sublineas = GetSelectListItems(new List<string>());
            return View(model);
        }

        [HttpPost]
        public ActionResult FiltroMarca(string Tipo)
        {
            List<string> marcas = _services.obtenerMarcas(Tipo);
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroColeccion(string Tipo, string Marca)
        {
            List<string> colecciones = _services.obtenerColecciones(Tipo, Marca);
            return Json(colecciones, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroLinea(string Tipo, string Marca, string Coleccion)
        {
            List<string> lineas = _services.obtenerLineas(Tipo, Marca, Coleccion);
            return Json(lineas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroSublinea(string Tipo, string Marca, string Coleccion, string Linea)
        {
            List<string> sublineas = _services.obtenerSublineas(Tipo, Marca, Coleccion, Linea);
            return Json(sublineas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Consultar(string Factor, string marca, string coleccion, string linea, string sublinea/*PARAMETROS_PN model*/)
        {
            try
            {
                ViewBag.marca = marca;
                ViewBag.coleccion = coleccion;
                ViewBag.linea = linea;
                ViewBag.sublinea = sublinea;

                if (Factor == "" || Factor == null)
                {
                    ViewBag.alerta = "Debe seleccionar un tipo.";
                    //return View("Index", model);
                }

                //PARAMETROS_PN _model = _services.obtenerParametros(model.Factor, model._TBL_PARAM_PN.PpMarcaS, model._TBL_PARAM_PN.PpColeccionS, model._TBL_PARAM_PN.PpLineaS, model._TBL_PARAM_PN.PpSubLineaS);
                PARAMETROS_PRE _model = _services.obtenerParametros(Factor, marca, coleccion, linea, sublinea);
                if (_model._TBL_PARAM_PRE != null)
                {
                    ViewBag.habilitar = "S";
                }
                else
                {
                    ViewBag.alerta = "No existen registros para mostrar";
                }

                return View("Consulta", _model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Actualizar(PARAMETROS_PRE model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string mensaje = _services.actualizar_crearParametros(model._TBL_PARAM_PRE);
                    string viewContent = ConvertViewToString("_Formulario", model);
                    return Json(new { PartialView = viewContent, mensaje = mensaje });
                    //return PartialView("_Formulario", parametros);
                }
                else
                {
                    //var errors = ModelState.Select(x => x.Value.Errors)
                    //           .Where(y => y.Count > 0)
                    //           .ToList();
                    string viewContent = ConvertViewToString("_Formulario", model);
                    return Json(new { PartialView = viewContent, mensaje_warning = "Valide la información ingresada" });
                    //return PartialView("_Formulario", parametros);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Crear(PARAMETROS_PRE model, string marca, string coleccion, string linea, string sublinea)
        {
            try
            {
                string viewContent;

                if (model._TBL_PARAM_PRE.PreCodigoN == 0)
                {
                    if(model.Factor.Length > 0 && marca.Length > 0 && coleccion.Length > 0 && linea.Length > 0 && sublinea.Length > 0)
                    {
                        model._TBL_PARAM_PRE.PreFactorS = model.Factor;
                        model._TBL_PARAM_PRE.PreMarcaS = marca;
                        model._TBL_PARAM_PRE.PreColeccionS = coleccion;
                        model._TBL_PARAM_PRE.PreLineaS = linea;
                        model._TBL_PARAM_PRE.PreSubLineaS = sublinea;
                        model._TBL_PARAM_PRE.PreCodigoN = 0;
                        model._TBL_PARAM_PRE.PreFecCreD = DateTime.Now;
                        string mensaje = _services.actualizar_crearParametros(model._TBL_PARAM_PRE);
                        viewContent = ConvertViewToString("_Formulario", model);
                        return Json(new { PartialView = viewContent, mensaje = mensaje });
                    }
                    else
                    {
                        viewContent = ConvertViewToString("_Formulario", model);
                        return Json(new { PartialView = viewContent, mensaje_warning = "Valide la información ingresada" });
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        if (model._TBL_PARAM_PRE.PreMarcaS.Equals(marca) && model._TBL_PARAM_PRE.PreColeccionS.Equals(coleccion) && model._TBL_PARAM_PRE.PreLineaS.Equals(linea)
                            && model._TBL_PARAM_PRE.PreSubLineaS.Equals(sublinea))
                        {
                            viewContent = ConvertViewToString("_Formulario", model);
                            return Json(new { PartialView = viewContent, mensaje_warning = "El registro ya existe." });
                        }
                        else
                        {
                            model._TBL_PARAM_PRE.PreMarcaS = marca;
                            model._TBL_PARAM_PRE.PreColeccionS = coleccion;
                            model._TBL_PARAM_PRE.PreLineaS = linea;
                            model._TBL_PARAM_PRE.PreSubLineaS = sublinea;
                            model._TBL_PARAM_PRE.PreCodigoN = 0;
                            model._TBL_PARAM_PRE.PreFecCreD = DateTime.Now;
                            string mensaje = _services.actualizar_crearParametros(model._TBL_PARAM_PRE);
                            viewContent = ConvertViewToString("_Formulario", model);
                            return Json(new { PartialView = viewContent, mensaje = mensaje });
                        }
                    }
                    else
                    {
                        List<ModelErrorCollection> errors = ModelState.Select(x => x.Value.Errors)
                        .Where(y => y.Count > 0)
                        .ToList();
                        viewContent = ConvertViewToString("_Formulario", model);
                        return Json(new { PartialView = viewContent, mensaje_warning = "Valide la información ingresada" });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (string element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }
            return selectList;
        }

        //FALTA AÑADIR LOS VALORES NUEVOS
        public ActionResult Upload(FormCollection formCollection)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files["UploadedFile"];

                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        int data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                        List<string> lstStatus = new List<string>();
                        using (ExcelPackage package = new ExcelPackage(file.InputStream))
                        {
                            ExcelWorksheets currentSheet = package.Workbook.Worksheets;
                            ExcelWorksheet workSheet = currentSheet.First();
                            int noOfCol = workSheet.Dimension.End.Column;
                            int noOfRow = workSheet.Dimension.End.Row;
                            string mensaje = "Proceso terminado exitosamente";
                            string estado = "E";
                            TBL_PARAM_PRE param = new TBL_PARAM_PRE();

                            for (int rowIterator = 3; rowIterator <= noOfRow; rowIterator++)
                            {
                                if (workSheet.Cells[rowIterator, 1].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 1].Value.ToString())
                                    && workSheet.Cells[rowIterator, 2].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 2].Value.ToString())
                                    && workSheet.Cells[rowIterator, 3].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 3].Value.ToString())
                                    && workSheet.Cells[rowIterator, 4].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 4].Value.ToString())
                                    && workSheet.Cells[rowIterator, 5].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 5].Value.ToString())
                                    && workSheet.Cells[rowIterator, 6].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 6].Value.ToString())
                                    && workSheet.Cells[rowIterator, 7].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 7].Value.ToString())
                                    && workSheet.Cells[rowIterator, 8].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 8].Value.ToString())
                                    && workSheet.Cells[rowIterator, 9].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 9].Value.ToString())
                                    && workSheet.Cells[rowIterator, 10].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 10].Value.ToString())
                                    && workSheet.Cells[rowIterator, 11].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 11].Value.ToString())
                                    && workSheet.Cells[rowIterator, 12].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 12].Value.ToString())
                                    && workSheet.Cells[rowIterator, 13].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 13].Value.ToString())
                                    && workSheet.Cells[rowIterator, 14].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 14].Value.ToString())
                                    && workSheet.Cells[rowIterator, 15].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 15].Value.ToString())
                                    && workSheet.Cells[rowIterator, 16].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 16].Value.ToString())
                                    && workSheet.Cells[rowIterator, 17].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 17].Value.ToString())
                                    && workSheet.Cells[rowIterator, 18].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 18].Value.ToString())
                                    && workSheet.Cells[rowIterator, 19].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 19].Value.ToString())
                                    && workSheet.Cells[rowIterator, 20].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 20].Value.ToString())
                                    && workSheet.Cells[rowIterator, 21].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 21].Value.ToString())
                                    && workSheet.Cells[rowIterator, 22].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 22].Value.ToString())
                                    && workSheet.Cells[rowIterator, 23].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 23].Value.ToString())
                                    && workSheet.Cells[rowIterator, 24].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 24].Value.ToString())
                                    && workSheet.Cells[rowIterator, 25].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 25].Value.ToString())
                                    && workSheet.Cells[rowIterator, 26].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 26].Value.ToString())
                                    && workSheet.Cells[rowIterator, 27].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 27].Value.ToString())
                                    && workSheet.Cells[rowIterator, 28].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 28].Value.ToString())
                                    && workSheet.Cells[rowIterator, 29].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 29].Value.ToString())
                                    && workSheet.Cells[rowIterator, 30].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 30].Value.ToString())
                                    && workSheet.Cells[rowIterator, 31].Value != null && !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 31].Value.ToString())
                                    && workSheet.Cells[rowIterator, 32].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 32].Value.ToString())
                                    && workSheet.Cells[rowIterator, 33].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 33].Value.ToString())
                                    && workSheet.Cells[rowIterator, 34].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 34].Value.ToString())
                                    )
                                {
                                    if (workSheet.Cells[rowIterator, 9].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 10].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 11].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 12].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 13].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 14].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 15].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 16].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 17].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 18].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 19].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 20].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 21].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 22].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 23].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 24].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 25].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 26].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 27].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 28].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 29].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 30].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 31].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 32].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 33].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 34].Value.GetType() != Type.GetType("System.Double"))
                                    {
                                        mensaje = "Proceso terminado con advertencias";
                                        estado = "W";
                                        lstStatus.Add("Se presento un error por tipo de datos en la fila: " + rowIterator);
                                    }
                                    else
                                    {
                                        param = new TBL_PARAM_PRE
                                        {
                                            PreFactorS = workSheet.Cells[rowIterator, 1].Value.ToString(),
                                            PreMarcaS = workSheet.Cells[rowIterator, 2].Value.ToString(),
                                            ID_Coleccion = workSheet.Cells[rowIterator, 3].Value.ToString(),
                                            PreColeccionS = workSheet.Cells[rowIterator, 4].Value.ToString(),
                                            ID_Linea = workSheet.Cells[rowIterator, 5].Value.ToString(),
                                            PreLineaS = workSheet.Cells[rowIterator, 6].Value.ToString(),
                                            ID_Sublinea = workSheet.Cells[rowIterator, 7].Value.ToString(),
                                            PreSubLineaS = workSheet.Cells[rowIterator, 8].Value.ToString(),
                                            PreFactorRentabilidadMinF = Convert.ToDouble(workSheet.Cells[rowIterator, 9].Value),
                                            PreFactorRentabilidadMaxF = Convert.ToDouble(workSheet.Cells[rowIterator, 10].Value),
                                            PreGastosAdminF = Convert.ToDouble(workSheet.Cells[rowIterator, 11].Value),
                                            PreGastosFinanF = Convert.ToDouble(workSheet.Cells[rowIterator, 12].Value),
                                            PreGastosMercadeoF = Convert.ToDouble(workSheet.Cells[rowIterator, 13].Value),
                                            PreAlmacenLineaCanalF = Convert.ToDouble(workSheet.Cells[rowIterator, 14].Value),
                                            PreIvaF = Convert.ToDouble(workSheet.Cells[rowIterator, 15].Value),
                                            PreTrmF = Convert.ToDouble(workSheet.Cells[rowIterator, 16].Value),
                                            PreAdminxFinanF = Convert.ToDouble(workSheet.Cells[rowIterator, 17].Value),
                                            PreMercadeoF = Convert.ToDouble(workSheet.Cells[rowIterator, 18].Value),
                                            PreVntsxCanalLineaF = Convert.ToDouble(workSheet.Cells[rowIterator, 19].Value),
                                            PreParticipacionAdminF = Convert.ToDouble(workSheet.Cells[rowIterator, 20].Value),
                                            PreParticipacionFinanF = Convert.ToDouble(workSheet.Cells[rowIterator, 21].Value),
                                            PreParticipacionMercadeoF = Convert.ToDouble(workSheet.Cells[rowIterator, 22].Value),
                                            PreEnterPriceM = Convert.ToDecimal(workSheet.Cells[rowIterator, 23].Value),
                                            PreMediumPriceM = Convert.ToDecimal(workSheet.Cells[rowIterator, 24].Value),
                                            PrePremiumPriceM = Convert.ToDecimal(workSheet.Cells[rowIterator, 25].Value),
                                            PreCocienteDivisorF = Convert.ToDouble(workSheet.Cells[rowIterator, 26].Value),
                                            PreCocienteDivisor2F = Convert.ToDouble(workSheet.Cells[rowIterator, 27].Value),
                                            PreResiduoDivisorF = Convert.ToInt32(workSheet.Cells[rowIterator, 28].Value),
                                            PreTopePrecioMilesF = Convert.ToDouble(workSheet.Cells[rowIterator, 29].Value),
                                            PrePrecioMinimoF = Convert.ToDouble(workSheet.Cells[rowIterator, 30].Value),
                                            PrePrecioMaximoF = Convert.ToDouble(workSheet.Cells[rowIterator, 31].Value),
                                            PreTerminoPrecioF = Convert.ToDouble(workSheet.Cells[rowIterator, 32].Value),
                                            PreFactorInsumoF = Convert.ToDouble(workSheet.Cells[rowIterator, 33].Value),
                                            PreFactorTelaF = Convert.ToDouble(workSheet.Cells[rowIterator, 34].Value)
                                        };
                                        _services.cargueParametros(param);
                                    }
                                }
                                else
                                {
                                    mensaje = "Proceso terminado con advertencias";
                                    estado = "W";
                                    lstStatus.Add("Existen campos vacios en la fila: " + rowIterator);
                                }
                            }

                            //Retorno los estados para informacion al usuario
                            ViewBag.lstStatus = lstStatus;
                            ViewBag.estado = estado;
                            ViewBag.mensaje = mensaje;

                        }
                    }
                }
                PARAMETROS_PRE model = new PARAMETROS_PRE();
                model.Marcas = GetSelectListItems(new List<string>());
                model.Colecciones = GetSelectListItems(new List<string>());
                model.Lineas = GetSelectListItems(new List<string>());
                model.Sublineas = GetSelectListItems(new List<string>());

                return View("Consulta", model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}