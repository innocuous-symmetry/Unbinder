const path = require('path');
const fs = require('fs');

const jsRoot = path.resolve(__dirname, 'wwwroot/js');

if (fs.existsSync(jsRoot)) {
    fs.rmdirSync(jsRoot, { recursive: true });
}

module.exports = {
    entry: {
        searchRecipes: "./wwwroot/ts/searchRecipes.ts",
        createRecipe: "./wwwroot/ts/createRecipe.ts",
        "types/validators": "./wwwroot/ts/types/validators.ts",
        "types/models": "./wwwroot/ts/types/models.ts",
        types: "./wwwroot/ts/types/index.ts",
    },
    mode: 'production',
    optimization: {
        minimize: false,
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
        ]
    },
    resolve: {
        extensions: ['.ts', '.js'],
    },
    output: {
        filename: '[name].js',
        path: path.resolve(__dirname, 'wwwroot/js'),
    }
}