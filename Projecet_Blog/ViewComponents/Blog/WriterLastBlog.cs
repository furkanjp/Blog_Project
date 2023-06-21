using Business_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = bm.GetBlogListByWriter(1);
			return View(values);
		}
	}
}
