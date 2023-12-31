﻿using Business_Layer.Concrete;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Plugins;

namespace Projecet_Blog.Controllers
{
    [Authorize(Roles = "Admin,Moderator,Writer")]
    public class MessageController : Controller
    {
        Context c = new Context();
        Message2Manager mm = new Message2Manager(new EfIMessage2Repository());
        public IActionResult InBox()
        {
           
            var username = User.Identity.Name;
            var usermail=c.Users.Where(x=>x.UserName==username).Select(y=>y.Email).FirstOrDefault();
            var writerID=c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
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
        
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
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
        public IActionResult SendMessage(Message2 p,int ReceiverID)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = writerID;
            p.ReceiverID = ReceiverID;

            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            mm.TAdd(p);

            return RedirectToAction("Inbox");
        }
    }
}
