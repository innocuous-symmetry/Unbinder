namespace Unbinder.Models
{
    public record IngredientWithDetails
    {

        public Ingredient Ingredient { get; init; } = default!;
        public IngredientDetails Details { get; init; } = default!;
    }

    public record IngredientDetails
    {
        public double? Amount { get; init; }
        public string? Unit { get; init; }
    }
}
