using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Category
    {
        public Category()
        {
            Users = new HashSet<User>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
