using System;
using System.Collections.Generic;

namespace Project2.ViewModel
{
    public class OrderResponseViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OrderDate { get; set; }           //type string, then convert to datetime
        public decimal TotalPrice { get; set; }
        public int? Status { get; set; }
    }
}