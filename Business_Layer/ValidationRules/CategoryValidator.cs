using Entity_Layer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.ValidationRules
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage(" Kategori ismi boş geçilemez.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez.");
            RuleFor(x => x.CategoryName).Length(3, 100).WithMessage("Kategori ismi en az 2, en fazla 50 karekter olabilir");
        }
    }
}
