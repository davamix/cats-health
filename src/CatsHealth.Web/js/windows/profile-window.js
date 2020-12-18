import { getRequestTo, postRequestTo } from "../requests.js";
import * as urls from "../urls.js";

// ELEMENTS

const saveButton = document.getElementById("profile-save-btn");
const closeButton = document.getElementById("profile-close-btn");
const profileWindow = document.getElementById("profile-window");

// EVENTS 

saveButton.addEventListener("click", (e) => {
    e.preventDefault();
    saveProfile();
});

closeButton.addEventListener("click", (e) => {
    e.preventDefault();
    closeWindow();
    cleanData();
});

function openProfileWindow(data) {
    if (data) {
        setData(data);
    }

    profileWindow.style.display = "block";
}

function setData(data) {
    document.getElementById("animal-id").value = data.id;
    document.getElementById("animal-name").value = data.name;
    document.getElementById("animal-species").value = data.species;
    document.getElementById("animal-birthdate").value = data.birthdate;

    const form = document.forms.animal_sex;
    const sexOption = form.elements.animal_sex;

    sexOption.forEach(x => {
        if (x.value === data.sex.toLowerCase()) {
            x.checked = true;
        }
    });
}

function saveProfile() {
    const form = document.forms.animal_sex;
    const sexOption = form.elements.animal_sex;

    const profile = {
        id: document.getElementById("animal-id").value,
        name: document.getElementById("animal-name").value,
        species: document.getElementById("animal-species").value,
        birthdate: document.getElementById("animal-birthdate").value,
        sex: sexOption.value
    }

    postRequestTo(urls.URL_PROFILES, profile)
        .then(data => {
            document.dispatchEvent(
                new CustomEvent("profile-saved", {
                    detail: {
                        profile: data
                    }
                })
            );
        })
        .then(() => {
            closeWindow();
            cleanData()
        });
}

function closeWindow() {
    profileWindow.style.display = "none";
}

function cleanData() {
    document.getElementById("animal-id").value = "";
    document.getElementById("animal-name").value = "";
    document.getElementById("animal-species").value = "";
    document.getElementById("animal-birthdate").value = "";

    const form = document.forms.animal_sex;
    const sexOption = form.elements.animal_sex;

    sexOption.forEach(x => x.checked = false);
}

export { openProfileWindow };