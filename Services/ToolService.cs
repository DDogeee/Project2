using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.IServices;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project2.Services
{
    public class ToolService : IToolService
    {
        ToolManagementContext _dbContext;
        public ToolService(ToolManagementContext db)
        {
            _dbContext = db;
        }
        public JsonResult GetTool()
        {
            try
            {
                var tools = _dbContext.Tools.ToList();
                var data = new { has_error = "no", message = "successfully get tool", data = tools };
                return new JsonResult(data);
            }
            catch
            {
                var data = new { has_error = "no", message = "something went wrong" };
                return new JsonResult(data);
            }

        }

        public JsonResult AddTool(Tool tool)
        {
            try
            {
                _dbContext.Tools.Add(tool);
                _dbContext.SaveChanges();
                var data = new { has_error = "no", message = "successfully add tool", data =  tool};
                return new JsonResult(data);
            }
            catch
            {
                var data = new { has_error = "no", message = "something went wrong" };
                return new JsonResult(data);
            }
        }

        public JsonResult EditTool(Tool tool)
        {
            try
            {
                _dbContext.Entry(tool).State = EntityState.Modified;
                _dbContext.SaveChanges();
                var data = new { has_error = "no", message = "successfully edit tool" , data = tool};
                return new JsonResult(data);
            }
            catch
            {
                var data = new { has_error = "yes", message = "something went wrong" };
                return new JsonResult(data);
            }
            
        }
        public JsonResult DeleteTool(int id)
        {
            try 
            {
                var tool = _dbContext.Tools.FirstOrDefault(x => x.Id == id);
                _dbContext.Entry(tool).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                var data = new { has_error = "no", message = "successfully delete tool" , data = tool};
                return new JsonResult(data);
            }
            catch
            {
                var data = new { has_error = "yes", message = "something went wrong"};
                return new JsonResult(data);
            }

        }
        public JsonResult GetToolId(int id)
        {
            try
            {
                var tool = _dbContext.Tools.FirstOrDefault(x => x.Id == id);
                var data = new { has_error = "no", message = "successfully get tool", data = tool};
                return new JsonResult(data);
            }
            catch
            {
                var data = new { has_error = "yes", message = "something went wrong" };
                return new JsonResult(data);
            }
        }
    }
}
