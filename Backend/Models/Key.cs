using System;
using System.Collections.Generic;

#nullable disable

namespace Project2.Models
{
    public partial class Key
    {
        public Key()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string MachineId { get; set; }
        public int ToolId { get; set; }
        public string ToolKey { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ToDate { get; set; }

        public virtual Tool Tool { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
