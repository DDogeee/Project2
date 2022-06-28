using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.IServices;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.ViewModel;


namespace Project2.Services
{
    public class ToolService : IToolService
    {
        private readonly ToolManagementContext _dbContext;
        public ToolService(ToolManagementContext db)
        {
            _dbContext = db;
        }

        public async Task<GenericResultModel<ToolResponseViewModel>> GetToolAsync()
        {
            try
            {
                var tools = await _dbContext.Tools.Select(s => new ToolResponseViewModel
                {
                    Code = s.Code,
                    Description = s.Description,
                    Id = s.Id,
                    Image = s.Image,
                    Name = s.Name,
                    Price = s.Price,
                    Status = s.Status
                }).ToListAsync();

                return GenericResultModel<ToolResponseViewModel>.Success(tools);
            }
            catch
            {   
                return GenericResultModel<ToolResponseViewModel>.Failed("Failed to view list of tools");
            }

        }

        public async Task<GenericResultModel<ToolResponseViewModel>> AddToolAsync(ToolResponseViewModel _tool)
        {
            try
            {
                var tool = new Tool 
                {
                    Id = _tool.Id,
                    Code = _tool.Code,
                    Name = _tool.Name,
                    Image = _tool.Image,
                    Description = _tool.Description,
                    Price = _tool.Price,
                    Status = _tool.Status,
                    // CreatedBy = ?,
                    CreatedDate = DateTime.Now
                };

                _dbContext.Tools.Add(tool);
                await _dbContext.SaveChangesAsync();

                return GenericResultModel<ToolResponseViewModel>.Success("Tool added successfully");
            }
            catch
            {   
                return GenericResultModel<ToolResponseViewModel>.Failed("Failed to add tool");
            }

        }
        public async Task<GenericResultModel<ToolResponseViewModel>> EditToolAsync(ToolResponseViewModel _tool)
        {
            try
            {
                var tool = new Tool {
                    Id = _tool.Id,
                    Code = _tool.Code,
                    Name = _tool.Name,
                    Image = _tool.Image,
                    Description = _tool.Description,
                    Price = _tool.Price,
                    Status = _tool.Status,
                    // ModifiedBy = ?,
                    ModifiedDate = DateTime.Now
                };
                _dbContext.Entry(tool).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return GenericResultModel<ToolResponseViewModel>.Success("Tool edited successfully");
            }
            catch
            {   
                return GenericResultModel<ToolResponseViewModel>.Failed("Failed to edit tool");
            }
        }
        public async Task<GenericResultModel<ToolResponseViewModel>> DeleteToolAsync(ToolResponseViewModel _tool)
        {
            try
            {
                var tool = await _dbContext.Tools.FirstOrDefaultAsync(x => x.Id == _tool.Id);

                // _dbContext.Entry(tool).State = EntityState.Deleted;
                // update the value of IsDeleted instead
                // tool.DeletedBy = ?;
                tool.DeletedDate = DateTime.Now;

                _dbContext.Entry(tool).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return GenericResultModel<ToolResponseViewModel>.Success("Tool deleted successfully");
            }
            catch
            {   
                return GenericResultModel<ToolResponseViewModel>.Failed("Failed to delete tool");
            }
        }
        public async Task<GenericResultModel<ToolResponseViewModel>> GetToolIdAsync(ToolResponseViewModel _tool)
        {
            try
            {
                var tool = await _dbContext.Tools.FirstOrDefaultAsync(x => x.Id == _tool.Id);
                var toolView = new ToolResponseViewModel {
                    Id = tool.Id,
                    Code = tool.Code,
                    Name = tool.Name,
                    Image = tool.Image,
                    Description = tool.Description,
                    Price = tool.Price,
                    Status = tool.Status,
                };
                return GenericResultModel<ToolResponseViewModel>.Success(toolView);
            }
            catch
            {   
                return GenericResultModel<ToolResponseViewModel>.Failed("Failed to get tool by ID");
            }
        }
        public async Task<decimal> GetToolPriceByIdAsync(int _toolId)
        {
            try
            {
                var tool = await _dbContext.Tools.FirstOrDefaultAsync(x => x.Id == _toolId);

                Console.WriteLine("Get price for this tool successfully");
                return tool.Price;
            }
            catch
            {   
                Console.WriteLine("Failed to get price for this tool");
                return 0;
            }
        }
    }
}
