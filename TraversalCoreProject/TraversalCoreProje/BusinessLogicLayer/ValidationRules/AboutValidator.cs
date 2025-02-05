using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Kısmını Boş Geçemezsin!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Kısmını Boş Geçemezsin!");
            RuleFor(x => x.Title2).NotEmpty().WithMessage("2.Başlığı Boş Geçemezsin!");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("2.Açıklamayı Boş Geçemezsin!");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Resim Kısmını Boş Geçemezsin!");
        }
    }
}
