using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MechAp
{
    public class CurrentUser
    {
        [PrimaryKey]
        public int Number { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
    }
}
