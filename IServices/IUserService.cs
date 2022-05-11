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
        GenericResultModel<string> Login(UserResponseViewModel user);
        JsonResult GetUserId(int id);
    }
}
