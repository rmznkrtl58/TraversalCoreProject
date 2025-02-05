using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Threading.Tasks;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{   //Identity Kayıt işlemleri:
    //1)Models klasörüme UserRegisterViewModel oluştur.
    //2)UserManager'i kullan gerisini zaten biliyon
    //Identity Şifre Şartlarını Türkçeleştirme:
    //Models klasörüme CustomIdentityValidator sınıfı oluşturuyorum
    //Giriş İşlemi:
    //Models içine UserSignInViewModel oluşturuyom gerisi aşağıda zaten
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager= signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {  //Kayıt olma işlemi

            AppUser appUser = new AppUser()
            {
             Name= model.Name,
             Surname= model.Surname,
             UserName= model.UserName,
             Email=model.Mail
             //passworda modelimden gelen değeri atamıyorum çünkü hashlendiği için
             //ilerde passwordu kullancam
            };
            if (String.IsNullOrEmpty(model.Password))
            {
                return View();
            }
            else
            {
                if (model.Password == model.ConfirmPassword)
                {                                                    //passwordu burda kullandım
                    var result = await _userManager.CreateAsync(appUser, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("SignIn", "Login");
                    }
                    else
                    {
                        foreach (var x in result.Errors)
                        {
                            ModelState.AddModelError("", x.Description);
                        }
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.userName,model.Password,false,true);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Profile", new {area="Member"});
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            //Amaç şifremi unuttum yaparak o kişinin mailine link gönderip
            //oradan şifrenin güncellenmesini sağlamak
            var findUserMail = await _userManager.FindByEmailAsync(model.mail);
            //bir şifrelenmiş token oluşturuyorum
            var passwordResetToken=await _userManager.GeneratePasswordResetTokenAsync(findUserMail);
            //bir token değeri oluşacak önemli şifrelenmiş link gibi düşün
            //link hangi sayfaya yönlendirecek login içerisindeki resetPassword 
            //sayfasına yönlendirip orada şifre güncelleme yapacak kullanıcı
            string passwordResetTokenLink = Url.Action("ResetPassword", "Login", new
            {
                userId=findUserMail.Id,//reset password sayfamda userId ve token değerini tutucak
                token=passwordResetToken
            },HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();
            //Kimden Gönderilecek(Maili Gönderecek Kişinin iki parametresi var)
            //1)ismi 2)maili
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Ramazan Kartal", "rmznkrtl1453@gmail.com");
            //from kısmı kimden geldiği
            mimeMessage.From.Add(mailboxAddressFrom);//mailin mailboxaddress değişkenimdeki bilgilerden
            //geldiğini kullanıcıma bildirmiş oldum

            //Kime Göndereceğim
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.mail);
            mimeMessage.To.Add(mailboxAddressTo);
            //mimeMessage.Body = m.Content;
            mimeMessage.Subject = "Şifre Değiştirme Talebi";
            var bodyBuilder = new BodyBuilder();//içerik oluşturucu
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            //MailKit.Netsmpt seç
            SmtpClient client = new SmtpClient();
            //1)gmail kullanacağım için 2)gmailin port numarası
            //3)bool durumu hoca söylemedi bakarız ona
            client.Connect("smtp.gmail.com", 587, false);
            //client.authenticate 1)gönderen kişinin mail
            //2)o mailin şifresi
            //kim tarafından gönderilecekse bu mail adresi
            //aşağıdaki olay hangi gmail hesabla göndereceksen myaccount kısmından güvenlik
            //uygulama şifrelerinden uyguluma şifresi oluşturup ordaki kodu 2.parametreye
            //yapıştırman gerek!
            client.Authenticate("rmznkrtl1453@gmail.com", "Gmail ayarlarından kod gelecek");
            client.Send(mimeMessage);
            client.Disconnect(true);


            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string userId,string token)
        {
            TempData["userid"] = userId;
            TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var userId=TempData["userid"];
            var token=TempData["token"];
            if (userId == null || token == null)
            {
                //bir hata mesajı verdirilebilir.
            }
            else
            {
                //authentice olunmuş kullanıcının Id'sine göre bul
                var findUser = await _userManager.FindByIdAsync(userId.ToString());
                var result = await _userManager.ResetPasswordAsync(findUser, token.ToString(), model.password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }

    }
}
