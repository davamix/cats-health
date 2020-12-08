import { getRequestTo, postRequestTo } from "./requests.js";
import * as storage from "./storage.js";
import * as urls from "./urls.js";

const dashboard = document.getElementById("dashboard");
const profilePanel = document.getElementById("profile-panel");

const profileImageDefault = "https://via.placeholder.com/120x67.webp";

const animal = storage.getAnimal();

dashboard.innerHTML = `<h1>${animal.name}'s Dashboard`;

function loadProfiles(){
    profilePanel.innerHTML = "";

    getRequestTo(urls.URL_PROFILES)
        .then(data => {
            data.forEach(profile =>{
                addProfileTab(profile);
            });
        })
        .then(() => addProfileNewTab());
}

function addProfileTab(profile){
    const profileImage = (profile.image) ? profile.image : profileImageDefault;

    const profileEl = document.createElement("div");
    profileEl.classList.add("profile-tab");

    profileEl.innerHTML = `
        <img src="${profileImage}" class="profile-tab-picture" title="${profile.name}" />
    `

    profileEl.addEventListener("click", (e) =>{
        e.preventDefault();

        storage.setAnimal(profile);
        location.reload();
    })

    profilePanel.appendChild(profileEl);
}

function addProfileNewTab(){
    const profileEl = document.createElement("div");
    profileEl.classList.add("profile-tab");

    profileEl.innerHTML = `
        <button class="profile-tab-add-btn" title="Add new profile">
            <i class="fas fa-paw fa-4x"></i>
        </button>
    `

    const addButton = profileEl.querySelector(".profile-tab-add-btn");

    addButton.addEventListener("click", (e) =>{
        e.preventDefault();

        console.log("Add new profile");
    })
    profilePanel.appendChild(profileEl);
}

loadProfiles();


