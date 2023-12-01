using System.ComponentModel.DataAnnotations.Schema;

namespace Unbinder.Models
{
    [Table("Ingredients")]
    public record Ingredient
    {
        public int IngredientId { get; init; }
        public string Name { get; init; } = default!;
        public string? Description { get; init; }
    }
}
