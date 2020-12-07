import * as storage from "./storage.js";

const dashboard = document.getElementById("dashboard");

const animal = storage.getAnimal();

dashboard.innerHTML = `<h1>${animal.name}'s Dashboard`;

// TODO:
// Get the available profiles and set them up into the profile panel (left)