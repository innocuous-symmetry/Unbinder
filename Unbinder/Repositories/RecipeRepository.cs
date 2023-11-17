using Unbinder.DB;
using Unbinder.Models;

namespace Unbinder.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly UnbinderDbContext _dbContext;

        public RecipeRepository(UnbinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Recipe> GetAll
        {
            get
            {
                return _dbContext.Recipes;
            }
        }
        

        public Recipe? GetById(int id)
        {
            return _dbContext.Recipes.Where(r => r.RecipeId == id).First();
            throw new NotImplementedException();
        }

        public Recipe? UpdateById(int id)
        {
            Recipe? recipe = GetById(id);
            if (recipe == null)
            {
                return null;
            }
            else
            {
                _dbContext.Recipes.Update(recipe);
                _dbContext.SaveChanges();
                return recipe;
            }
        }

        public int DeleteById(int id)
        {
            Recipe? recipe = GetById(id);
            if (recipe == null)
            {
                return 0;
            }

            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
            return 1;
        }
    }
}
