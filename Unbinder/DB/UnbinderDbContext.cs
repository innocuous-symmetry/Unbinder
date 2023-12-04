using Microsoft.EntityFrameworkCore;
using Unbinder.Models;

namespace Unbinder.DB
{
    public class UnbinderDbContext : DbContext
    {
        public UnbinderDbContext(DbContextOptions<UnbinderDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
