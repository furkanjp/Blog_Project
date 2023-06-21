using Business_Layer.Concrete;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projecet_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminBlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory().OrderByDescending(b => b.BlogCreateDate).ToList();
            return View(values);
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = blogManager.TGetById(id);
            blogManager.TDelete(blogvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = blogManager.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerID;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            blogManager.TUpdate(p);
            return RedirectToAction("Index", "AdminBlog");
        }
    }
}
