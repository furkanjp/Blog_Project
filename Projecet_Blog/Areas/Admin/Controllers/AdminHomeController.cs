using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
