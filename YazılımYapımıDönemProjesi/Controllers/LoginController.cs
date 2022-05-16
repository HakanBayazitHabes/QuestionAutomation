using BusinessLayer.Concreate;
using BusinessLayer.FluentValidation;
using DataAccsessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace YazılımYapımıDönemProjesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        UserManager userManager = new UserManager(new EfUserDal());
        //kullanıcı ekleme
        public ActionResult Index(User p)
        {
            userManager.Add(p);
            return View();
        }
        //öğrenci kaydı oluşturma
        [HttpGet]
        public ActionResult OgrenciKaydol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciKaydol(User user)
        {
            userManager.Add(user);
            return View();
        }
        //öğrenci girişi gerçekleştirme
        [HttpGet]
        public ActionResult OgrenciGirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciGirisYap(User user)
        {
            var uservalue = userManager.GetByMailPassword(user);
            if (uservalue != null)
            {
                FormsAuthentication.SetAuthCookie(uservalue.Mail, false);
                Session["Mail"] = uservalue.Mail;
                return RedirectToAction("Index", "Ögrenci");
            }
            else
            {
                return RedirectToAction("OgrenciKaydol");
            }
        }
        //öğrenci çıkışını gerçekleştirme
        public ActionResult OgrenciLogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("OgrenciKaydol");
        }
        //öğrenci şifresini sıfırlama
        [HttpGet]
        public ActionResult ResetOgrenciPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetOgrenciPassword(User user)
        {
            var userValue = userManager.GetByEmail(user);
            if (userValue !=null)
            {
                Guid rastgeleSifre = Guid.NewGuid();
                userValue.Password = rastgeleSifre.ToString().Substring(0, 8);
                userManager.Update(userValue);
                SmtpClient client = new SmtpClient("smtp.yandex.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("questionautomation@yandex.com", "topnjkmpmuqbgcce");
                MailAddress from = new MailAddress("questionautomation@yandex.com", "Şifre Sıfırlama E-postası");
                MailAddress to = new MailAddress(userValue.Mail);
                MailMessage message = new MailMessage("questionautomation@yandex.com",userValue.Mail);
                message.Body = "Merhaba " + userValue.Name + "<br/> Kullanıcı Adınız= " + userValue.Mail + "<br/> Şifreniz=" + userValue.Password; ;
                message.IsBodyHtml = true;
                message.Subject = "Şifre Değiştirme İsteği";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                client.Send(message);
                return RedirectToAction("OgrenciKaydol");
            }
            return View();
        }

        //Öğretemne Kaydol
        [HttpGet]
        public ActionResult OgretmenKaydol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OgretmenKaydol(User user)
        {
            userManager.Add(user);
            return View();
        }

        //Öğretmen giriş yap
        [HttpGet]
        public ActionResult OgretmenGirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OgretmenGirisYap(User user)
        {
            var uservalue = userManager.GetByMailPassword(user);
            if (uservalue != null)
            {
                FormsAuthentication.SetAuthCookie(uservalue.Mail, false);
                Session["Mail"] = uservalue.Mail;
                return RedirectToAction("Index", "Öğretmen");
            }
            else
            {
                return RedirectToAction("OgretmenKaydol");
            }
        }

        //Öğretmen çıkış yap
        public ActionResult OgretmenLogOut()
        {
            FormsAuthentication.SignOut();
            return View("OgretmenKaydol");
        }

        //Öğretmen şifre sıfırlama
        [HttpGet]
        public ActionResult ResetOgretmenPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetOgretmenPassword(User user)
        {
            var userValue = userManager.GetByEmail(user);
            if (userValue != null)
            {
                Guid rastgeleSifre = Guid.NewGuid();
                userValue.Password = rastgeleSifre.ToString().Substring(0, 8);
                userManager.Update(userValue);
                SmtpClient client = new SmtpClient("smtp.yandex.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("questionautomation@yandex.com", "topnjkmpmuqbgcce");
                MailAddress from = new MailAddress("questionautomation@yandex.com", "Şifre Sıfırlama E-postası");
                MailAddress to = new MailAddress(userValue.Mail);
                MailMessage message = new MailMessage("questionautomation@yandex.com", userValue.Mail);
                message.Body = "Merhaba " + userValue.Name + "<br/> Kullanıcı Adınız= " + userValue.Mail + "<br/> Şifreniz=" + userValue.Password; ;
                message.IsBodyHtml = true;
                message.Subject = "Şifre Değiştirme İsteği";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                client.Send(message);
                return RedirectToAction("OgretmenKaydol");
            }
            return View();
        }

        //Admin giriş Yap
        [HttpGet]
        public ActionResult AdminGirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminGirisYap(User user)
        {
            var uservalue = userManager.GetByMailPassword(user);
            if (uservalue != null)
            {
                FormsAuthentication.SetAuthCookie(uservalue.Mail, false);
                Session["Mail"] = uservalue.Mail;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        //Admin çıkış yap
        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            return View("AdminGirisYap");
        }

    }
}