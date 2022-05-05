using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.IServices;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    [Route("api/quan-ly-tool")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly IToolService toolService;
        public ToolController(IToolService tool)
        {
            toolService = tool;
        }


        [HttpGet]
        [Route("danh-sach-tool")]
        public JsonResult GetTool()
        {
            return toolService.GetTool();
        }

        [HttpPost]
        [Route("them-tool")]
        public JsonResult AddTool(Tool tool)
        {
            return toolService.AddTool(tool);
        }

        [HttpPut]
        [Route("sua-tool")]
        public JsonResult EditTool(Tool tool)
        {
            return toolService.EditTool(tool);
        }

        [HttpDelete]
        [Route("xoa-tool")]
        public JsonResult DeleteTool(int id)
        {
            return toolService.DeleteTool(id);
        }

        [HttpGet]
        [Route("lay-tool-theo-id")]
        public JsonResult GetToolId(int id)
        {
            return toolService.GetToolId(id);
        }
    }
}
