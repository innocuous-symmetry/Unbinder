using Unbinder.Models;

namespace Unbinder.ViewModels
{
	public class RecipeListViewModel
	{
		public IEnumerable<Recipe> Recipes { get; }

		public RecipeListViewModel(IEnumerable<Recipe> recipes)
		{
			Recipes = recipes;
		}
	}
}