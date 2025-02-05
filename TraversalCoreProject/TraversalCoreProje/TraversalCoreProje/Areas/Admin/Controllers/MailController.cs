using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest m)
        {
            MimeMessage mimeMessage = new MimeMessage();
            //Kimden Gönderilecek(Maili Gönderecek Kişinin iki parametresi var)
            //1)ismi 2)maili
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Ramazan Kartal","rmznkrtl1453@gmail.com");
            //from kısmı kimden geldiği
            mimeMessage.From.Add(mailboxAddressFrom);//mailin mailboxaddress değişkenimdeki bilgilerden
            //geldiğini kullanıcıma bildirmiş oldum

            //Kime Göndereceğim
            MailboxAddress mailboxAddressTo = new MailboxAddress("User",m.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            //mimeMessage.Body = m.Content;
            mimeMessage.Subject = m.Subject;
            var bodyBuilder = new BodyBuilder();//içerik oluşturucu
            bodyBuilder.TextBody = m.Content;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            //MailKit.Netsmpt seç
            SmtpClient client= new SmtpClient();
            //1)gmail kullanacağım için 2)gmailin port numarası
            //3)bool durumu hoca söylemedi bakarız ona
            client.Connect("smtp.gmail.com",587,false);
            //client.authenticate 1)gönderen kişinin mail
            //2)o mailin şifresi
            //kim tarafından gönderilecekse bu mail adresi
            //aşağıdaki olay hangi gmail hesabla göndereceksen myaccount kısmından güvenlik
            //uygulama şifrelerinden uyguluma şifresi oluşturup ordaki kodu 2.parametreye
            //yapıştırman gerek!
            client.Authenticate("rmznkrtl1453@gmail.com", "verilen kodu buraya yaz");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
