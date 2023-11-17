namespace Unbinder.Models
{
    public record Recipe
    {
        public int RecipeId { get; init; }
        public string Name {get; init; } = default!;
        public string ShortDescription { get; init; } = default!;
        public string? Author { get; init; }

        public string? RecipeText { get; init; }

        public string? ImageUrl { get; init; }
    }
}
