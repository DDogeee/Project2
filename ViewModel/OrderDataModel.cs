using System;
using System.Collections.Generic;

namespace Project2.ViewModel
{
    public class OrderDataModel
    {
        public int UserId { get; set; }
        public List<ToolOrderDataModel> Tools { get; set; }
    }
}
