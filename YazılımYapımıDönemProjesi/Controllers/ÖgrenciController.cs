using BusinessLayer.Concreate;
using DataAccsessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YazılımYapımıDönemProjesi.Controllers
{
    
    public class ÖgrenciController : Controller
    {
        // GET: Ögrenci
        QuestionManager questionManager = new QuestionManager(new EfQuestionDal());
        Question_WrongAnswer question_WrongAnswer = new Question_WrongAnswer();
        WrongAnswerManager wrongAnswerManager = new WrongAnswerManager(new EfWrongAnswerDal());

       //Öğrencinin ana başlama noktası sınava giriş ekranı
        public ActionResult Index()
        {
            return View();
        }

        //öğretmenin eklediği soruları öğrenciye gösterildiği bölüm
        public ActionResult EklenenSorularınGosterimi()
        {
            question_WrongAnswer.Question= questionManager.GetAll().FindAll(x=>x.AdminAllow=="Allow").Take(10);
            question_WrongAnswer.WrongAnswer = wrongAnswerManager.GetAll();
            return View(question_WrongAnswer);
        }

        //Öğrencinin karşısına çıkan soruları işaretlemesidir
        public ActionResult SorununDogruIsaretlenmesi(int id)
        {
            questionManager.GetByIdTrue(id);
            return RedirectToAction("EklenenSorularınGosterimi");
        }
        public ActionResult SorununYanlisIsaretlenmesi(int id)
        {
            questionManager.GetByIdFalse(id);
            return RedirectToAction("EklenenSorularınGosterimi");
        }

        //Bu kısım öğrencinin sadece yanlış yaptığı kısımları gösterir
        public ActionResult SoruModulununGosterilmesi()
        {
            question_WrongAnswer.Question = questionManager.GetAll().FindAll(x => x.AdminAllow == "Allow").Take(20);
            question_WrongAnswer.WrongAnswer = wrongAnswerManager.GetAll();
            return View(question_WrongAnswer);
        }

        //Öğrencinin yaptığı soruları başarı oranına göre raporlar
        public ActionResult SoruDetaylarınınRaporlanması()
        {
            var tumSorular = questionManager.GetAll();
            return View(tumSorular);
        }
    }
}