using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserRole:IEntity
    {
        [Key]
        public int UserRoleID { get; set; }
        [StringLength(20)]
        public string UserRoleName { get; set; }
        public ICollection<User> Users { get; set; }






    }
}
