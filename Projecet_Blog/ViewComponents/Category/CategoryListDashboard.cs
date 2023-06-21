using Business_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.ViewComponents.Category
{
    public class CategoryListDashboard:ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
