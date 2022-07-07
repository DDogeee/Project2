using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.ViewModel;

namespace Project2.IServices
{
    public interface IOrderDetailService
    {
        Task<GenericResultModel<OrderDetailResponseViewModel>> GetOrderDetailAsync();
        Task<GenericResultModel<OrderDetailResponseViewModel>> GetOrderDetailIdAsync(int id);
        Task<GenericResultModel<OrderDetailResponseViewModel>> GetOrderDetailByOrderIdAsync(int orderId);


    }
}
