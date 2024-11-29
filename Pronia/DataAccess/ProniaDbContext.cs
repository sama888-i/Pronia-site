using Microsoft.EntityFrameworkCore;
using Pronia.Models;

namespace Pronia.DataAccess
{
    public class ProniaDbContext:DbContext 
    {
        public DbSet <Slider> Sliders { get; set; }
        public ProniaDbContext(DbContextOptions opt) : base(opt) { }

    }
}
