using Business_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var values = commentManager.GetCommentWithBlog();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var values = commentManager.TGetById(id);
            commentManager.TDelete(values);

            return RedirectToAction("Index");
        }

    }
}
