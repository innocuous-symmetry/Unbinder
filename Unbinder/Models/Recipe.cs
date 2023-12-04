using System.ComponentModel.DataAnnotations.Schema;

namespace Unbinder.Models
{
    [Table("Recipes")]
    public record Recipe
    {
        // required properties
        public int RecipeId { get; init; }
        public string Name {get; init; } = default!;
        public string ShortDescription { get; init; } = default!;

        // optional properties
        public string? S3Url { get; init; }
        public string? Author { get; init; }
        public string? RecipeText { get; init; }
        public string? MainImageUrl { get; init; }
    }
}
