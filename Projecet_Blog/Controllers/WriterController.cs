using Business_Layer.Concrete;
using Business_Layer.ValidationRules;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Entity_Layer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projecet_Blog.Models;
using static System.Net.WebRequestMethods;

namespace Projecet_Blog.Controllers
{

    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
     
      
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            ////sisteme otantike olan kulllanıcaya ait ıd çekme

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.imageurl = values.ImgUrl;
            model.username = values.UserName;
            model.namesurname = values.NameSurname;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.namesurname;
            values.Email = model.mail;
            values.ImgUrl = model.imageurl;
            values.UserName = model.username;
            //  values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);

            if (!model.ChangePassword)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            }

            var result = await _userManager.UpdateAsync(values);


            return RedirectToAction("Index", "Dashboard");
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index", "DashBoard");
        }
       
    }
}
