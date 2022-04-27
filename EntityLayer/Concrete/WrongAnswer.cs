using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WrongAnswer:IEntity
    {
        [Key]
        public int WrongAnswerID { get; set; }
        [StringLength(25)]
        [Required(ErrorMessage = "Name is WrongAnswer 1.")]
        public string WrongAnswer_1 { get; set; }
        [StringLength(25)]
        [Required(ErrorMessage = "Name is WrongAnswer 2.")]
        public string WrongAnswer_2 { get; set; }
        [StringLength(25)]
        [Required(ErrorMessage = "Name is WrongAnswer 3.")]
        public string WrongAnswer_3 { get; set; }


        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
