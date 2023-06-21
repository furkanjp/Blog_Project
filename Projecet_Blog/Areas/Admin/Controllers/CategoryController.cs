using Business_Layer.Concrete;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Business_Layer.ValidationRules;
using DataAccess_Layer.EntityFramework;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess_Layer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace Projecet_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetList().ToPagedList(page, 7);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");
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
        public IActionResult CategoryDelete(int id) 
        {
            var blogvalue = cm.TGetById(id);
            cm.TDelete(blogvalue);
            return RedirectToAction("Index");
        }

    }
}
    

