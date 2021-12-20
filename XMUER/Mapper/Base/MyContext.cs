using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XMUER.Models.Home;

namespace XMUER.Mapper.Base
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options){}

        public DbSet<Avatar> Avatars { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
