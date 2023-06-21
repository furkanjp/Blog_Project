//using Microsoft.AspNetCore.Mvc;
//using Projecet_Blog.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace Projecet_Blog.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen ad soyad giriniz")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen ad soyad giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen mail  giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string UserName { get; set; }

    }
}
