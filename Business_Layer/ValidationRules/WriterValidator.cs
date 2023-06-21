using Entity_Layer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {

        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad soyad boş olamaz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş olamaz.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Mail adresi geçerli olmak zorundadır.");
            RuleFor(x => x.WriterMail).Length(5, 250).WithMessage("Mail adresi en az 5 en fazla 250 karekter olabilir");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Parola boş olamaz.");
            RuleFor(x => x.WriterPassword).Length(5, 50).WithMessage("Parola en az 5 en fazla 50 karekter olabilir");

        }
    }
}
