using AppWebHojaCosto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebHojaCosto.Services;
using System.IO;
using OfficeOpenXml;

namespace AppWebHojaCosto.Controllers
{
    public class ParametrosController : Controller
    {
        private ParametrosServices _services;

        public ParametrosController()
        {
            _services = new ParametrosServices();
        }

        // GET: Parametros
        public ActionResult Index()
        {
            PARAMETROS_PN model = new PARAMETROS_PN();
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
                PARAMETROS_PN _model = _services.obtenerParametros(Factor, marca, coleccion, linea, sublinea);
                if (_model._TBL_PARAM_PN != null)
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
        public ActionResult Actualizar(PARAMETROS_PN model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    String mensaje = _services.actualizar_crearParametros(model._TBL_PARAM_PN);
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
        public ActionResult Crear(PARAMETROS_PN model, string marca, string coleccion, string linea, string sublinea)
        {
            try
            {
                string viewContent;
                if (model._TBL_PARAM_PN.PpCodigoN == 0)
                {
                    if (model.Factor != null && marca.Length > 0 && coleccion.Length > 0 && linea.Length > 0 && sublinea.Length > 0)
                    {
                        model._TBL_PARAM_PN.PpFactorS = model.Factor;
                        model._TBL_PARAM_PN.PpMarcaS = marca;
                        model._TBL_PARAM_PN.PpColeccionS = coleccion;
                        model._TBL_PARAM_PN.PpLineaS = linea;
                        model._TBL_PARAM_PN.PpSubLineaS = sublinea;
                        model._TBL_PARAM_PN.PpCodigoN = 0;
                        model._TBL_PARAM_PN.PpFecCreD = DateTime.Now;
                        string mensaje = _services.actualizar_crearParametros(model._TBL_PARAM_PN);
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
                        if (model._TBL_PARAM_PN.PpMarcaS.Equals(marca) && model._TBL_PARAM_PN.PpColeccionS.Equals(coleccion) && model._TBL_PARAM_PN.PpLineaS.Equals(linea)
                            && model._TBL_PARAM_PN.PpSubLineaS.Equals(sublinea))
                        {
                            viewContent = ConvertViewToString("_Formulario", model);
                            return Json(new { PartialView = viewContent, mensaje_warning = "El registro ya existe." });
                        }
                        else
                        {
                            model._TBL_PARAM_PN.PpMarcaS = marca;
                            model._TBL_PARAM_PN.PpColeccionS = coleccion;
                            model._TBL_PARAM_PN.PpLineaS = linea;
                            model._TBL_PARAM_PN.PpSubLineaS = sublinea;
                            model._TBL_PARAM_PN.PpCodigoN = 0;
                            model._TBL_PARAM_PN.PpFecCreD = DateTime.Now;
                            String mensaje = _services.actualizar_crearParametros(model._TBL_PARAM_PN);
                            viewContent = ConvertViewToString("_Formulario", model);
                            return Json(new { PartialView = viewContent, mensaje = mensaje });
                            //return PartialView("_Formulario", parametros);
                        }
                    }
                    else
                    {
                        //var errors = ModelState.Select(x => x.Value.Errors)
                        //           .Where(y => y.Count > 0)
                        //           .ToList();
                        viewContent = ConvertViewToString("_Formulario", model);
                        return Json(new { PartialView = viewContent, mensaje_warning = "Valide la información ingresada" });
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
                            TBL_PARAM_PN param = new TBL_PARAM_PN();

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
                                        param = new TBL_PARAM_PN
                                        {
                                            PpFactorS = workSheet.Cells[rowIterator, 1].Value.ToString(),
                                            PpMarcaS = workSheet.Cells[rowIterator, 2].Value.ToString(),
                                            ID_Coleccion  = workSheet.Cells[rowIterator, 3].Value.ToString(),
                                            PpColeccionS = workSheet.Cells[rowIterator, 4].Value.ToString(),
                                            ID_Linea = workSheet.Cells[rowIterator, 5].Value.ToString(),
                                            PpLineaS = workSheet.Cells[rowIterator, 6].Value.ToString(),
                                            ID_Sublinea = workSheet.Cells[rowIterator, 7].Value.ToString(),
                                            PpSubLineaS = workSheet.Cells[rowIterator, 8].Value.ToString(),
                                            PpFactorRentabilidadMinF = Convert.ToDouble(workSheet.Cells[rowIterator, 9].Value),
                                            PpFactorRentabilidadMaxF = Convert.ToDouble(workSheet.Cells[rowIterator, 10].Value),
                                            PpGastosAdminF = Convert.ToDouble(workSheet.Cells[rowIterator, 11].Value),
                                            PpGastosFinanF = Convert.ToDouble(workSheet.Cells[rowIterator, 12].Value),
                                            PpGastosMercadeoF = Convert.ToDouble(workSheet.Cells[rowIterator, 13].Value),
                                            PpAlmacenLineaCanalF = Convert.ToDouble(workSheet.Cells[rowIterator, 14].Value),
                                            PpIvaF = Convert.ToDouble(workSheet.Cells[rowIterator, 15].Value),
                                            PpTrmF = Convert.ToDouble(workSheet.Cells[rowIterator, 16].Value),
                                            PpAdminxFinanF = Convert.ToDouble(workSheet.Cells[rowIterator, 17].Value),
                                            PpMercadeoF = Convert.ToDouble(workSheet.Cells[rowIterator, 18].Value),
                                            PpVntsxCanalLineaF = Convert.ToDouble(workSheet.Cells[rowIterator, 19].Value),
                                            PpParticipacionAdminF = Convert.ToDouble(workSheet.Cells[rowIterator, 20].Value),
                                            PpParticipacionFinanF = Convert.ToDouble(workSheet.Cells[rowIterator, 21].Value),
                                            PpParticipacionMercadeoF = Convert.ToDouble(workSheet.Cells[rowIterator, 22].Value),
                                            PpEnterPriceM = Convert.ToDecimal(workSheet.Cells[rowIterator, 23].Value),
                                            PpMediumPriceM = Convert.ToDecimal(workSheet.Cells[rowIterator, 24].Value),
                                            PpPremiumPriceM = Convert.ToDecimal(workSheet.Cells[rowIterator, 25].Value),
                                            PpCocienteDivisorF = Convert.ToDouble(workSheet.Cells[rowIterator, 26].Value),
                                            PpCocienteDivisor2F = Convert.ToDouble(workSheet.Cells[rowIterator, 27].Value),
                                            PpResiduoDivisorF = Convert.ToInt32(workSheet.Cells[rowIterator, 28].Value),
                                            PpTopePrecioMilesF = Convert.ToDouble(workSheet.Cells[rowIterator, 29].Value),
                                            PpPrecioMinimoF = Convert.ToDouble(workSheet.Cells[rowIterator, 30].Value),
                                            PpPrecioMaximoF = Convert.ToDouble(workSheet.Cells[rowIterator, 31].Value),
                                            PpTerminoPrecioF = Convert.ToDouble(workSheet.Cells[rowIterator, 32].Value),
                                            PpFactorInsumoF = Convert.ToDouble(workSheet.Cells[rowIterator, 33].Value),
                                            PpFactorTelaF = Convert.ToDouble(workSheet.Cells[rowIterator, 34].Value)
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
                PARAMETROS_PN model = new PARAMETROS_PN();
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