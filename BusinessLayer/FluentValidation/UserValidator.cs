using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçemezsiniz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçemezsiniz");
            RuleFor(x => x.SurName).MinimumLength(3).WithMessage("Soyad boş geçemezsiniz");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("Password boş geçilemez");

        }
    }
}
