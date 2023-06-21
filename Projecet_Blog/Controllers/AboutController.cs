using Business_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
	{
		AboutManager abm = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
			var values = abm.GetList();
			return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{
			
			return PartialView();
		}
	}
}
