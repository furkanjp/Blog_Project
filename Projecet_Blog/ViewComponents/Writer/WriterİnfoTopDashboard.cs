using Business_Layer.Concrete;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.ViewComponents.Writer
{
    public class WriterİnfoTopDashboard:ViewComponent
    {
        WriterManager writermanager = new WriterManager(new EfWriterRepository());

        Context c = new Context();
        public IViewComponentResult Invoke()
        {

            //sisteme otantike olan kulllanıcaya ait ıd çekme
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = writermanager.GetWriterById(writerID);
            return View(values);
        }
    }
}
