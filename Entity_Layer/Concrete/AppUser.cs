using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string NameSurname{ get; set; }
        public string? ImgUrl { get; set; }
    }
}
