using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    public class GuideValidator:AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Adınızı Soyadınızı Boş Bırakmayınız!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen Açıklama Alanını Boş Bırakmayınız!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Resim Alanını Boş Bırakmayınız!");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Lütfen Açıklamanızı minimum 10 karakter girin!");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Lütfen Açıklamanızı maximum 100 karakter girin!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen Adınızı Soyadınızı maximum 50 karakter girin!");
        }
    }
}
