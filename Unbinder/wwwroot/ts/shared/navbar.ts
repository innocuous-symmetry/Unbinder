import { createButton } from "../stories/ui/button/Button";

document.addEventListener("DOMContentLoaded", () => {
    const navbar = document.getElementById("navbar-right-button-group");

    const viewAll = createButton({
        label: "View All Recipes",
        "asp-controller": "Recipe",
        "asp-action": "Index",
    });

    const addNew = createButton({
        label: "Add New Recipe",
        "asp-controller": "Recipe",
        "asp-action": "Create",
    });

    const search = createButton({
        label: "Search My Recipes",
        "asp-controller": "Recipe",
        "asp-action": "Search",
    });

    // check if navbar already contains these elements
    if (navbar.children.length > 0) {
        console.log("Skipping client-side navbar injection");
        return;
    }

    for (const item of [viewAll, addNew, search]) {
        navbar.appendChild(item);
    }
})