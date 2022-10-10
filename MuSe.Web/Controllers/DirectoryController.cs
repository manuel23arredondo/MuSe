using Microsoft.AspNetCore.Mvc;

namespace MuSe.Web.Controllers
{
    public class DirectoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
