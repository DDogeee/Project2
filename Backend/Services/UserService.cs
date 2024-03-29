﻿using Microsoft.AspNetCore.Mvc;
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

        public GenericResultModel<UserResponseViewModel> Register(UserResponseViewModel user)
        {
            try
            {
                var _userchecker = _dbContext.Users.SingleOrDefault(x => x.Username == user.Username);

                if (_userchecker == null)
                {
                    var _user = new User
                    {
                        IsAdmin = user.IsAdmin,
                        Username = user.Username,
                        Password = user.Password,
                        Phone = user.Phone,
                        Status = Constants.StatusActive
                    };

                    _dbContext.Users.Add(_user);
                    _dbContext.SaveChanges();

                    user.Id = _user.Id;
                    return GenericResultModel<UserResponseViewModel>.Success(user);
                }
                else
                {
                    return GenericResultModel<UserResponseViewModel>.Failed("Username already exist");
                }        
            }
            catch
            {
                return GenericResultModel<UserResponseViewModel>.Failed("Something went wrong");

            }
        }
        public GenericResultModel<JsonResult> Login(UserResponseViewModel user)
        {
            var _user = _dbContext.Users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            // return null if user not found
            if (_user == null)
                return GenericResultModel<JsonResult>.Failed("Wrong password");
            else
            {
                var __user = new UserResponseViewModel
                {
                    IsAdmin = _user.IsAdmin,
                    Username = _user.Username,
                    Phone = _user.Phone,
                    Fullname = _user.Fullname,
                    Email = _user.Email,
                    Status = _user.Status,
                };
                var jwt = new JwtService(_config);
                
                var token = jwt.GenerateSecurityToken(__user.Username);
                var data = new {token = token, user=__user};
                return GenericResultModel<JsonResult>.Success(new JsonResult(data));
            }
        }
        public GenericResultModel<UserResponseViewModel> GetUserInfo(string username)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Username == username);
                var userView = new UserResponseViewModel
                {
                    Id = user.Id,
                    IsAdmin = user.IsAdmin,
                    Username = user.Username,
                    Phone = user.Phone,
                    Fullname = user.Fullname,
                    Email = user.Email,
                    Status = user.Status,
                };
                return GenericResultModel<UserResponseViewModel>.Success(userView);
            }
            catch
            {
                return GenericResultModel<UserResponseViewModel>.Success("Failed to get information from user " + username);
            }
        }

        public GenericResultModel<string> Logout(string token)
        {
            var _token = new ExpiredToken
            {
                ExpiredToken1 = token
            };
            _dbContext.ExpiredTokens.Add(_token);
            _dbContext.SaveChanges();
            return GenericResultModel<string>.Success("Logout Successful");
        }
    }
}
