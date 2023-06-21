using DataAccess_Layer.Concrete;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.Controllers
{

    public class DashBoardController : Controller
    {
        [Authorize(Roles = "Admin,Moderator,Writer")]
        public IActionResult Index()
        {
            DataAccess_Layer.Concrete.Context c = new DataAccess_Layer.Concrete.Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writername = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            var writerimage = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.yazarisim = writername;
            ViewBag.yazarustisim = writername;
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerid).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();


        }

    }
}
