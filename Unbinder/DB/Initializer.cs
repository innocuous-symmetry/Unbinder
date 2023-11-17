using Unbinder.Models;

namespace Unbinder.DB
{
    public static class Initializer
    {
        public static int Seed(IApplicationBuilder applicationBuilder)
        {
            UnbinderDbContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<UnbinderDbContext>();

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(SeedData.InitialRecipes);
            }

            if (!context.Ingredients.Any())
            {
                context.Ingredients.AddRange(SeedData.PadThaiIngredients);
            }

            int insertCount = context.SaveChanges();
            Console.WriteLine($"Seeded {insertCount} records");
            return insertCount;
        }
    }
}
