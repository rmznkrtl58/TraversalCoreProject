using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProje.Models
{  //Identity ile alakalı şifrelemede belirlenen şartları türkçeleştirme
	public class CustomIdentityValidator:IdentityErrorDescriber
	{                                //Kısa Şifre Girildiğinde
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Şifreniz Minimum {length} karakter olmalıdır!"
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Şifrenizde En Az 1 Küçük Harf Olmalı!"
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = "Şifrenizde En Az 1 Büyük Harf Olmalı!"
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Şifrenizde En Az 1 Sembol Olmalı!"
			};
		}
		//Bu işlemlerin işlemesi için startupa geç ve orda gerekli işlemleri yap
	}
}
