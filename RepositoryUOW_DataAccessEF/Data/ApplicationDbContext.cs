using Microsoft.EntityFrameworkCore;
using RepositoryUOW_Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryUOW_DataAccessEF.Data
{
    public class ApplicationDbContext:DbContext
    {
        // in N-Tier architecture we should add conectionString in web appsetting 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
