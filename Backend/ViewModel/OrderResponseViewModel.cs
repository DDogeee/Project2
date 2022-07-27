using System;
using System.Collections.Generic;

namespace Project2.ViewModel
{
    public class OrderResponseViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int? Status { get; set; }
    }
}