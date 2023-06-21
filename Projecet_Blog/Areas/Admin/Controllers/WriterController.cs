using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projecet_Blog.Areas.Admin.Models;

namespace Projecet_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(Writers);
            return Json(jsonWriters);
        }
        public IActionResult GetWriterByID(int writerid)
        {
            var findWriter = Writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters=JsonConvert.SerializeObject(findWriter);   
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            Writers.Add(w);
            var jsonWriters= JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            
            var writer = Writers.FirstOrDefault(x => x.Id == id);
            Writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterClass w)
        {

            var writer = Writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name=w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }
        public static List<WriterClass> Writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name="Orhan"
            },
            new WriterClass
            {
                Id = 2,
                Name="Burhan"
            },
            new WriterClass
            {
                Id = 3,
                Name="Furkan"
            },
            new WriterClass
            {
                Id = 4,
                Name="Burcu"
            }

        };
    }
}
