using System;
using System.Collections.Generic;

#nullable disable

namespace Project2.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int KeyId { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? Date { get; set; }

        public virtual Key Key { get; set; }
        public virtual Order Order { get; set; }
    }
}
