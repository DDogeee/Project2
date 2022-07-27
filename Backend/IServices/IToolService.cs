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
        Task<GenericResultModel<ToolResponseViewModel>> AddToolAsync(ToolResponseViewModel _tool);
        Task<GenericResultModel<ToolResponseViewModel>> EditToolAsync(ToolResponseViewModel _tool);
        Task<GenericResultModel<ToolResponseViewModel>> DeleteToolAsync(ToolResponseViewModel _tool);
        Task<GenericResultModel<ToolResponseViewModel>> GetToolIdAsync(int id);



    }
}
