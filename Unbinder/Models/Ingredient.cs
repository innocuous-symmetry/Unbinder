namespace Unbinder.Models
{
    public record Ingredient
    {
        public int IngredientId { get; init; }
        public string Name { get; init; } = default!;
        public string? Description { get; init; }
    }
}
