using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Models;

namespace RazorPageMovie.Data
{
    public class RazorPageMovieContextDb : DbContext
    {
        public RazorPageMovieContextDb (DbContextOptions<RazorPageMovieContextDb> options)
            : base(options)
        {
        }



        public DbSet<RazorPageMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
