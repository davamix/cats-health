import { getRequestTo, postRequestTo } from "./requests.js";
import { openProfileWindow } from "./profile-window.js";
import { openWeightWindow } from "./weight-window.js";
import * as storage from "./storage.js";
import * as urls from "./urls.js";

const dashboard = document.getElementById("dashboard");
const profilePanel = document.getElementById("profile-panel");

const profileImageDefault = "https://via.placeholder.com/120x67.webp";

// EVENTS 

document.addEventListener("profile-saved", (e) => {
    loadProfiles();
    // insertProfile with e data in order to avoid a request in loadProfiles??
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

    if (animal) {
        dashboard.innerHTML = `<h1 class="title">${animal.name}'s Dashboard</h1>`;

        loadCards();
    } else {
        openProfileWindow();
    }
}

async function loadCards(){
    const cards = document.createElement("div");
    cards.classList.add("cards");

    createWeightCard(cards);
    createVaccineeCard(cards);

    dashboard.appendChild(cards);
}

function createWeightCard(parent){
    const card = document.createElement("div");
    card.classList.add("dashboard-card");
    card.innerHTML = `
        <div class="title">
            <i class="fas fa-weight-hanging fa-2x"> 6.3 kg</i>
        </div>
        <div>
            <p>13/10/2020</p>
        </div>
        <div class="bottom-panel">
            <div class="toolbar">
                <button class="add-btn" id="add-weight" title="Add new weight">
                    <i class="fas fa-plus"></i>
                </button>
            </div>
        </div>
    `

    const addButton = card.querySelector(".add-btn");
    
    addButton.addEventListener("click", (e)=>{
        e.preventDefault();
        openWeightWindow();

    });

    parent.appendChild(card);
}

function createVaccineeCard(parent){
    const card = document.createElement("div");
    card.classList.add("dashboard-card");
    card.innerHTML = `
        <div class="title">
            <i class="fas fa-syringe fa-2x"> Vaccine</i>
        </div>
        <div>
            <p>Next: 13/10/2020</p>
        </div>        
    `

    parent.appendChild(card);
}

loadProfiles();

loadDashboard();



