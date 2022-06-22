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
    public class OrderService : IOrderService
    {
        private readonly ToolManagementContext _dbContext;
        public OrderService(ToolManagementContext db)
        {
            _dbContext = db;
        }

        public async Task<GenericResultModel<OrderResponseViewModel>> GetOrderAsync()
        {
            try
            {
                var orders = await _dbContext.Orders.Select(s => new OrderResponseViewModel
                {
                    Id = s.Id,
                    UserId = s.UserId,
                    OrderDate = s.OrderDate.ToString(),
                    TotalPrice = s.TotalPrice,
                    Status = s.Status
                }).ToListAsync();

                return GenericResultModel<OrderResponseViewModel>.Success(orders);
            }
            catch
            {   
                return GenericResultModel<OrderResponseViewModel>.Failed("Failed to view list of orders");
            }

        }

        public async Task<GenericResultModel<OrderResponseViewModel>> AddOrderAsync(OrderResponseViewModel _order)
        {
             var order = new Order 
                {
                    UserId = _order.UserId,
                    OrderDate = DateTime.ParseExact(_order.OrderDate, "yyyy-MM-dd HH:mm:ss.zzz", CultureInfo.InvariantCulture),
                    TotalPrice = _order.TotalPrice,
                    Status = _order.Status
                };

                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();
                return GenericResultModel<OrderResponseViewModel>.Success("A new order added successfully");
            // try
            // {


            // }
            // catch
            // {   
            //     return GenericResultModel<OrderResponseViewModel>.Failed("Failed to add a new order");
            // }

        }

        //Only admins can modify orders, or not?
        public async Task<GenericResultModel<OrderResponseViewModel>> EditOrderAsync(OrderResponseViewModel _order)
        {
            try
            {
                var order = new Order {
                    Id = _order.Id,
                    UserId = _order.UserId,
                    OrderDate = DateTime.ParseExact(_order.OrderDate, "yyyy-MM-dd HH:mm:ss.zzz", CultureInfo.InvariantCulture),
                    TotalPrice = _order.TotalPrice,
                    Status = _order.Status
                };
                _dbContext.Entry(order).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return GenericResultModel<OrderResponseViewModel>.Success("Order edited successfully");
            }
            catch
            {   
                return GenericResultModel<OrderResponseViewModel>.Failed("Failed to edit order");
            }
        }
        public async Task<GenericResultModel<OrderResponseViewModel>> DeleteOrderAsync(OrderResponseViewModel _order)
        {
            try
            {
                var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == _order.Id);
                _dbContext.Entry(order).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return GenericResultModel<OrderResponseViewModel>.Success("Order deleted successfully");
            }
            catch
            {   
                return GenericResultModel<OrderResponseViewModel>.Failed("Failed to delete order");
            }
        }
          public async Task<GenericResultModel<OrderResponseViewModel>> GetOrderIdAsync(OrderResponseViewModel _order)
        {
            try
            {
                var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == _order.Id);
                var orderView = new OrderResponseViewModel {
                    Id = order.Id,
                    UserId = order.UserId,
                    OrderDate = order.OrderDate.ToString(),
                    TotalPrice = order.TotalPrice,
                    Status = order.Status
                };
                return GenericResultModel<OrderResponseViewModel>.Success(orderView);
            }
            catch
            {   
                return GenericResultModel<OrderResponseViewModel>.Failed("Failed to get order by ID");
            }
        }
    }
}
