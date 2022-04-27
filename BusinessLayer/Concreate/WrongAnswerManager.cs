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

        public List<WrongAnswer> GetAll()
        {
            return _wrongAnswerDal.GetAll();
        }

        public void Update(WrongAnswer wrongAnswer)
        {
            _wrongAnswerDal.Update(wrongAnswer);
        }
    }
}
