using Business_Layer.Concrete;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.ViewComponents.Writer
{
    [AllowAnonymous]
    public class WriterMessageNotification:ViewComponent
    {
        Context c=new Context();
        
        Message2Manager mm =new Message2Manager(new EfIMessage2Repository());
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            return View(values);
        }
    }
}
