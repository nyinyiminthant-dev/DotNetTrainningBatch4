using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetTrainingBatch4.ConsoleApp
{
    internal class AppDbContex : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.connectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogDot> Blogs { get; set; }
    }
}
