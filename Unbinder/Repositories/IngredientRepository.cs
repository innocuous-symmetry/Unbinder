using Unbinder.DB;
using Unbinder.Models;

namespace Unbinder.Repositories
{
    public class IngredientRepository(UnbinderDbContext _dbContext) : BaseRepository<Ingredient>(_dbContext), IIngredientRepository
    {
        public override IEnumerable<Ingredient>? GetAll => _dbContext.Ingredients;
        public override Ingredient? GetById(int id) => _dbContext.Ingredients.Where(i => i.IngredientId == id).First();

        public override Ingredient? UpdateById(int id)
        {
            Ingredient? ingredient = GetById(id);
            if (ingredient == null) return null;

            _dbContext.Ingredients.Update(ingredient);
            _dbContext.SaveChanges();
            return ingredient;
        }

        public override int DeleteById(int id)
        {
            Ingredient? ingredient = GetById(id);
            if (ingredient == null) return 0;

            _dbContext.Ingredients.Remove(ingredient);
            _dbContext.SaveChanges();
            return 1;
        }
    }
}
