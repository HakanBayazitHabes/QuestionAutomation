using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Question:IEntity
    {
        [Key]
        public int ID { get; set; }
        [StringLength(30)]
        public string CourseName { get; set; }
        [StringLength(30)]
        public string UnitName { get; set; }
        [StringLength(3000)]
        public string QuestionText { get; set; }
        [StringLength(40)]
        public string CorrectAnswer { get; set; }
        public bool TeacherAllow { get; set; }
        public bool AdminAllow { get; set; }

        public ICollection<WrongAnswer> WrongAnswers { get; set; }
    }
}
