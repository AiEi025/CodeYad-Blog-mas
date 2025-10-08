using CodeYad_Blog.CoreLayer.DTOs.Users;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _blogContext;
        public UserService(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public OperationResult LoginUser(LoginUserDTO loginUserDTO)
        {
            var passhashed = loginUserDTO.Passsword.EncodeToMd5();
            var Issuccess = _blogContext.Users.Any(p=>p.UserName== loginUserDTO.UserName && p.Password == passhashed);
            if (!Issuccess)
                return OperationResult.NotFound("مورد مورد نظر یافت نشد");
            return OperationResult.Success();
        }

        public OperationResult RegisterUser(UserRegisterDTO RegisterDTO)
        {
            var IsUserNameExist = _blogContext.Users.Any(p=>p.UserName == RegisterDTO.UserName);
            if (IsUserNameExist)
               return OperationResult.Error("نام کاربری تکراری است");

            var passwordhash = RegisterDTO.Password.EncodeToMd5();
            _blogContext.Users.Add(new User
            { 
            FullName = RegisterDTO.FullName,
            IsDelete = false,
            UserName = RegisterDTO.UserName,
            Role = UserRole.User,
            CreationDate = DateTime.Now,
            Password = passwordhash,
            });
            _blogContext.SaveChanges();
            return OperationResult.Success();
        }
    }
}
