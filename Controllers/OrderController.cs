using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.IServices;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Project2.Controllers
{
    [Route("api/quan-ly-don-hang")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("danh-sach")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> GetOrderAsync()
        {
            return await _orderService.GetOrderAsync();
        }

        [HttpGet("cho-duyet")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> GetPendingOrderAsync()
        {
            return await _orderService.GetPendingOrderAsync();
        }

        [HttpPost("them-don-hang")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> AddOrderAsync(OrderDataModel _orderData)
        {
            return await _orderService.AddOrderAsync(_orderData);
        }

        [HttpPut("duyet-don-hang")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> ApproveOrderAsync(OrderResponseViewModel _order)
        {
           return await _orderService.ApproveOrderAsync(_order);
        }

        [HttpPut("xoa-don-hang")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> DeleteOrderAsync(OrderResponseViewModel _order)
        {
            return await _orderService.DeleteOrderAsync(_order);
        }

        [HttpGet("chi-tiet/{id:int}")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> GetOrderIdAsync(int id)
        {
            return await _orderService.GetOrderIdAsync(id);
        }

        [HttpGet("lich-su/{userId:int}")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> GetUserOrderHistoryAsync(int userId)
        {
            return await _orderService.GetUserOrderHistoryAsync(userId);

        }
    }
}
