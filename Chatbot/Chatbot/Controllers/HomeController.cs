using System.Web.Mvc;

namespace Chatbot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}