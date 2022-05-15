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
        Question_WrongAnswer qw = new Question_WrongAnswer();
        public ActionResult Index(int p=1)
        {
            var sorularınSayfalanması = questionManager.GetAll().ToPagedList(p, 10);
            return View(sorularınSayfalanması);
        }
        
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
        public ActionResult EklenenSorununGorunumu(int id)
        {
            qw.Question = questionManager.GetByLastID(id);
            qw.WrongAnswer = wrongAnswerManager.GetAll();
            return View(qw);
        }
        public ActionResult SorularıGetir(int id)
        {
            var soruicerigi = questionManager.GetByQuestionID(id);
            return View("SorularıGetir", soruicerigi);
        }
        [ValidateInput(false)]
        public ActionResult EklenenSorulariGuncelle(Question question)
        {
            questionManager.Update(question);
            Thread.Sleep(2100);
            return RedirectToAction("Index");
        }
    }
}