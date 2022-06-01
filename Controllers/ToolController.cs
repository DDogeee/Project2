using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.IServices;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Project2.Controllers
{
    [Route("api/quan-ly-tool")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly IToolService _toolService;
        public ToolController(IToolService toolService)
        {
            _toolService = toolService;
        }


        [HttpGet("danh-sach-tool")]
        public async Task<GenericResultModel<ToolResponseViewModel>> GetTool()
        {
            return await _toolService.GetToolAsync();
        }

        [HttpPost]
        [Route("them-tool")]
        [Authorize]

        public JsonResult AddTool(Tool tool)
        {
            return _toolService.AddTool(tool);
        }

        [HttpPut]
        [Route("sua-tool")]
        [Authorize]

        public JsonResult EditTool(Tool tool)
        {
            return _toolService.EditTool(tool);
        }

        [HttpDelete]
        [Route("xoa-tool")]
        [Authorize]

        public JsonResult DeleteTool(int id)
        {
            return _toolService.DeleteTool(id);
        }

        [HttpGet]
        [Route("chi-tiet")]
        public JsonResult GetToolId(int id)
        {
            return _toolService.GetToolId(id);
        }
    }
}
