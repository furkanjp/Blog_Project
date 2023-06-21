using Business_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetList (id);
            return View(values);
        }
    }
}