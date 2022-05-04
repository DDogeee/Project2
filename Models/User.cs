using System;
using System.Collections.Generic;

#nullable disable

namespace Project2.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsModified { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
