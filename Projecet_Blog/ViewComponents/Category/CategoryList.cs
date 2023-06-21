using Business_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Projecet_Blog.ViewComponents.Category
{
    public class CategoryList: ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());  
        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();
            return View(values);
        }

    }
}