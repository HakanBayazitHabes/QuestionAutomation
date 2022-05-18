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
    public class UserRoleManager : IUserRoleService
    {

        IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }
        //userrole eklenir
        public void Add(UserRole userRole)
        {
            UserRoleValidator userRoleValidator = new UserRoleValidator();
            var result = userRoleValidator.Validate(userRole);
            if (result.Errors.Count <= 0)
            {
                _userRoleDal.Add(userRole);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }
        }
        //userrole silinir
        public void Delete(UserRole userRole)
        {
            try
            {
                _userRoleDal.Delete(userRole);
            }
            catch
            {

                throw new Exception("Silme Gerçekleştirilemedi!");
            }
        }
        // Bütün userrole UserRole tipinde  listeye alınır
        public List<UserRole> GetAll()
        {
            return _userRoleDal.GetAll();
        }
        //userrole ler update edilir
        public void Update(UserRole userRole)
        {
            _userRoleDal.Update(userRole);
        }
    }
}
