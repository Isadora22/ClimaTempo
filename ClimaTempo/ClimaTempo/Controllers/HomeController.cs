using System.Web.Mvc;

namespace ClimaTempo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Informações da Candidata";

            return View();
        }

        public ActionResult Clima()
        {
            ViewBag.Message = "Previsão do Tempo";

            return View();
        }
    }
}