using Project2.Models;
using Project2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserResponseViewModel> WithoutPasswords(this IEnumerable<UserResponseViewModel> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static UserResponseViewModel WithoutPassword(this UserResponseViewModel user)
        {
            user.Password = null;
            return user;
        }
    }
}
