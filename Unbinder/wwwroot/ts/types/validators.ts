import type { Ingredient, Recipe } from "./models";

export function isRecipe(input: unknown): input is Recipe {
    return (
        typeof input == 'object'
        && input != null
        && 'recipeId' in input
        && 'name' in input
        && 'shortDescription' in input
        && (input as Recipe).recipeId != undefined
        && (input as Recipe).name != undefined
        && (input as Recipe).shortDescription != undefined
    );
}

export function isArrayOfType<T>(input: unknown, isType: (input: unknown) => input is T): input is T[] {
    return Array.isArray(input) && input.every(isType);
}

export function isRecipeArray(input: unknown): input is Recipe[] {
    return isArrayOfType(input, isRecipe);
}

export function isIngredient(input: unknown): input is Ingredient {
    return (
        typeof input == 'object'
        && input != null
        && 'ingredientId' in input
        && 'name' in input
        && (input as Ingredient).ingredientId != undefined
        && (input as Ingredient).name != undefined
    );
}

export function isIngredientArray(input: unknown): input is Ingredient[] {
    return isArrayOfType(input, isIngredient);
}