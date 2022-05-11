using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Cinema.Models
{
    public partial class User
    {
        public User()
        {
        }

        public int Id { get; set; }
        //public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string ProfilePicture { get; set; }
    }
}
