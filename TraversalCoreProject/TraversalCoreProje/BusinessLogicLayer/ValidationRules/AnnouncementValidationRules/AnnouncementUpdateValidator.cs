using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator:AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Duyuru Başlığını Boş Bırakmayınız!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Duyuru Başlığı En Az 5 Karakter Olmalı!");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Duyuru Başlığı En Fazla 50 Karakter Olmalı!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Duyuru İçeriğini Boş Bırakmayınız!");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("Duyuru İçeriği En Az 20 Karakter Olmalı!");
            RuleFor(x => x.Content).MaximumLength(300).WithMessage("Duyuru İçeriği En Fazla 300 Karakter Olmalı!");
        }
    }
}
