using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.IServices;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.ViewModel;
using System.Globalization;

namespace Project2.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly ToolManagementContext _dbContext;
        public OrderDetailService(ToolManagementContext db)
        {
            _dbContext = db;
        }
        public async Task<GenericResultModel<OrderDetailResponseViewModel>> GetOrderDetailAsync()
        {
            try
            {
                var details = await _dbContext.OrderDetails.Select(s => new OrderDetailResponseViewModel
                {
                    Id = s.Id,
                    OrderId = s.OrderId,
                    KeyId = s.KeyId,
                    Price = s.Price,
                    Discount = s.Discount,
                    Date = s.Date
                }).ToListAsync();

                return GenericResultModel<OrderDetailResponseViewModel>.Success(details);
            }
            catch
            {   
                return GenericResultModel<OrderDetailResponseViewModel>.Failed("Failed to view list of order details");
            }

        }
        public async Task<GenericResultModel<OrderDetailResponseViewModel>> GetOrderDetailIdAsync(OrderDetailResponseViewModel _detail)
        {
            try
            {
                var s = await _dbContext.OrderDetails.FirstOrDefaultAsync(x => x.Id == _detail.Id);
                var detailView = new OrderDetailResponseViewModel {
                    Id = s.Id,
                    OrderId = s.OrderId,
                    KeyId = s.KeyId,
                    Price = s.Price,
                    Discount = s.Discount,
                    Date = s.Date
                };
                return GenericResultModel<OrderDetailResponseViewModel>.Success(detailView);
            }
            catch
            {   
                return GenericResultModel<OrderDetailResponseViewModel>.Failed("Failed to get order detail by ID: " + _detail.Id);
            }
        }
        public async Task<GenericResultModel<OrderDetailResponseViewModel>> GetOrderDetailByOrderIdAsync(OrderDetailResponseViewModel _detail)
        {
            try
            {
                var details = await _dbContext.OrderDetails.Where(s => s.OrderId == _detail.OrderId).Select(s => new OrderDetailResponseViewModel
                {
                    Id = s.Id,
                    OrderId = s.OrderId,
                    KeyId = s.KeyId,
                    Price = s.Price,
                    Discount = s.Discount,
                    Date = s.Date
                }).ToListAsync();
                return GenericResultModel<OrderDetailResponseViewModel>.Success(details);
            }
            catch
            {
                return GenericResultModel<OrderDetailResponseViewModel>.Failed("Failed to view list of order details of this OrderId: " + _detail.OrderId);
            }
        }
        public async Task<OrderDetail> AddOrderDetailAsync(Order _order, ToolOrderDataModel _toolOrderData)
        {
            try
            {
                var keyService = new KeyService(_dbContext);
                var toolService = new ToolService(_dbContext);

                var orderDetail = new OrderDetail
                {
                    OrderId = _order.Id,
                    Date = _order.OrderDate,
                    //Generate a new key for this order detail
                    KeyId = await keyService.GenerateKey(_toolOrderData.ToolId, _toolOrderData.MachineId),
                    //Get tool price from database
                    Price = await toolService.GetToolPriceByIdAsync(_toolOrderData.ToolId),
                    Discount = _toolOrderData.Discount,
                };
                _dbContext.OrderDetails.Add(orderDetail);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine("Add a new order detail successfully");
                return orderDetail;
            }
            catch
            {   
                Console.WriteLine("Failed to add a new order detail");
                return null;
            }
        }
    }
}
