using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWrongAnswerService
    {
        List<WrongAnswer> GetAll();
        void Add(WrongAnswer wrongAnswer);
        void Update(WrongAnswer wrongAnswer);
        void Delete(WrongAnswer wrongAnswer);
    }
}
