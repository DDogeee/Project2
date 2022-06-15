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

        [HttpPost("them-tool")]
        [Authorize]
        public async Task<GenericResultModel<ToolResponseViewModel>> AddToolAsync(ToolResponseViewModel _tool)
        {
            return await _toolService.AddToolAsync(_tool);
        }

        [HttpPut("sua-tool")]
        [Authorize]

        // public JsonResult EditTool(Tool tool)
        // {
        //     return _toolService.EditTool(tool);
        // }

        public async Task<GenericResultModel<ToolResponseViewModel>> EditToolAsync(ToolResponseViewModel _tool)
        {
            return await _toolService.EditToolAsync(_tool);
        }

        [HttpDelete("xoa-tool")]
        [Authorize]

        // public JsonResult DeleteTool(int id)
        // {
        //     return _toolService.DeleteTool(id);
        // }

        public async Task<GenericResultModel<ToolResponseViewModel>> DeleteToolAsync(int id)
        {
            return await _toolService.DeleteToolAsync(id);
        }

        [HttpGet("chi-tiet")]
        public async Task<GenericResultModel<ToolResponseViewModel>> GetToolIdAsync(int id)
        {
            return await _toolService.GetToolIdAsync(id);
        }
    }
}
