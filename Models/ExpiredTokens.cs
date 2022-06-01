using System;
using System.Collections.Generic;

#nullable disable

namespace Project2.Models
{
    public partial class ExpiredTokens
    {
        public int Id { get; set; }
        public string ExpiredToken { get; set; }
    }
}
