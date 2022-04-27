using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserRoleService
    {
        List<UserRole> GetAll();
        void Add(UserRole userRole);
        void Update(UserRole userRole);
        void Delete(UserRole userRole);
    }
}
