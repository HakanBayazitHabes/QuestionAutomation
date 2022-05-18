using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }
        //Soru ekleme işlemi burada gerçekleşir
        public void Add(Question question)
        {
            QuestionValidator questionValidator = new QuestionValidator();
            var result = questionValidator.Validate(question);
            if (result.Errors.Count <= 0)
            {
                question.AddDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _questionDal.Add(question);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }
        }
        //id ye göre false degeri atanır
        public void GetByIdFalse(int id)
        {
            var yanlisYapilanSoru = _questionDal.Get(x => x.ID == id);
            yanlisYapilanSoru.IsTrue = false;
            yanlisYapilanSoru.IsMark = true;
            yanlisYapilanSoru.IsMarkedModal = true;
            _questionDal.Update(yanlisYapilanSoru);
        }
        //Id'ye göre True degeri atanır
        public void GetByIdTrue(int id)
        {
            var dogruYapılanSoru = _questionDal.Get(x => x.ID == id);
            dogruYapılanSoru.IsTrue = true;
            dogruYapılanSoru.IsMark = true;
            dogruYapılanSoru.IsMarkedModal = true;
            _questionDal.Update(dogruYapılanSoru);
        }
        //Id'ye göre sorular active edilir
        public void GetByactiveID(int id)
        {
            var izinVerilenSoru=_questionDal.Get(x => x.ID == id);
            izinVerilenSoru.AdminAllow = "Allow";
            _questionDal.Update(izinVerilenSoru);
        }
        //Id'ye göre sorular pasif edilebilir
        public void GetByPassiveID(int id)
        {
            var izinVerilmeyenSoru = _questionDal.Get(x => x.ID==id);
            izinVerilmeyenSoru.AdminAllow = "Not Allow";
            _questionDal.Update(izinVerilmeyenSoru);
        }
        //Sorular silinir
        public void Delete(Question question)
        {
            try
            {
                _questionDal.Delete(question);
            }
            catch
            {

                throw new Exception("Silme Gerçekleştirilemedi!");
            }
        }
        //Bütün sorular question tipinde listeye eklenir
        public List<Question> GetAll()
        {
            return _questionDal.GetAll();
        }
        //sorular güncellenir
        public void Update(Question question)
        {
            _questionDal.Update(question);
        }
        //Son id'li soruyu getirir
        public IEnumerable<Question> GetByLastID(int id)
        {
            yield return _questionDal.Get(x => x.ID == id);
        }
        //sorunun id'sine göre soruyu getirir
        public Question GetByQuestionID(int id)
        {
            return _questionDal.Get(x => x.ID == id);
        }
    }
}
