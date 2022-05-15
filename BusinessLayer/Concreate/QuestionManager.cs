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

        public void GetByIdFalse(int id)
        {
            var yanlisYapilanSoru = _questionDal.Get(x => x.ID == id);
            yanlisYapilanSoru.IsTrue = false;
            yanlisYapilanSoru.IsMark = true;
            yanlisYapilanSoru.IsMarkedModal = true;
            _questionDal.Update(yanlisYapilanSoru);
        }

        public void GetByIdTrue(int id)
        {
            var dogruYapılanSoru = _questionDal.Get(x => x.ID == id);
            dogruYapılanSoru.IsTrue = true;
            dogruYapılanSoru.IsMark = true;
            dogruYapılanSoru.IsMarkedModal = true;
            _questionDal.Update(dogruYapılanSoru);
        }

        public void GetByactiveID(int id)
        {
            var izinVerilenSoru=_questionDal.Get(x => x.ID == id);
            izinVerilenSoru.AdminAllow = "Allow";
            _questionDal.Update(izinVerilenSoru);
        }

        public void GetByPassiveID(int id)
        {
            var izinVerilmeyenSoru = _questionDal.Get(x => x.ID==id);
            izinVerilmeyenSoru.AdminAllow = "Not Allow";
            _questionDal.Update(izinVerilmeyenSoru);
        }

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

        public List<Question> GetAll()
        {
            return _questionDal.GetAll();
        }

        public void Update(Question question)
        {
            _questionDal.Update(question);
        }

        public IEnumerable<Question> GetByLastID(int id)
        {
            yield return _questionDal.Get(x => x.ID == id);
        }

        public Question GetByQuestionID(int id)
        {
            return _questionDal.Get(x => x.ID == id);
        }
    }
}
