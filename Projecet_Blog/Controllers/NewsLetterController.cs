using Business_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm=new NewsLetterManager(new EfNewsLetterRepository());   
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter p,string Mail)
        {
            //p.MailStatus=true;
            //nm.AddNewsLetter(p);
            p.Mail = Mail;
            p.MailStatus = true;
            nm.AddNewsLetter(p);

            return Json(new { success = true });
            
          // return PartialView();
        }
    }
}
