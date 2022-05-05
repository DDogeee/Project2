using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.IServices
{
    public interface IToolService
    {
        JsonResult GetTool();
        JsonResult AddTool(Tool tool);
        JsonResult EditTool(Tool tool);
        JsonResult DeleteTool(int id);
        JsonResult GetToolId(int id);



    }
}
