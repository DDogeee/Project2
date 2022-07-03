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
                    OrderDate = s.OrderDate,
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
        public async Task<GenericResultModel<OrderResponseViewModel>> GetPendingOrderAsync()
        {
            try
            {
                var pendingOrders = await _dbContext.Orders.Where(s => s.Status == Constants.StatusPending).Select(s => new OrderResponseViewModel
                {
                    Id = s.Id,
                    UserId = s.UserId,
                    OrderDate = s.OrderDate,
                    TotalPrice = s.TotalPrice,
                    Status = s.Status
                }).ToListAsync();
                return GenericResultModel<OrderResponseViewModel>.Success(pendingOrders);
            }
            catch
            {
                return GenericResultModel<OrderResponseViewModel>.Failed("Failed to view list of pending orders");
            }
        }
        public async Task<GenericResultModel<OrderResponseViewModel>> AddOrderAsync(OrderDataModel _orderData)
        {
            try
            {
                var currentTime = DateTime.Now;
                decimal currentPrice = 0;                   //Keep track of prices

                var order = new Order
                {
                    UserId = _orderData.UserId,
                    OrderDate = currentTime,
                    TotalPrice = currentPrice,
                    Status = Constants.StatusPending        //New order awaits admin's approval
                };
                _dbContext.Orders.Add(order);               //Add a blank new order to get the ID for order details
                await _dbContext.SaveChangesAsync();

                //Add new order details according to the number of tools and their amount of keys in the order
                var orderDetail = new OrderDetailService(_dbContext);
                foreach (var tool in _orderData.Tools)
                {
                    for (int i = 0; i < tool.NumberOfKeys; i++)
                    {
                        var detail = await orderDetail.AddOrderDetailAsync(order, tool);
                        if (detail.Discount != null)
                        {
                            currentPrice += detail.Price * (1 - detail.Discount.Value / 100);
                        }
                        else
                        {
                            currentPrice += detail.Price;
                        }
                    }
                }

                //Add the total price of the order into database
                order.TotalPrice = currentPrice;
                _dbContext.Entry(order).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return GenericResultModel<OrderResponseViewModel>.Success("A new order added successfully");
            }
            catch
            {
                return GenericResultModel<OrderResponseViewModel>.Failed("Failed to add a new order");
            }
        }
        public async Task<GenericResultModel<OrderResponseViewModel>> ApproveOrderAsync(OrderResponseViewModel order)
        {
            try
            {   // Join table OrderDetails and table Keys

                var query = from od in _dbContext.OrderDetails
                            join k in _dbContext.Keys on od.KeyId equals k.Id
                            where od.OrderId == order.Id
                            select new { Detail = od, Key = k };

                // Activate all keys found by the given orderID
                foreach (var item in query)
                {
                    var key = item.Key;
                    if (key != null)
                    {
                        key.Status = Constants.StatusActive;
                        key.StartDate = DateTime.Now;
                        key.ToDate = DateTime.Now.Add(new TimeSpan(365, 0, 0, 0));
                    }
                }

                // Activate the order itself
                var orderItem = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == order.Id);
                orderItem.Status = Constants.StatusActive;

                await _dbContext.SaveChangesAsync();

                return GenericResultModel<OrderResponseViewModel>.Success("Approve this order successfully");
            }
            catch
            {
                return GenericResultModel<OrderResponseViewModel>.Failed("Failed to approve this order");
            }

        }
        public async Task<GenericResultModel<OrderResponseViewModel>> DeleteOrderAsync(OrderResponseViewModel _order)
        {
            try
            {
                var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == _order.Id);
                order.Status = Constants.StatusDeleted;
                _dbContext.Entry(order).State = EntityState.Modified;
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
                var orderView = new OrderResponseViewModel
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    OrderDate = order.OrderDate,
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
        // Stack overflow when called, didn't enter breakpoints inside function when debugging
        // public async Task<GenericResultModel<OrderResponseViewModel>> GetOrderByUserIdAsync(OrderResponseViewModel _order)
        // {
        //     try
        //     {
        //         var userOrders = await _dbContext.Orders.Where(s => s.UserId == _order.UserId).Select(s => new OrderResponseViewModel
        //         {
        //             Id = s.Id,
        //             UserId = s.UserId,
        //             OrderDate = s.OrderDate,
        //             TotalPrice = s.TotalPrice,
        //             Status = s.Status
        //         }).ToListAsync();
        //         return GenericResultModel<OrderResponseViewModel>.Success(userOrders);
        //     }
        //     catch
        //     {
        //         return GenericResultModel<OrderResponseViewModel>.Failed("Failed to view list of orders by userID: " + _order.UserId);
        //     }
        // }
    }
}
