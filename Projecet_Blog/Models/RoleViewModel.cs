
namespace Projecet_Blog.Models
{
    public class RoleViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen rol adı girini")]
        public string name { get; set; }
    }
}
