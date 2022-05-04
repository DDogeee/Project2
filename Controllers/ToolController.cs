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
    [Route("api/[controller]")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly IToolService toolService;
        public ToolController(IToolService tool)
        {
            toolService = tool;
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Tool/GetTool")]
        public IEnumerable<Tool> GetTool()
        {
            return toolService.GetTool();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Tool/AddTool")]
        public Tool AddTool(Tool tool)
        {
            return toolService.AddTool(tool);
        }

        [HttpPut]
        [Route("[action]")]
        [Route("api/Tool/EditTool")]
        public Tool EditTool(Tool tool)
        {
            return toolService.EditTool(tool);
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Tool/DeleteTool")]
        public Tool DeleteTool(int id)
        {
            return toolService.DeleteTool(id);
        }
    }
}
