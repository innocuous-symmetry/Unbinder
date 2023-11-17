using Unbinder.Models;

namespace Unbinder.DB
{
    public static class SeedData
    {
        public static Recipe PadThaiRecipe
        {
            get => new()
            {
                Name = "Pad Thai",
                ShortDescription = "A popular noodle dish",
                Author = "Github Copilot",
                RecipeText = "1. Cook the noodles according to the package instructions.\n" +
                "2. In a small bowl, combine the tamarind paste, fish sauce, and brown sugar. Set aside.\n" +
                "3. Heat the oil in a large wok or skillet over medium-high heat. Add the garlic and stir-fry until fragrant, about 30 seconds. Add the shrimp and stir-fry until pink, about 2 minutes. Add the tofu and cook for 1 minute. Push everything to the side of the wok.\n" +
                "4. Crack the eggs into the wok and scramble until nearly set, about 1 minute. Add the noodles and pour the sauce over the top. Toss everything to combine.\n" +
                "5. Add the bean sprouts and green onions and toss to combine. Transfer to a serving platter and top with the cilantro and peanuts. Serve with lime wedges.",
            };
        }

        public static Recipe PancakeRecipe
        {
            get => new()
            {
                Name = "Pancakes",
                ShortDescription = "A delicious breakfast",
                Author = "Github Copilot",
                RecipeText = "1. In a large bowl, whisk together the flour, baking powder, salt, and sugar.\n" +
                "2. In a separate bowl, whisk together the milk, eggs, and melted butter.\n" +
                "3. Add the wet ingredients to the dry ingredients and whisk until just combined. Let the batter rest for 5 minutes.\n" +
                "4. Heat a large nonstick skillet or griddle over medium-low heat. Add a little butter to the pan and swirl to coat. Add ⅓ cup of the batter to the pan and cook until the edges are set and bubbles form on the surface, about 2 minutes. Flip and cook for 1 minute more. Repeat with the remaining batter.\n" +
                "5. Serve with butter and maple syrup.",
            };
        }

        public static Recipe[] InitialRecipes => new Recipe[] { PadThaiRecipe, PancakeRecipe };

        public static Ingredient[] PadThaiIngredients
        {
            get
            {
                return [
                    new Ingredient
                    {
                        Name = "Cilantro",
                        Description = "Aromatic herb with a citrusy flavor",
                    },
                    new Ingredient
                    {
                        Name = "Lime",
                        Description = "A citrus fruit with a sour taste",
                    },
                    new Ingredient
                    {
                        Name = "Peanuts",
                        Description = "A legume that grows underground",
                    },
                    new Ingredient
                    {
                        Name = "Rice Noodles",
                        Description = "Noodles made from rice flour",
                    },
                    new Ingredient
                    {
                        Name = "Eggs",
                        Description = "A breakfast staple",
                    },
                    new Ingredient
                    {
                        Name = "Tofu",
                        Description = "A soy-based meat substitute",
                    },
                ];
            }
        }
        public static Ingredient[] PancakeIngredients
        {
            get
            {
                return [
                    new Ingredient
                    {
                        Name = "All purpose flour",
                        Description = "A versatile flour",
                    },
                    new Ingredient
                    {
                        Name = "Baking powder",
                        Description = "A leavening agent",
                    },
                    new Ingredient
                    {
                        Name = "Salt",
                        Description = "A mineral",
                    },
                    new Ingredient
                    {
                        Name = "Granulated sugar",
                        Description = "A sweetener",
                    }
                ];
            }
        }

        public static Ingredient[] InitialIngredients => PadThaiIngredients.Concat(PancakeIngredients).ToArray();
    }
}
