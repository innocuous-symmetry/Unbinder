using Unbinder.Models;

namespace Unbinder.Repositories
{
    public interface IRecipeIngredientRepository : IBaseRepository<RecipeIngredient>
    {
        public IEnumerable<IngredientWithDetails>? GetIngredientsByRecipeId(int recipeId);
    }
}
