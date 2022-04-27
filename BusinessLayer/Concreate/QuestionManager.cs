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
                _questionDal.Add(question);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }
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
    }
}
