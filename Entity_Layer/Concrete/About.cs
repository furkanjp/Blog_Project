using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string AboutDetails1 { get; set; }
        public string AboutDetails2 { get; set; }
        public string Aboutİmage1 { get; set; }
        public string Aboutİmage2 { get; set; }
        public string AboutMapLocation { get; set; }
        public bool AboutStatus { get; set; }
    }
}
