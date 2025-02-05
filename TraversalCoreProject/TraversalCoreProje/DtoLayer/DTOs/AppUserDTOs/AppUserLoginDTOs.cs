using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserLoginDTOs
    {
        //[Required(ErrorMessage = "Lütfen E-Posta Adresinizi Girin!")]
        //[Required(ErrorMessage = "Lütfen Şifrenizi Girin!")]
        public string userName { get; set; }
        public string Password { get; set; }
    }
}
