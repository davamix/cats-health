import { getRequestTo, postRequestTo } from "./requests.js";
import * as urls from "./urls.js";

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

function openWeightWindow(data){
    if(data){

    }

    weightWindow.style.display = "block";
}

function saveProfile(){
    console.log("Save");
}

function closeWindow(){
    console.log("Close");
    weightWindow.style.display = "none";
}

function cleanData(){

}

export { openWeightWindow };