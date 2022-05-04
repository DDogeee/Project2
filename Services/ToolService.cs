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
        QuanlykeyphanmemContext dbContext;
        public ToolService(QuanlykeyphanmemContext _db)
        {
            dbContext = _db;
        }
        public IEnumerable<Tool> GetTool()
        {
            var tools = dbContext.Tools.ToList();
            return tools;
        }

        public Tool AddTool(Tool tool)
        {
            if (tool != null)
            {
                dbContext.Tools.Add(tool);
                dbContext.SaveChanges();
                return tool;
            }
            return null;
        }

        public Tool EditTool(Tool tool)
        {
            dbContext.Entry(tool).State = EntityState.Modified;
            dbContext.SaveChanges();
            return tool;
        }
        public Tool DeleteTool(int id)
        {
            var tool = dbContext.Tools.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(tool).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return tool;
        }
    }
}
