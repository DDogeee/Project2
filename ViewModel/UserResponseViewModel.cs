using System;
using System.Collections.Generic;

namespace Project2.ViewModel
{
    public class UserResponseViewModel
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Status { get; set; }
    }
}
