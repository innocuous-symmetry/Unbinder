async function getAllIngredients () {
  const ingredients = await fetch('/api/ingredients');
  return await ingredients.json();
}

document.addEventListener('DOMContentLoaded', async () => {
  const ingredients = await getAllIngredients();
  console.log({ ingredients });

  const dropdown = document.getElementById('ingredient-selector');

  ingredients.forEach(ingredient => {
    const option = document.createElement('option');
    option.value = ingredient.id;
    option.innerText = ingredient.name;
    dropdown.appendChild(option);
  });
});
