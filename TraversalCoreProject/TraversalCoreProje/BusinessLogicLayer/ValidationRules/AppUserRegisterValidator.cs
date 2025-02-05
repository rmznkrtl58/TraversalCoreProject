using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    //moddelerimin validasyonlarını yapmam için dto katmanımda
    //o modelin classını baz almam gerekiyor
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Boş Geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Boş Geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Geçilemez!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar Alanı Boş Geçilemez!");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Veri Girişi Yapınız!");
            RuleFor(x => x.UserName).MinimumLength(20).WithMessage("Lütfen En Fazla 20 Karakter Veri Girişi Yapınız!");
            //Equal->eşit
            RuleFor(x => x.Password).Equal(y=>y.ConfirmPassword).WithMessage("Şifreler Birbirleriyle Uyuşmuyor!");
        }
    }
}
