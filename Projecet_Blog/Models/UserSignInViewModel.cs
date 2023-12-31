﻿using System.ComponentModel.DataAnnotations;

namespace Projecet_Blog.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı adını girin")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        public string password { get; set; }
    }
}
