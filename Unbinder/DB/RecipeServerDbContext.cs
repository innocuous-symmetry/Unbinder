using Microsoft.EntityFrameworkCore;
using Unbinder.Models;

namespace Unbinder.DB
{
    public class RecipeServerDbContext : DbContext
    {
        public RecipeServerDbContext(DbContextOptions<RecipeServerDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
