using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Areas.Member.Models
{
	public class UserEditViewModel
	{
        public string name { get; set; }
        public string surName { get; set; }
        public string password { get; set; }
        [Compare("password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string confirmPassword { get; set; }
        public string mail { get; set; }
        public string imageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
