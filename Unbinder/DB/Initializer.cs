using Unbinder.Models;

namespace Unbinder.DB
{
    public static class Initializer
    {
        public static int Seed(IApplicationBuilder applicationBuilder)
        {
            UnbinderDbContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<UnbinderDbContext>();

            Console.WriteLine("Connection established, preparing to seed database...");

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(SeedData.InitialRecipes);
            }
            else
            {
                Console.WriteLine("Recipes already exist in the database");
            }

            if (!context.Ingredients.Any())
            {
                context.Ingredients.AddRange(SeedData.PadThaiIngredients);
            }
            else
            {
                Console.WriteLine("Ingredients already exist in the database");
            }

            int insertCount = context.SaveChanges();
            Console.WriteLine($"Seeded {insertCount} records");
            return insertCount;
        }
    }
}
