using BusinessLayer.Concreate;
using DataAccsessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace YazılımYapımıDönemProjesi.Controllers
{
     
    public class AdminController : Controller
    {
        // GET: Admin
        QuestionManager questionManager = new QuestionManager(new EfQuestionDal());
        Question_WrongAnswer qw = new Question_WrongAnswer();
        WrongAnswerManager wrongAnswerManager = new WrongAnswerManager(new EfWrongAnswerDal());

        public ActionResult Index(int p = 1)
        {
            var degerler = questionManager.GetAll().ToPagedList(p, 10);
            return View(degerler);
        }
        public ActionResult EklenenSorununGorunumu(int id)
        {
            qw.Question = questionManager.GetByLastID(id);
            qw.WrongAnswer = wrongAnswerManager.GetAll();
            return View(qw);
        }
        public ActionResult IzinVer(int id)
        {
            questionManager.GetByactiveID(id);
            return RedirectToAction("Index");
        }
        public ActionResult IzinVerme(int id)
        {
            questionManager.GetByPassiveID(id);       
            return RedirectToAction("Index");
        }
        public ActionResult IzinVerilenleriGoruntule()
        {
            var izinVerilenSoru= questionManager.GetAll();
            return View(izinVerilenSoru);
        }
        public ActionResult IzinVerilmeyenleriGoruntule()
        {
            var izinVerilmeyenSoru = questionManager.GetAll();
            return View(izinVerilmeyenSoru);
        }
        public ActionResult IzinVerilenlereIzinVerme(int id)
        {
            questionManager.GetByPassiveID(id);
            return RedirectToAction("IzinVerilenleriGoruntule");
        }
        public ActionResult IzinVerilmeyenlereIzinVerme(int id)
        {
            questionManager.GetByactiveID(id);
            return RedirectToAction("IzinVerilmeyenleriGoruntule");
        }
    }
}