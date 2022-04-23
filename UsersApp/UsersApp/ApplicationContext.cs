using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace UsersApp
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users{ get; set; }

        public ApplicationContext() : base("DefaultConnection") { }
    }
}
