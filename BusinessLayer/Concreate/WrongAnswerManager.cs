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
    public class WrongAnswerManager : IWrongAnswerService
    {
        IWrongAnswerDal _wrongAnswerDal;

        public WrongAnswerManager(IWrongAnswerDal wrongAnswerDal)
        {
            _wrongAnswerDal = wrongAnswerDal;
        }
        //yanlış cevap eklediği kısım
        public void Add(WrongAnswer wrongAnswer)
        {
            WrongAnswerValidator wrongAnswerValidator = new WrongAnswerValidator();
            var result = wrongAnswerValidator.Validate(wrongAnswer);
            if (result.Errors.Count <= 0)
            {
                _wrongAnswerDal.Add(wrongAnswer);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }
        }
        //yanlışcevapların silindiği kısım
        public void Delete(WrongAnswer wrongAnswer)
        {
            try
            {
                _wrongAnswerDal.Delete(wrongAnswer);
            }
            catch
            {

                throw new Exception("Silme Gerçekleştirilemedi!");
            }
        }
        //Bütün soruşarın WrongAnswer tiinde listeye atanması
        public List<WrongAnswer> GetAll()
        {
            return _wrongAnswerDal.GetAll();
        }
        //yanlış cevapalrın güncelleştirilemsi
        public void Update(WrongAnswer wrongAnswer)
        {
            _wrongAnswerDal.Update(wrongAnswer);
        }
    }
}
