using BusinessLayer.Concreate;
using DataAccsessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace YazılımYapımıDönemProjesi.Controllers
{
    
    public class ÖğretmenController : Controller
    {
        // GET: Öğretmen
        QuestionManager questionManager = new QuestionManager(new EfQuestionDal());
        WrongAnswerManager wrongAnswerManager = new WrongAnswerManager(new EfWrongAnswerDal());
        Question_WrongAnswer question_WrongAnswer = new Question_WrongAnswer();

        //Öğretmenin ekledği bütün sorular karrşısında gözükür sayfalanmış bir şekilde
        public ActionResult Index(int p=1)
        {
            var butunSorularınSayfalanması = questionManager.GetAll().ToPagedList(p, 10);
            return View(butunSorularınSayfalanması);
        }
        
        //Öğretmenin soru eklmediği bölüm
        [HttpGet]
        public ActionResult SoruEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SoruEkle(Question question)
        {
            questionManager.Add(question);
            Thread.Sleep(2100);
            return RedirectToAction("Index");
        }

        //Öğretmenin yanlış cevap eklemesi
        [HttpGet]
        public ActionResult YanlisCevapEkle(int id)
        {
            ViewBag.deger = id;
            return View();
        }
        [HttpPost]
        public ActionResult YanlisCevapEkle(WrongAnswer wrongAnswer)
        {
            wrongAnswerManager.Add(wrongAnswer);
            Thread.Sleep(2100);
            return RedirectToAction("Index");
        }

        //öğretmenin eklediği soruyu kendisine gösterilmesi
        public ActionResult EklenenSorununGorunumu(int id)
        {
            question_WrongAnswer.Question = questionManager.GetByLastID(id);
            question_WrongAnswer.WrongAnswer = wrongAnswerManager.GetAll();
            return View(question_WrongAnswer);
        }

        //Eklenen soruları guncelleme sayfasına getirmesi
        public ActionResult SorularıGetir(int id)
        {
            var soruIcerigi = questionManager.GetByQuestionID(id);
            return View("SorularıGetir", soruIcerigi);
        }

        //getirilen soruların güncellenmesi
        [ValidateInput(false)]
        public ActionResult EklenenSorulariGuncelle(Question question)
        {
            questionManager.Update(question);
            Thread.Sleep(2100);
            return RedirectToAction("Index");
        }
    }
}