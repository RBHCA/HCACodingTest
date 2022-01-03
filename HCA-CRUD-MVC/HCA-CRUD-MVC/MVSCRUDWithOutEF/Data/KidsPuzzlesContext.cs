using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KidsPuzzles.Models;

namespace KidsPuzzles.Data
{
    public class KidsPuzzlesContext : DbContext
    {
        public KidsPuzzlesContext (DbContextOptions<KidsPuzzlesContext> options)
            : base(options)
        {
        }

        public DbSet<KidsPuzzles.Models.KidsPuzzleViewModel> KidsPuzzleViewModel { get; set; }
    }
}
