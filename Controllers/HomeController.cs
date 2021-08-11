using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }
    }
}