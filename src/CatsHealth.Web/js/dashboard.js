import { getRequestTo, postRequestTo } from "./requests.js";
import { openProfileWindow } from "./windows/profile-window.js";
import * as storage from "./storage.js";
import * as urls from "./urls.js";
import WeightComponent from "./components/Weight/weight-component.js";
import VaccineComponent from "./components/Vaccine/vaccine-component.js";

const dashboard = document.getElementById("dashboard");
const profilePanel = document.getElementById("profile-panel");

const profileImageDefault = "https://via.placeholder.com/120x67.webp";

// EVENTS 

document.addEventListener("profile-saved", (e) => {
    loadProfiles();
    // insertProfile with e data in order to avoid a request in loadProfiles??
});

// TODO: Move this event inside the component
document.addEventListener("weight-saved", (data) => {
    const card = document.getElementById("card-weight");
    const date_field = card.querySelector(".date");
    const value_field = card.querySelector(".weight");

    const date = data.detail.weight.registeredOn;
    const formated_date = date.split("T")[0];

    date_field.innerHTML = formated_date;
    value_field.innerHTML = data.detail.weight.value;
});

// FUNCTIONS

function loadProfiles() {
    profilePanel.innerHTML = "";

    getRequestTo(urls.URL_PROFILES)
        .then(data => {
            if (data) {
                data.forEach(profile => {
                    addProfileTab(profile);
                });
            }
        })
        .then(() => addProfileNewTab());
}

function addProfileTab(profile) {
    const profileImage = (profile.image) ? profile.image : profileImageDefault;

    const profileEl = document.createElement("div");
    profileEl.classList.add("profile-tab");

    profileEl.innerHTML = `
        <img src="${profileImage}" class="profile-tab-picture" title="${profile.name}" />
    `

    profileEl.addEventListener("click", (e) => {
        e.preventDefault();

        storage.setAnimal(profile);
        location.reload();
    });

    profilePanel.appendChild(profileEl);
}

function addProfileNewTab() {
    const profileEl = document.createElement("div");
    profileEl.classList.add("profile-tab");

    profileEl.innerHTML = `
        <button class="profile-tab-add-btn" title="Add new profile">
            <i class="fas fa-paw fa-4x"></i>
        </button>
    `

    const addButton = profileEl.querySelector(".profile-tab-add-btn");

    addButton.addEventListener("click", (e) => {
        e.preventDefault();

        openProfileWindow();
    });

    profilePanel.appendChild(profileEl);
}

function loadDashboard() {
    const animal = storage.getAnimal();

    // TODO:
    // - Get data for cards based on animal Id. Weight, Vaccine...

    if (animal) {
        dashboard.innerHTML = `<h1 class="title">${animal.name}'s Dashboard</h1>`;

        loadCards();
    } else {
        openProfileWindow();
    }
}

async function loadCards() {
    const cards = document.createElement("div");
    cards.classList.add("cards");

    const animal = storage.getAnimal();

    await createWeightCard(animal, cards);
    await createVaccineeCard(cards);

    dashboard.appendChild(cards);
}

async function createWeightCard(animal, parent) {
    const component = new WeightComponent();

    component.createCard(animal.id)
        .then(card => parent.appendChild(card));
}

async function createVaccineeCard(parent) {
    const component = new VaccineComponent();
    const card = component.createCard();

    parent.appendChild(card);
}

loadProfiles();

loadDashboard();



