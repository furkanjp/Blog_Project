using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class Category
    {
        //erişim belirteci değişken türü isim {get;set;}
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string  CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        //
        public List<Blog> Blogs { get; set; }

    }
}
