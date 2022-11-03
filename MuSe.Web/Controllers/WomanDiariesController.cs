using Microsoft.AspNetCore.Mvc;

namespace MuSe.Web.Controllers
{
    public class WomanDiariesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
