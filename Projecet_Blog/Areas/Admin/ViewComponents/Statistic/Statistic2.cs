using Business_Layer.Concrete;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Projecet_Blog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            //Son yazılan blog ismi ve yazarı
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();

            var blogid= c.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.WriterID).Take(1).FirstOrDefault();
            ViewBag.v2 = c.Writers.Where(x => x.WriterID == blogid).Select(x => x.WriterName).FirstOrDefault();

            

            //bu ay oluşturulan blog sayısı
            DateTime currentDate = DateTime.Now;
            DateTime startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            int totalBlogsThisMonth = c.Blogs.Count(x => x.BlogCreateDate >= startOfMonth && x.BlogCreateDate <= endOfMonth);

            ViewBag.v3 = totalBlogsThisMonth;




            return View();
        }
    }
}
