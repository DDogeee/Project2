using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project2.IServices;
using Project2.Models;
using Project2.Services;
using Project2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    [Route("api/quan-ly-user")]
    [ApiController]
    
    public class UserController
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        public UserController(IConfiguration config, IUserService userService)
        {
            _userService = userService;
            _config = config;
        }


        [HttpPost]
        [Route("dang-nhap")]
        public GenericResultModel<JsonResult> Login(UserResponseViewModel user)
        {
            return _userService.Login(user);
        }

        [HttpGet]
        [Route("chi-tiet")]
        public JsonResult GetUserId(int id)
        {
            return _userService.GetUserId(id);
        }
        
        [HttpPost]
        [Route("dang-ki")]
        public GenericResultModel<UserResponseViewModel> Register(UserResponseViewModel user)
        {
            return _userService.Register(user);
        }

    }
}
