using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.IServices
{
    public interface IToolService
    {
        IEnumerable<Tool> GetTool();
        Tool AddTool(Tool tool);
        Tool EditTool(Tool tool);
        Tool DeleteTool(int id);



    }
}
