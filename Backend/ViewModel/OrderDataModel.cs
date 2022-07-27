using System;
using System.Collections.Generic;

namespace Project2.ViewModel
{
    public class OrderDataModel
    {
        public string Username { get; set; }
        public List<ToolOrderDataModel> Tools { get; set; }
    }
}
