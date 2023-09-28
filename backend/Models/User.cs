using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserDescription { get; set; }
        public int? UsersCategoryId { get; set; }
        public string UsersConfirm { get; set; }
        public string UserImg { get; set; }

        public virtual Category UsersCategory { get; set; }
    }
}
