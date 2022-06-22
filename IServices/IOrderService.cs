using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.ViewModel;

namespace Project2.IServices
{
    public interface IOrderService
    {
        Task<GenericResultModel<OrderResponseViewModel>> GetOrderAsync();
        Task<GenericResultModel<OrderResponseViewModel>> AddOrderAsync(OrderResponseViewModel _order);
        Task<GenericResultModel<OrderResponseViewModel>> EditOrderAsync(OrderResponseViewModel _order);
        Task<GenericResultModel<OrderResponseViewModel>> DeleteOrderAsync(OrderResponseViewModel _order);
        Task<GenericResultModel<OrderResponseViewModel>> GetOrderIdAsync(OrderResponseViewModel _order);



    }
}
