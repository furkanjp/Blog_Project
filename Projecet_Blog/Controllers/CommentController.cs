using Business_Layer.Concrete;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using DocumentFormat.OpenXml.InkML;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Projecet_Blog.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        BlogManager bm =new BlogManager(new EfBlogRepository()); 
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();

        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            p.CommentStatus = true;
            p.BlogID = 1098;
            cm.CommentAdd(p);
            
            //var values = cm.GetList(id).FirstOrDefault();
            //p.BlogID = values.BlogID;
            //cm.CommentAdd(p);

            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }

    }
}
