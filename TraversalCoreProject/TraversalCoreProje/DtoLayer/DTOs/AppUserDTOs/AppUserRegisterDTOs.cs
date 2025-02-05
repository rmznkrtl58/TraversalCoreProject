using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserRegisterDTOs
    {
        //[Required(ErrorMessage = "Lütfen Adınızı Giriniz!")]
        //[Required(ErrorMessage = "Lütfen Soyadınızı Giriniz!")]
        //[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz!")]
        //[Required(ErrorMessage = "Lütfen E-posta Adresinizi Giriniz!")]
        //[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz!")]
        //[Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz!")]
        //[Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
