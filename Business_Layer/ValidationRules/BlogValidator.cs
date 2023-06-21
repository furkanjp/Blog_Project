using Entity_Layer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez.");
            RuleFor(x => x.BlogTitle).Length(3, 100).WithMessage("Blog Başlığı en az 3 en fazla 100 karekter olabilir");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez.");
            RuleFor(x => x.BlogContent).MinimumLength(3).WithMessage("Blog içeriği en az 3 karekter olabilir");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog resmi boş geçilemez");
        }
    }
}
