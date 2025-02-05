using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules.Contact
{
    public class SendContactUsValidator:AbstractValidator<SendMessageDTO>
    {   
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanını boş bırakamazsınız!");
            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("Mail alanı için minimum 5 karakter giriniz!");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Mail alanı için maximum 50 karakter giriniz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanını boş bırakamazsınız!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adınız ve Soyadınızı  boş bırakamazsınız!");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriğini boş bırakamazsınız!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu alanı için minimum 3 karakter giriniz!");
            RuleFor(x => x.Subject).MaximumLength(30).WithMessage("Konu alanı için maximum 30 karakter giriniz!");
        }
    }
}
