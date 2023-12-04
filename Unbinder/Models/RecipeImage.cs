using System.ComponentModel.DataAnnotations.Schema;

namespace Unbinder.Models
{
    [Table("RecipeImages")]
    public record RecipeImage
    {
        public int RecipeImageId { get; init; }
        public int RecipeId { get; init; }
        public string? ImageUrl { get; init; }
        public string? ImageAlt { get; init; }
    }
}
