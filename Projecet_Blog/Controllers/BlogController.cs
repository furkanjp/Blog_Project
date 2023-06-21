using Business_Layer.Concrete;
using Business_Layer.ValidationRules;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Entity_Layer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace Projecet_Blog.Controllers
{

    public class BlogController : Controller
    {
        //Blogmanagerdan bm türet ve bunu efblogla newle 
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();


        [AllowAnonymous]
        public IActionResult Index()
        {
            //değerler bütün değerleri getir ve değerleri döndür
            var values = bm.GetBlogListWithCategory().OrderByDescending(b => b.BlogCreateDate).ToList();
            return View(values);
        }
        [AllowAnonymous]
        public  IActionResult BlogReadAll(int id) 
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        [HttpGet]
        public IActionResult BlogAdd()
        {       
            
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv=categoryvalues;
            return View();
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter","Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        public IActionResult DeleteBlog(int id) 
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        [HttpGet]
        public IActionResult EditBlog(int id) 
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID =writerID;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
