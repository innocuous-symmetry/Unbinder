using Microsoft.Extensions.Logging;
using Unbinder.Models;
using Unbinder.Repositories;

namespace Unbinder.DB
{
    public static class Initializer
    {
        private static readonly ILogger logger = new LoggerFactory().CreateLogger("DBInitializer");

        public static int Seed(IApplicationBuilder applicationBuilder)
        {
            int totalInsertCount = 0;

            using UnbinderDbContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<UnbinderDbContext>();

            logger.Log(LogLevel.Information, "Connection established, preparing to seed database...");

            // if records are not already seeded, do an initial insert into DB
            WriteIfNotInitialized(context.Recipes, SeedData.InitialRecipes, context.Recipes.AddRange);
            WriteIfNotInitialized(context.Ingredients, SeedData.InitialIngredients, context.Ingredients.AddRange);

            // save changes so we can references them for establishing relations
            int insertCount = context.SaveChanges();
            logger.Log(LogLevel.Information, $"Seeded {insertCount} records");
            totalInsertCount += insertCount;

            // establish relations if they do not already exist
            Recipe? padThai = context.Recipes.Where(r => r.Name == "Pad Thai").FirstOrDefault();
            Recipe? pancakes = context.Recipes.Where(r => r.Name == "Pancakes").FirstOrDefault();

            if (padThai != null)
            {
                logger.Log(LogLevel.Information, "Found Pad Thai recipe, checking relations...");
                AddRelations(context, SeedData.PadThaiIngredientsWithDetails, padThai.RecipeId);
            }

            if (pancakes != null)
            {
                logger.Log(LogLevel.Information, "Found Pancakes recipe, checking relations...");
                AddRelations(context, SeedData.PancakeIngredientsWithDetails, pancakes.RecipeId);
            }

            totalInsertCount += context.SaveChanges();
            return totalInsertCount;
        }

        private delegate void Callback<T>(IEnumerable<T> seedData);

        private static void WriteIfNotInitialized<T>(IEnumerable<T> existingItems, IEnumerable<T> seedData, Callback<T> addRange)
        {
            if (existingItems.Any()) {
                logger.Log(LogLevel.Information, "Record already exists in the database");
                return;
            }

            addRange(seedData);
        }

        private static void AddRelations(UnbinderDbContext context, IngredientWithDetails[] details, int recipeId)
        {
            var names = details.Select(d => d.Ingredient.Name);

            foreach (var ing in context.Ingredients)
            {
                if (names.Contains(ing.Name))
                {
                    logger.Log(LogLevel.Information, $"Writing entry for {ing.Name}");

                    var entryForThis = details.Where(d => d.Ingredient.Name == ing.Name).FirstOrDefault();

                    context.RecipeIngredients.Add(new RecipeIngredient
                    {
                        RecipeId = recipeId,
                        IngredientId = ing.IngredientId,
                        Amount = entryForThis?.Details.Amount,
                        Unit = entryForThis?.Details.Unit,
                    });
                }
            }

        }
    }
}
