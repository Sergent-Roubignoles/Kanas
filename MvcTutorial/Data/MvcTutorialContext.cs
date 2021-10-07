using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTutorial.Models;

namespace MvcTutorial.Data
{
    public class MvcTutorialContext : DbContext
    {
        public MvcTutorialContext (DbContextOptions<MvcTutorialContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
