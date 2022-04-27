using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IQuestionService
    {
        List<Question> GetAll();
        void Add(Question question);
        void Update(Question question);
        void Delete(Question question);
    }
}
