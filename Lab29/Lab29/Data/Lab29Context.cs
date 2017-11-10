using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab29.Models
{
    public class Lab29Context : DbContext
    {
        public Lab29Context (DbContextOptions<Lab29Context> options)
            : base(options)
        {
        }

        public DbSet<Lab29.Models.VideoGames> VideoGames { get; set; }
    }
}
