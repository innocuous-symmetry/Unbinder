import type { Ingredient, Recipe } from "./models";

export function isRecipe(input: unknown): input is Recipe {
    return (
        typeof input == 'object'
        && input != null
        && 'RecipeId' in input
        && 'Name' in input
        && 'ShortDescription' in input
        && (input as Recipe).RecipeId != undefined
        && (input as Recipe).Name != undefined
        && (input as Recipe).ShortDescription != undefined
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
        && 'IngredientId' in input
        && 'Name' in input
        && (input as Ingredient).IngredientId != undefined
        && (input as Ingredient).Name != undefined
    );
}

export function isIngredientArray(input: unknown): input is Ingredient[] {
    return isArrayOfType(input, isIngredient);
}