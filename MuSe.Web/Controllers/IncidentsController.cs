using Microsoft.AspNetCore.Mvc;

namespace MuSe.Web.Controllers
{
    public class IncidentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
