using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.ViewModel;

namespace Project2.IServices
{
    public interface IToolService
    {
        Task<GenericResultModel<ToolResponseViewModel>> GetToolAsync();
        JsonResult AddTool(Tool tool);
        JsonResult EditTool(Tool tool);
        JsonResult DeleteTool(int id);
        JsonResult GetToolId(int id);



    }
}
