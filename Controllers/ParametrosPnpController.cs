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
    public class ParametrosPnpController : Controller
    {
        private ParametrosPnpServices _services;

        public ParametrosPnpController()
        {
            _services = new ParametrosPnpServices();
        }

        // GET: ParametrosPnp
        public ActionResult Index()
        {
            PARAMETROS_PNP model = new PARAMETROS_PNP();
            model.Marcas = GetSelectListItems(new List<string>());
            model.Colecciones = GetSelectListItems(new List<string>());
            model.Lineas = GetSelectListItems(new List<string>());
            model.Sublineas = GetSelectListItems(new List<string>());
            return View(model);
        }

        [HttpPost]
        public ActionResult FiltroMarca(string Tipo)
        {
            var marcas = _services.obtenerMarcas(Tipo);
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroColeccion(string Tipo, string Marca)
        {
            var colecciones = _services.obtenerColecciones(Tipo, Marca);
            return Json(colecciones, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroLinea(string Tipo, string Marca, string Coleccion)
        {
            var lineas = _services.obtenerLineas(Tipo, Marca, Coleccion);
            return Json(lineas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroSublinea(string Tipo, string Marca, string Coleccion, string Linea)
        {
            var sublineas = _services.obtenerSublineas(Tipo, Marca, Coleccion, Linea);
            return Json(sublineas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Consultar(string Factor, string marca, string coleccion, string linea, string sublinea/*PARAMETROS_PNP model*/)
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

                PARAMETROS_PNP _model = _services.obtenerParametros(Factor, marca, coleccion, linea, sublinea);
                if (_model._TBL_PARAM_PNP != null)
                {
                    ViewBag.habilitar = "S";
                }
                else
                {
                    ViewBag.alerta = "No existen registros para mostrar";
                }

                return View("Index", _model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Actualizar(PARAMETROS_PNP model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    String mensaje = _services.actualizar_crearParametros(model._TBL_PARAM_PNP);
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
        public ActionResult Crear(PARAMETROS_PNP model, string marca, string coleccion, string linea, string sublinea)
        {
            try
            {
                string viewContent;

                if (model._TBL_PARAM_PNP.PnCodigoN == 0)
                {
                    if (model.Factor != null && marca.Length > 0 && coleccion.Length > 0 && linea.Length > 0 && sublinea.Length > 0)
                    {
                        model._TBL_PARAM_PNP.PnFactorS = model.Factor;
                        model._TBL_PARAM_PNP.PnMarcaS = marca;
                        model._TBL_PARAM_PNP.PnColeccionS = coleccion;
                        model._TBL_PARAM_PNP.PnLineaS = linea;
                        model._TBL_PARAM_PNP.PnSubLineaS = sublinea;
                        model._TBL_PARAM_PNP.PnCodigoN = 0;
                        model._TBL_PARAM_PNP.PnFecCreD = DateTime.Now;
                        string mensaje = _services.actualizar_crearParametros(model._TBL_PARAM_PNP);
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
                        if (model._TBL_PARAM_PNP.PnMarcaS.Equals(marca) && model._TBL_PARAM_PNP.PnColeccionS.Equals(coleccion) && model._TBL_PARAM_PNP.PnLineaS.Equals(linea)
                            && model._TBL_PARAM_PNP.PnSubLineaS.Equals(sublinea))
                        {
                            viewContent = ConvertViewToString("_Formulario", model);
                            return Json(new { PartialView = viewContent, mensaje_warning = "El registro ya existe." });
                        }
                        else
                        {
                            model._TBL_PARAM_PNP.PnMarcaS = marca;
                            model._TBL_PARAM_PNP.PnColeccionS = coleccion;
                            model._TBL_PARAM_PNP.PnLineaS = linea;
                            model._TBL_PARAM_PNP.PnSubLineaS = sublinea;
                            model._TBL_PARAM_PNP.PnCodigoN = 0;
                            model._TBL_PARAM_PNP.PnFecCreD = DateTime.Now;

                            String mensaje = _services.actualizar_crearParametros(model._TBL_PARAM_PNP);
                            viewContent = ConvertViewToString("_Formulario", model);
                            return Json(new { PartialView = viewContent, mensaje = mensaje });
                            //return PartialView("_Formulario", parametros);
                        }
                    }
                    else
                    {
                        var errors = ModelState.Select(x => x.Value.Errors)
                                   .Where(y => y.Count > 0)
                                   .ToList();
                        viewContent = ConvertViewToString("_Formulario", model);
                        return Json(new { PartialView = viewContent, mensaje_warning = "Valide la información ingresada." });
                        //return PartialView("_Formulario", parametros);
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
            var selectList = new List<SelectListItem>();

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }
            return selectList;
        }

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
                        var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                        List<string> lstStatus = new List<string>();
                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            String mensaje = "Proceso terminado exitosamente";
                            String estado = "E";
                            TBL_PARAM_PNP param = new TBL_PARAM_PNP();

                            for (int rowIterator = 3; rowIterator <= noOfRow; rowIterator++)
                            {
                                if (workSheet.Cells[rowIterator, 1].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 1].Value.ToString())
                                    && workSheet.Cells[rowIterator, 2].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 2].Value.ToString())
                                    && workSheet.Cells[rowIterator, 3].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 3].Value.ToString())
                                    && workSheet.Cells[rowIterator, 4].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 4].Value.ToString())
                                    && workSheet.Cells[rowIterator, 5].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 5].Value.ToString())
                                    && workSheet.Cells[rowIterator, 6].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 6].Value.ToString())
                                    && workSheet.Cells[rowIterator, 7].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 7].Value.ToString())
                                    && workSheet.Cells[rowIterator, 8].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 8].Value.ToString())
                                    && workSheet.Cells[rowIterator, 9].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 9].Value.ToString())
                                    && workSheet.Cells[rowIterator, 10].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 10].Value.ToString())
                                    && workSheet.Cells[rowIterator, 11].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 11].Value.ToString())
                                    && workSheet.Cells[rowIterator, 12].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 12].Value.ToString())
                                    && workSheet.Cells[rowIterator, 13].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 13].Value.ToString())
                                    && workSheet.Cells[rowIterator, 14].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 14].Value.ToString())
                                    && workSheet.Cells[rowIterator, 15].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 15].Value.ToString())
                                    && workSheet.Cells[rowIterator, 16].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 16].Value.ToString())
                                    && workSheet.Cells[rowIterator, 17].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 17].Value.ToString())
                                    && workSheet.Cells[rowIterator, 18].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 18].Value.ToString())
                                    && workSheet.Cells[rowIterator, 19].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 19].Value.ToString())
                                    && workSheet.Cells[rowIterator, 20].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 20].Value.ToString())
                                    && workSheet.Cells[rowIterator, 21].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 21].Value.ToString())
                                    && workSheet.Cells[rowIterator, 22].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 22].Value.ToString())
                                    && workSheet.Cells[rowIterator, 23].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 23].Value.ToString())
                                    && workSheet.Cells[rowIterator, 24].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 24].Value.ToString())
                                    && workSheet.Cells[rowIterator, 25].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 25].Value.ToString())
                                    && workSheet.Cells[rowIterator, 26].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 26].Value.ToString())
                                    && workSheet.Cells[rowIterator, 27].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 27].Value.ToString())
                                    && workSheet.Cells[rowIterator, 28].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 28].Value.ToString())
                                    && workSheet.Cells[rowIterator, 29].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 29].Value.ToString())
                                    && workSheet.Cells[rowIterator, 30].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 30].Value.ToString())
                                    && workSheet.Cells[rowIterator, 31].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 31].Value.ToString())
                                    && workSheet.Cells[rowIterator, 32].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 32].Value.ToString())
                                    && workSheet.Cells[rowIterator, 33].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 33].Value.ToString())
                                    && workSheet.Cells[rowIterator, 34].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 34].Value.ToString())
                                    && workSheet.Cells[rowIterator, 35].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 35].Value.ToString())
                                    && workSheet.Cells[rowIterator, 36].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 36].Value.ToString())
                                    && workSheet.Cells[rowIterator, 37].Value != null && !String.IsNullOrEmpty(workSheet.Cells[rowIterator, 37].Value.ToString())
                                    )
                                {
                                    if (
                                        workSheet.Cells[rowIterator, 9].Value.GetType() != Type.GetType("System.Double")
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
                                        || workSheet.Cells[rowIterator, 21].Value.GetType() != param.PnFactorMinF.GetType()
                                        || workSheet.Cells[rowIterator, 22].Value.GetType() != param.PnFactorMaxF.GetType()
                                        || workSheet.Cells[rowIterator, 23].Value.GetType() != param.PnIvaF.GetType()
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
                                        || workSheet.Cells[rowIterator, 34].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 35].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 36].Value.GetType() != Type.GetType("System.Double")
                                        || workSheet.Cells[rowIterator, 37].Value.GetType() != Type.GetType("System.Double"))
                                    {
                                        mensaje = "Proceso terminado con advertencias";
                                        estado = "W";
                                        lstStatus.Add("Se presento un error por tipo de datos en la fila: " + rowIterator);
                                    }
                                    else
                                    {
                                        param = new TBL_PARAM_PNP
                                        {
                                            PnFactorS = workSheet.Cells[rowIterator, 1].Value.ToString(),
                                            PnMarcaS = workSheet.Cells[rowIterator, 2].Value.ToString(),
                                            ID_Coleccion = workSheet.Cells[rowIterator, 3].Value.ToString(),
                                            PnColeccionS = workSheet.Cells[rowIterator, 4].Value.ToString(),
                                            ID_Linea = workSheet.Cells[rowIterator, 5].Value.ToString(),
                                            PnLineaS = workSheet.Cells[rowIterator, 6].Value.ToString(),
                                            ID_Sublinea = workSheet.Cells[rowIterator, 7].Value.ToString(),
                                            PnSubLineaS = workSheet.Cells[rowIterator, 8].Value.ToString(),
                                            PnPinSeguridadF = Convert.ToDouble(workSheet.Cells[rowIterator, 9].Value),
                                            PnGastosOrigenF = Convert.ToDouble(workSheet.Cells[rowIterator, 10].Value),
                                            PnGastosFleteF = Convert.ToDouble(workSheet.Cells[rowIterator, 11].Value),
                                            PnGastosFleteAereoF = Convert.ToDouble(workSheet.Cells[rowIterator, 12].Value),
                                            PnArancelF = Convert.ToDouble(workSheet.Cells[rowIterator, 13].Value),
                                            PnSeguroIntF = Convert.ToDouble(workSheet.Cells[rowIterator, 14].Value),
                                            PnGastosDestF = Convert.ToDouble(workSheet.Cells[rowIterator, 15].Value),
                                            PnOtrosGastosF = Convert.ToDouble(workSheet.Cells[rowIterator, 16].Value),
                                            PnAdcPrdM = Convert.ToDecimal(workSheet.Cells[rowIterator, 17].Value),
                                            PnSensorizacionM = Convert.ToDecimal(workSheet.Cells[rowIterator, 18].Value),
                                            PnArregloPrdM = Convert.ToDecimal(workSheet.Cells[rowIterator, 19].Value),
                                            PnReconstruccionM = Convert.ToDecimal(workSheet.Cells[rowIterator, 20].Value),
                                            PnPorcGastosEstimadoF = Convert.ToDouble(workSheet.Cells[rowIterator, 21].Value),
                                            PnPorcGastosRealF = Convert.ToDouble(workSheet.Cells[rowIterator, 22].Value),
                                            PnFactorMinF = Convert.ToDouble(workSheet.Cells[rowIterator, 23].Value),
                                            PnFactorMaxF = Convert.ToDouble(workSheet.Cells[rowIterator, 24].Value),
                                            PnIvaF = Convert.ToDouble(workSheet.Cells[rowIterator, 25].Value),
                                            PnTRMF = Convert.ToDouble(workSheet.Cells[rowIterator, 26].Value),
                                            PnEnterpriceM = Convert.ToDecimal(workSheet.Cells[rowIterator, 27].Value),
                                            PnMediumPriceM = Convert.ToDecimal(workSheet.Cells[rowIterator, 28].Value),
                                            PnPremiumPriceM = Convert.ToDecimal (workSheet.Cells[rowIterator, 29].Value),
                                            PnDivisorCocienteF = Convert.ToDouble(workSheet.Cells[rowIterator, 30].Value),
                                            PnDivisorCocienteDosF = Convert.ToDouble(workSheet.Cells[rowIterator, 31].Value),
                                            PnDivisorResiduoF = Convert.ToInt32(workSheet.Cells[rowIterator, 32].Value),
                                            PnTopeMinimoF = Convert.ToDouble(workSheet.Cells[rowIterator, 33].Value),
                                            PnTopeMaximoF = Convert.ToDouble(workSheet.Cells[rowIterator, 34].Value),
                                            PnValorVerdaderoF = Convert.ToDouble(workSheet.Cells[rowIterator, 35].Value),
                                            PnValorFalsoF = Convert.ToDouble(workSheet.Cells[rowIterator, 36].Value),
                                            PnRedondeoF = Convert.ToDouble(workSheet.Cells[rowIterator, 37].Value)
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
                PARAMETROS_PNP model = new PARAMETROS_PNP();
                model.Marcas = GetSelectListItems(new List<string>());
                model.Colecciones = GetSelectListItems(new List<string>());
                model.Lineas = GetSelectListItems(new List<string>());
                model.Sublineas = GetSelectListItems(new List<string>());
                return View("Index", model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}