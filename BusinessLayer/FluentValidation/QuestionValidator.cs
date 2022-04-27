using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class QuestionValidator:AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(p => p.CorrectAnswer).NotEmpty().WithMessage("Doğru cevap boş geçilemez.");
            RuleFor(p => p.CourseName).NotEmpty().WithMessage("Ders adı boş geçilemez.");
            RuleFor(p => p.QuestionText).NotEmpty().WithMessage("Soru boş geçilemez.");
            RuleFor(p => p.UnitName).NotEmpty().WithMessage("Ünite adı boş geçilemez.");
        }
    }
}
