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


        [HttpGet("danh-sach-don-hang")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> GetOrderAsync()
        {
            return await _orderService.GetOrderAsync();
        }

        [HttpPost("them-don-hang")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> AddOrderAsync(OrderResponseViewModel _order)
        {
            return await _orderService.AddOrderAsync(_order);
        }

        [HttpPut("sua-don-hang")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> EditToolAsync(OrderResponseViewModel _order)
        {
            return await _orderService.EditOrderAsync(_order);
        }

        [HttpDelete("xoa-don-hang")]
        [Authorize]
        public async Task<GenericResultModel<OrderResponseViewModel>> DeleteToolAsync(OrderResponseViewModel _order)
        {
            return await _orderService.DeleteOrderAsync(_order);
        }

        [HttpGet("chi-tiet")]
        public async Task<GenericResultModel<OrderResponseViewModel>> GetToolIdAsync(OrderResponseViewModel _order)
        {
            return await _orderService.GetOrderIdAsync(_order);
        }
    }
}
