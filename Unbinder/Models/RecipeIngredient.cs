using System.ComponentModel.DataAnnotations.Schema;

namespace Unbinder.Models
{
    [Table("RecipeIngredients")]
    public record RecipeIngredient
    {
        public int RecipeIngredientId { get; init; }
        public int RecipeId { get; init; }
        public int IngredientId { get; init; }
        public string? Amount { get; init; }
        public string? Unit { get; init; }
    }
}
