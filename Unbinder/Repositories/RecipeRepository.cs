using Unbinder.DB;
using Unbinder.Models;

namespace Unbinder.Repositories
{
    public class RecipeRepository(UnbinderDbContext dbContext) : BaseRepository<Recipe>(dbContext), IRecipeRepository
    {

        public override IEnumerable<Recipe>? GetAll => _dbContext.Recipes;
        

        public override Recipe? GetById(int id) => _dbContext.Recipes.Where(r => r.RecipeId == id).First();

        public override Recipe? UpdateById(int id)
        {
            Recipe? recipe = GetById(id);
            if (recipe == null) return null;

            _dbContext.Recipes.Update(recipe);
            _dbContext.SaveChanges();
            return recipe;
        }

        public override int DeleteById(int id)
        {
            Recipe? recipe = GetById(id);
            if (recipe == null) return 0;

            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
            return 1;
        }
    }
}
