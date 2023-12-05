import { isRecipeArray, type Recipe } from "./types";

function setSearchResultMessage(model: Recipe[]): void {
    const message = document.getElementById("query-message");
    message.innerHTML = `Viewing ${model.length} results for: ${window.location.search.split("=")[1]}`;
}

async function handleSearch(textField?: HTMLInputElement) {
    if (!textField) {
        console.log("NO TEXT FIELD!");
        return;
    }

    const newResult = await fetch(`/api/recipe/search?q=${textField.value}`);
    const newResultJson = await newResult.json();
    const searchResultsContainer = document.getElementById("search-results");

    if (isRecipeArray(newResultJson)) {
        let updatedHTML = "";
        for (const recipe of newResultJson) {
            updatedHTML += `
                <p>${recipe.Name}</p>
                <p>${recipe.ShortDescription}</p>
            `;
        }

        console.log(updatedHTML);

        setSearchResultMessage(newResultJson);
        searchResultsContainer.innerHTML = updatedHTML;
    }
}

document.addEventListener('DOMContentLoaded', () => {
    console.log("Loaded DOM");

    // dom elements
    const searchButton = document.getElementById("execute-search");

    const inputNodes = document.querySelectorAll("input");
    let textField: HTMLInputElement | null = null;

    inputNodes.forEach(node => {
        if (node.id == "new-search-query") {
            textField = node;
            console.log("Found text field");
        }
    });

    // handle search updates on client side
    searchButton.onclick = async () => handleSearch(textField);
});