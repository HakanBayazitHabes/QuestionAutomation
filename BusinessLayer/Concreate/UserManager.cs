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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        //User ekleme işlemi yapılır
        public void Add(User user)
        {
            UserValidator usertValidator = new UserValidator();
            var result = usertValidator.Validate(user);
            if (result.Errors.Count <= 0)
            {
                _userDal.Add(user);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }
        }
        //Usser Silinir
        public void Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
            }
            catch
            {

                throw new Exception("Silme Gerçekleştirilemedi!");
            }
        }
        //Mail ve password'a göre kullanıcı getirilir
        public User GetByMailPassword(User user)
        {
            return _userDal.Get(x => x.Mail == user.Mail && x.Password== user.Password);
        }

        //Bütün kullanıcıları getirir.
        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }
        //Kullanıcıları güncelleştirir
        public void Update(User user)
        {
            _userDal.Update(user);
        }
        //mail3 göre kullanıcı getirir
        public User GetByEmail(User user)
        {
            return _userDal.Get(x => x.Mail == user.Mail);
        }

        
    }
}
