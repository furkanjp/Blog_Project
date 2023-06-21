using Business_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        NotificationManager mn = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = mn.GetList();
            return View(values);
        }
    }
}
