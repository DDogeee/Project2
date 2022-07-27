using System;
using System.Collections.Generic;

namespace Project2.ViewModel
{
   public class KeyResponseViewModel 
   {
      public int Id { get; set; }
      public string MachineId { get; set; }
      public int ToolId { get; set; }
      public string ToolKey { get; set; }
      public int Status { get; set; }
      public DateTime? CreatedDate { get; set; }
      public DateTime? StartDate { get; set; }
      public DateTime? ToDate { get; set; }
   }

}
   