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
    [Route("api/chi-tiet-don-hang")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("danh-sach")]
        [Authorize]
        public async Task<GenericResultModel<OrderDetailResponseViewModel>> GetOrderDetailAsync()
        {
            return await _orderDetailService.GetOrderDetailAsync();
        }

        [HttpGet("theo-id")]
        [Authorize]
        public async Task<GenericResultModel<OrderDetailResponseViewModel>> GetOrderDetailIdAsync(OrderDetailResponseViewModel _detail)
        {
            return await _orderDetailService.GetOrderDetailIdAsync(_detail);
        }

        [HttpGet("theo-don-hang")]
        public async Task<GenericResultModel<OrderDetailResponseViewModel>> GetOrderDetailByOrderIdAsync(OrderDetailResponseViewModel _detail)
        {
            return await _orderDetailService.GetOrderDetailByOrderIdAsync(_detail);
        }
    }
}
