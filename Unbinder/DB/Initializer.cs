using Unbinder.Models;
using Unbinder.Repositories;

namespace Unbinder.DB
{
    public static class Initializer
    {
        public static int Seed(IApplicationBuilder applicationBuilder)
        {
            int totalInsertCount = 0;

            using UnbinderDbContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<UnbinderDbContext>();

            Console.WriteLine("Connection established, preparing to seed database...");

            // if records are not already seeded, do an initial insert into DB
            WriteIfNotInitialized(context.Recipes, SeedData.InitialRecipes, context.Recipes.AddRange);
            WriteIfNotInitialized(context.Ingredients, SeedData.InitialIngredients, context.Ingredients.AddRange);

            // save changes so we can references them for establishing relations
            int insertCount = context.SaveChanges();
            Console.WriteLine($"Seeded {insertCount} records");
            totalInsertCount += insertCount;

            // establish relations if they do not already exist
            Recipe? padThai = context.Recipes.Where(r => r.Name == "Pad Thai").FirstOrDefault();
            Recipe? pancakes = context.Recipes.Where(r => r.Name == "Pancakes").FirstOrDefault();

            if (padThai != null)
            {
                Console.WriteLine("Found Pad Thai recipe, checking relations...");
                var padThaiIngredientNames = SeedData.PadThaiIngredients.Select(i => i.Name);
                AddRelations(context, padThaiIngredientNames, padThai.RecipeId);
            }

            if (pancakes != null)
            {
                Console.WriteLine("Found Pancakes recipe, checking relations...");
                var pancakeIngredientNames = SeedData.PancakeIngredients.Select(i => i.Name);
                AddRelations(context, pancakeIngredientNames, pancakes.RecipeId);
            }

            totalInsertCount += context.SaveChanges();
            return totalInsertCount;
        }

        private delegate void Callback<T>(IEnumerable<T> seedData);

        private static void WriteIfNotInitialized<T>(IEnumerable<T> existingItems, IEnumerable<T> seedData, Callback<T> addRange)
        {
            if (existingItems.Any()) {
                Console.WriteLine("Record already exists in the database");
                return;
            }

            addRange(seedData);
        }

        private static void AddRelations(UnbinderDbContext context, IEnumerable<string> names, int id)
        {
            foreach (var ing in context.Ingredients)
            {
                if (names.Contains(ing.Name))
                {
                    context.RecipeIngredients.Add(new RecipeIngredient
                    {
                        RecipeId = id,
                        IngredientId = ing.IngredientId,
                    });
                }
            }

        }
    }
}
