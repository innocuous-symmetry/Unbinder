export type Recipe = {
    RecipeId: number,
    Name: string,
    ShortDescription: string,
    S3Url?: string,
    Author?: string,
    RecipeText?: string,
    MainImageUrl?: string,
}

export type Ingredient = {
    IngredientId: number,
    Name: string,
    Description?: string
}

export type RecipeIngredient = {
    RecipeIngredientId: number,
    RecipeId: number,
    IngredientId: number,
    Amount?: number,
    Unit?: string,
}

export type IngredientWithDetails = Ingredient & Pick<RecipeIngredient, 'Amount' | 'Unit'>