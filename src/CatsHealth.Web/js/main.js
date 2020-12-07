import { getRequestTo, postRequestTo } from "./requests.js";
import * as storage from "./storage.js";

const URL_PROFILES = "https://localhost:5001/api/Profile";

const cardsContainer = document.getElementById("profile-cards-container");
const coverImage = "https://via.placeholder.com/400x225.webp?text=Profile+Picture";

function loadProfiles(){
    getRequestTo(URL_PROFILES)
        .then(data => {
            cardsContainer.innerHTML = "";
            
            data.forEach(profile =>{
                addProfileCard(profile);
            });

            addProfileNewButton();
        });
}

function addProfileCard(profile){
    const profileEl = document.createElement("div");
    const profileImage = (profile.image) ? profile.image : coverImage;

    profileEl.classList.add("profile-card");

    profileEl.innerHTML = `
        <img src="${profileImage}" class="profile-card-picture" title="${profile.name}" />
        
        <div class="profile-card-name">
            <h3>${profile.name}</h3>
        </div>
    `

    profileEl.addEventListener("click", (e) =>{
        e.preventDefault();
        
        storage.setAnimal(profile);
        location.assign("dashboard.html");
    });

    cardsContainer.appendChild(profileEl);
}

function addProfileNewButton(){
    const profileEl = document.createElement("div");
    profileEl.classList.add("profile-card-add");

    profileEl.innerHTML = `
        <button class="profile-add-btn" title="Add new profile">
            <i class="fas fa-paw fa-10x"></i>
        </button>
    `

    profileEl.addEventListener("click", ()=>{
        console.log("Add new profile");
    });

    cardsContainer.appendChild(profileEl);
}


// Test POST
// const profile = {
//     name: "P1"
// };

// postRequestTo(URL_PROFILES, profile).then(data => console.log("POST: ", data));

loadProfiles();