using Business_Layer.Concrete;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projecet_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminMessageController : Controller
    {
        Context c = new Context();
        Message2Manager mm = new Message2Manager(new EfIMessage2Repository());
        ContactManager cm=new ContactManager(new EfContactRepository());

        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendBoxListByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            var receivers = c.Writers.ToList();
            ViewBag.Receivers = receivers.Select(r => new SelectListItem
            {
                Value = r.WriterID.ToString(),
                Text = r.WriterName
            }).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(Message2 p, int ReceiverID)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = writerID;
            p.ReceiverID = ReceiverID;

            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            mm.TAdd(p);

            return RedirectToAction("SendBox");
        }
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }

        public IActionResult ContactBox()
        {
            var values = cm.GetList().OrderByDescending(b => b.ContactDate).ToList();
            return View(values);
        }
        public IActionResult ContactMessageDetails(int id)
        {
            var value = cm.TGetById(id);
            return View(value);
        }
    }

}
