using System;
using System.Collections.Generic;

namespace Project2.ViewModel
{
    public class OrderDetailResponseViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? KeyId { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? Date { get; set; }
    }
}