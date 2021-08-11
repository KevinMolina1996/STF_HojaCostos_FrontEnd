using AppWebHojaCosto.Models;
using AppWebHojaCosto.Models.Json;
using AppWebHojaCosto.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            string json = JSONOutput.GETJson(JSONOutput.GETUrl("ConsultarTodosUsuarios", null));
            //List<Usuarios> usuarios = JsonConvert.DeserializeObject<List<Usuarios>>(json);

            return View();
        }

        [HttpPost]
        public ActionResult Editar(int Codigo, bool boEstado)
        {
            HelperResponse helper = new HelperResponse();
            string json = JSONOutput.POSTJson(JSONOutput.GETUrl("ActualizarEstadoUsuario", new object[]{
                "intCodigo=" + Codigo,
                "&boEstado=" + boEstado
            }));
            List<HelperResponse> _response = JsonConvert.DeserializeObject<List<HelperResponse>>(json);

            foreach (var item in _response)
            {
                helper = new HelperResponse
                {
                    _respuesta = item._respuesta,
                    _mensaje = item._mensaje
                };
            }

            if (helper._respuesta == 1)
            {
                if (boEstado)
                    helper._mensaje = "Usuario activado";
                else
                    helper._mensaje = "Usuario inactivado";
            }

            return Json(new { respuesta = helper._respuesta, mensaje = helper._mensaje }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ActualizarModulos(int UsCodigoN, string MoCodigoN)
        {
            HelperResponse helper = new HelperResponse();
            string json = JSONOutput.POSTJson(JSONOutput.GETUrl("ActualizarUsuarioMod", new object[]{
                "UsCodigoN=" + UsCodigoN,
                "&MoCodigoN=" + MoCodigoN
            }));
            List<HelperResponse> _response = JsonConvert.DeserializeObject<List<HelperResponse>>(json);

            return Json(new { respuesta = _response[0]._respuesta, mensaje = _response[0]._mensaje }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult ConsultaModulos(int codigo)
        //{
        //    string json = JSONOutput.POSTJson(JSONOutput.GETUrl("ConsultaTodosModulos", null));
        //    List<Modulos> lstModulos = JsonConvert.DeserializeObject<List<Modulos>>(json);

        //    string jsonUsu = JSONOutput.POSTJson(JSONOutput.GETUrl("ConsultarUsuarioModulos", new object[]{
        //        "intCodigo=" + codigo
        //    }));
        //    List<Usuario> _usu = JsonConvert.DeserializeObject<List<Usuario>>(jsonUsu);

        //    String strModulos = _usu[0].MoCodigoN;

        //    //Limpio los estados de los modulos, para asignarse de acuerdo al usuario seleccionado
        //    foreach (var item in lstModulos)
        //    {
        //        item.MoEstadoB = false;
        //    }

        //    if (!String.IsNullOrEmpty(strModulos))
        //    {
        //        String[] split = strModulos.Split('|');
        //        foreach (var item in lstModulos)
        //        {
        //            for (int i = 0; i < split.Length; i++)
        //            {
        //                if (Convert.ToInt32(split[i]) == item.MoCodigoN)
        //                    item.MoEstadoB = true;
        //            }
        //        }
        //    }

        //    return Json(new { lstModulos }, JsonRequestBehavior.AllowGet);
        //}
    }
}