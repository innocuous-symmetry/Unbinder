using Unbinder.DB;
using Unbinder.Models;

namespace Unbinder.Repositories
{
    public class RecipeIngredientRepository(UnbinderDbContext context) : BaseRepository<RecipeIngredient>(context), IRecipeIngredientRepository
    {
        // inapplicable methods intentionally left blank
        public override IEnumerable<RecipeIngredient>? GetAll => null;
        public override RecipeIngredient? UpdateById(int id) => null;

        // overridden methods:
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

        // custom methods
        public IEnumerable<IngredientWithDetails>? GetIngredientsByRecipeId(int recipeId)
        {
            // get all ingredients associated with this recipe
            var ingredientDetails = _dbContext.RecipeIngredients
                .Where(ri => ri.RecipeId == recipeId)
                .ToArray();

            if (ingredientDetails == null) return null;

            // get the full DB listing for each ingredient
            var ingredientsForRecipe = _dbContext.Ingredients
                .Where(i => ingredientDetails.Select(d => d.IngredientId).Contains(i.IngredientId))
                .ToArray();

            if (ingredientsForRecipe == null) return null;

            // combine the two into a merged output
            return MergeIngredientsWithDetails(ingredientsForRecipe, ingredientDetails);
            
        }

        private static List<IngredientWithDetails> MergeIngredientsWithDetails(
            Ingredient[] ingredients, RecipeIngredient[] details)
        {
            List<IngredientWithDetails> output = [];

            foreach (var ing in ingredients)
            {
                RecipeIngredient? CurrentDetails = details.Where(ri => 
                    ri.IngredientId == ing.IngredientId).FirstOrDefault();

                output.Add(new IngredientWithDetails
                {
                    Ingredient = ing,
                    Details = new IngredientDetails
                    {
                        Amount = CurrentDetails?.Amount,
                        Unit = CurrentDetails?.Unit,
                    }
                });
            }

            return output;
        }
    }
}
