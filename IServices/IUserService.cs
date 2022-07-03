using Microsoft.AspNetCore.Mvc;
using Project2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.IServices
{
    public interface IUserService
    {
        GenericResultModel<JsonResult> Login(UserResponseViewModel user);
        GenericResultModel<UserResponseViewModel> GetUserId(UserResponseViewModel _user);
        GenericResultModel<UserResponseViewModel> Register(UserResponseViewModel user);
        GenericResultModel<string> Logout(string token);
    }
}
