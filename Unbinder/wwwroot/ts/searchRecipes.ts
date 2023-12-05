import { isRecipeArray } from "./types/validators";
import type { Recipe } from "./types/models";

document.addEventListener('DOMContentLoaded', () => {
    console.log("Loaded searchRecipes.ts");

    // dom elements
    const searchButton = document.getElementById("execute-search");
    const message = document.getElementById("query-message");
    let textField: HTMLInputElement | null = null;
    const inputNodes = document.querySelectorAll("input");

    // functions
    function setSearchResultMessage(model: Recipe[], query?: string): void {
        message.innerHTML = `Viewing ${model.length} results for: ${query ?? window.location.search.split("=")[1]}`;
    }

    function checkForTextField() {
        inputNodes.forEach(node => {
            if (node.id == "new-search-query") {
                console.log('found text field');
                textField = node;
            }
        })
    }

    async function handleSearch() {
        console.log("__SEARCH HANDLER__");

        if (!textField) {
            checkForTextField();
            if (!textField) {
                console.log("text field was not found :(");
                return;
            }
        }

        console.log("found text field, searching...");

        const newResult = await fetch(`/api/recipe/search?q=${textField.value}`);
        console.log({ newResult });

        const newResultJson = await newResult.json();
        console.log({ newResultJson });

        const searchResultsContainer = document.getElementById("search-results");

        const isRecipeArr = isRecipeArray(newResultJson);
        console.log({ isRecipeArr });

        if (isRecipeArr) {
            let updatedHTML = "";
            for (const recipe of newResultJson) {
                updatedHTML += `
                <p>${recipe.name}</p>
                <p>${recipe.shortDescription}</p>
            `;
            }

            console.log({ updatedHTML });

            setSearchResultMessage(newResultJson, textField.value);
            searchResultsContainer.innerHTML = updatedHTML;
        }
    }

    // perform actions and attach event listeners
    checkForTextField();
    searchButton.onclick = async () => handleSearch();
});