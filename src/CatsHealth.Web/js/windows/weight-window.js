import { getRequestTo, postRequestTo } from "../requests.js";
import * as urls from "../urls.js";
import * as storage from "../storage.js";

// ELEMENTS

const saveButton = document.getElementById("weight-save-btn");
const closeButton = document.getElementById("weight-close-btn");
const weightWindow = document.getElementById("weight-window");

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

function openWeightWindow(data) {
    if (data) {
        // Load data in fields
    }

    weightWindow.style.display = "block";
}

function saveProfile() {

    const data = {
        profileId: storage.getAnimal().id,
        value: document.getElementById("animal-weight").value,
        registeredOn: document.getElementById("weight-date").value
    };

    console.log("Saving: ", data);

    postRequestTo(urls.URL_WEIGHTS, data)
        .then(data => {
            document.dispatchEvent(
                new CustomEvent("weight-saved", {
                    detail: {
                        weight: data
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
    weightWindow.style.display = "none";
}

function cleanData() {
    document.getElementById("animal-id").value = "";
    document.getElementById("animal-weight").value = "";
    document.getElementById("weight-date").value = "";
}

export { openWeightWindow };