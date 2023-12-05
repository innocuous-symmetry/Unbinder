export type Recipe = {
    recipeId: number,
    name: string,
    shortDescription: string,
    s3Url?: string,
    author?: string,
    recipeText?: string,
    mainImageUrl?: string,
}

export type Ingredient = {
    ingredientId: number,
    name: string,
    description?: string
}

export type RecipeIngredient = {
    recipeIngredientId: number,
    recipeId: number,
    ingredientId: number,
    amount?: number,
    unit?: string,
}

export type IngredientWithDetails = Ingredient & Pick<RecipeIngredient, 'amount' | 'unit'>