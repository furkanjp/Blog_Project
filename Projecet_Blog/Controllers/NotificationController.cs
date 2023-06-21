using Business_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AllNotification()
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
