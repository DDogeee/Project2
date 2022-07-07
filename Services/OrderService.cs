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
        private OrderDetailService _orderDetailService;
        public OrderService(ToolManagementContext db)
        {
            _dbContext = db;
            _orderDetailService = new OrderDetailService(db);
        }

        public async Task<GenericResultModel<OrderResponseViewModel>> GetOrderAsync()
        {
            try
            {
                // Join table Order and table Users
                var query = from od in _dbContext.Orders
                            join u in _dbContext.Users on od.UserId equals u.Id
                            select new { Order = od, User = u };

                var orders = await query.Select(item => new OrderResponseViewModel
                {
                        Id = item.Order.Id,
                        Username = item.User.Username,
                        OrderDate = item.Order.OrderDate,
                        TotalPrice = item.Order.TotalPrice,
                        Status = item.Order.Status
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
                // Join table Order and table Users
                var query = from od in _dbContext.Orders
                            join u in _dbContext.Users on od.UserId equals u.Id
                            where od.Status == Constants.StatusPending
                            select new { Order = od, User = u };

                var pendingOrders = await query.Select(s => new OrderResponseViewModel
                {
                    Id = s.Order.Id,
                    Username = s.User.Username,
                    OrderDate = s.Order.OrderDate,
                    TotalPrice = s.Order.TotalPrice,
                    Status = s.Order.Status
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

                var user = await _dbContext.Users.FirstOrDefaultAsync(s => s.Username == _orderData.Username);

                var order = new Order
                {
                    UserId = user.Id,
                    OrderDate = currentTime,
                    TotalPrice = currentPrice,
                    Status = Constants.StatusPending        //New order awaits admin's approval
                };
                _dbContext.Orders.Add(order);               //Add a blank new order to get the ID for order details
                await _dbContext.SaveChangesAsync();

                //Add new order details according to the number of tools and their amount of keys in the order
                foreach (var tool in _orderData.Tools)
                {
                    for (int i = 0; i < tool.NumberOfKeys; i++)
                    {
                        var detail = await _orderDetailService.AddOrderDetailAsync(order, tool);
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
        public async Task<GenericResultModel<OrderResponseViewModel>> GetOrderIdAsync(int id)
        {
            try
            {
                // Join table Order and table Users
                var query = from od in _dbContext.Orders
                            join u in _dbContext.Users on od.UserId equals u.Id
                            where od.Id == id
                            select new { Order = od, User = u };

                var orderView = await query.Select(item => new OrderResponseViewModel
                {
                        Id = item.Order.Id,
                        Username = item.User.Username,
                        OrderDate = item.Order.OrderDate,
                        TotalPrice = item.Order.TotalPrice,
                        Status = item.Order.Status
                }).ToListAsync();
                return GenericResultModel<OrderResponseViewModel>.Success(orderView);
            }
            catch
            {
                return GenericResultModel<OrderResponseViewModel>.Failed("Failed to get order by ID: " + id);
            }
        }
        public async Task<GenericResultModel<OrderResponseViewModel>> GetUserOrderHistoryAsync(string username)
        {
            try
            {
                // Join table Order and table Users
                var query = from od in _dbContext.Orders
                            join u in _dbContext.Users on od.UserId equals u.Id
                            where u.Username == username
                            select new { Order = od, User = u };

                var userOrders = await query.Select(item => new OrderResponseViewModel
                {
                        Id = item.Order.Id,
                        Username = item.User.Username,
                        OrderDate = item.Order.OrderDate,
                        TotalPrice = item.Order.TotalPrice,
                        Status = item.Order.Status
                }).ToListAsync();
                return GenericResultModel<OrderResponseViewModel>.Success(userOrders);
            }
            catch
            {
                return GenericResultModel<OrderResponseViewModel>.Failed("Failed to view list of orders by user: " + username);
            }
        }
    }
}
