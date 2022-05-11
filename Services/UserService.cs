using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project2.Helpers;
using Project2.IServices;
using Project2.Models;
using Project2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services
{
    public class UserService : IUserService
    {
        private readonly ToolManagementContext _dbContext;
        private IConfiguration _config;

        public UserService(ToolManagementContext db, IConfiguration config)
        {
            _dbContext = db;
            _config = config;
        }


        public GenericResultModel<string> Login(UserResponseViewModel user)
        {


            var _user = _dbContext.Users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            // return null if user not found
            if (_user == null)
                return GenericResultModel<string>.Failed("Wrong password");
            else
            {
                var jwt = new JwtService(_config);
                var token = jwt.GenerateSecurityToken(user.Username);

                return GenericResultModel<string>.Success(token);
            }


        }

        public JsonResult GetUserId(int id)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
                var data = new { has_error = "no", message = "successfully get tool", data = user };
                return new JsonResult(data);
            }
            catch
            {
                var data = new { has_error = "yes", message = "something went wrong" };
                return new JsonResult(data);
            }
        }
    }
}
