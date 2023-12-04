using Unbinder.DB;
using Unbinder.Models;

namespace Unbinder.Repositories
{
    public class RecipeIngredientRepository(UnbinderDbContext context) : BaseRepository<RecipeIngredient>(context), IRecipeIngredientRepository
    {
        // inapplicable methods intentionally left blank
        public override IEnumerable<RecipeIngredient>? GetAll => null;
        public override RecipeIngredient? UpdateById(int id) => null;

        // implemented methods:
        public override RecipeIngredient? GetById(int id) => _dbContext.RecipeIngredients.Where(ri => ri.RecipeIngredientId == id).FirstOrDefault();

        public override RecipeIngredient Post(RecipeIngredient entity)
        {
            _dbContext.RecipeIngredients.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public override int DeleteById(int id)
        {
            var recipeIngredient = GetById(id);
            if (recipeIngredient == null) return 0;
            _dbContext.RecipeIngredients.Remove(recipeIngredient);
            _dbContext.SaveChanges();
            return 1;
        }
    }
}
