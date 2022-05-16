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

        //Sayfalayarak kaydedilen bütün soruları çeker
        public ActionResult Index(int p = 1)
        {
            var degerler = questionManager.GetAll().ToPagedList(p, 10);
            return View(degerler);
        }

        //sorulacak sorunun nasıl gözükeceğini admine gösterir
        public ActionResult EklenenSorununGorunumu(int id)
        {
            qw.Question = questionManager.GetByLastID(id);
            qw.WrongAnswer = wrongAnswerManager.GetAll();
            return View(qw);
        }

        //Adminin öğretmen tarafından eklenen sorulara izin vermesi 
        public ActionResult IzinVer(int id)
        {
            questionManager.GetByactiveID(id);
            return RedirectToAction("Index");
        }

        //Adminin öğretmen tarafından eklenen sorulara izin vermeme
        public ActionResult IzinVerme(int id)
        {
            questionManager.GetByPassiveID(id);
            return RedirectToAction("Index");
        }

        //adminin izin verdiği sorular nasıl gözüktüğünü gösterecek
        public ActionResult IzinVerilenleriGoruntule()
        {
            var izinVerilenSoru = questionManager.GetAll();
            return View(izinVerilenSoru);
        }

        //adminin izin vermediği sorular nasıl gözüküyor onları gösterir
        public ActionResult IzinVerilmeyenleriGoruntule()
        {
            var izinVerilmeyenSoru = questionManager.GetAll();
            return View(izinVerilmeyenSoru);
        }

        //adminin izin verdiği sorulara daha sonra izin vermeme
        public ActionResult IzinVerilenlereIzinVerme(int id)
        {
            questionManager.GetByPassiveID(id);
            return RedirectToAction("IzinVerilenleriGoruntule");
        }

        //adminin izin vermediği sorulara daha sonra izin verme
        public ActionResult IzinVerilmeyenlereIzinVerme(int id)
        {
            questionManager.GetByactiveID(id);
            return RedirectToAction("IzinVerilmeyenleriGoruntule");
        }
    }
}