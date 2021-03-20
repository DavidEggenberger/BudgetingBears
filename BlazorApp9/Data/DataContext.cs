using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<SolutionDesired> Solutions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }
    }
}
