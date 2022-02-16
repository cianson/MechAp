using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MechAp
{
    public class User
    {
        [MaxLength(15)]
        public string FirstName { get; set; }

        [MaxLength(15)]
        public string LastName { get; set; }

        [PrimaryKey, MaxLength(15)]
        public string Username { get; set; }

        [MaxLength(14)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
    }
}