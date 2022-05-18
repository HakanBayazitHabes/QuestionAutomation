using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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
        [StringLength(30)]
        public string SubjectName { get; set; }
        [StringLength(4000)]
        [AllowHtml]
        public string QuestionText { get; set; }
        public DateTime AddDate { get; set; }
        [StringLength(250)]
        public string CorrectAnswer { get; set; }
        public string AdminAllow { get; set; }
        public bool IsTrue { get; set; }
        public bool IsMark { get; set; }
        public bool IsMarkedModal { get; set; }
        public ICollection<WrongAnswer> WrongAnswers { get; set; }
    }
}
