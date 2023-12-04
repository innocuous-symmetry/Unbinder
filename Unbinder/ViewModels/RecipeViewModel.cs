using Unbinder.Models;

namespace Unbinder.ViewModels
{
    public class RecipeViewModel(Recipe _recipe, IEnumerable<IngredientWithDetails>? _ingredients)
    {
        public Recipe Recipe { get; init; } = _recipe;
        public IEnumerable<IngredientWithDetails>? Ingredients { get; init; } = _ingredients;
    }
}
