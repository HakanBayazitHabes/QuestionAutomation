using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User:IEntity
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(20)]
        public string SurName { get; set; }
        [StringLength(15)]
        public string Password { get; set; }
        [StringLength(30)]
        public string Mail { get; set; }


        public int UserRoleID { get; set; }
        public virtual UserRole UserRole { get; set; }

    }
}
