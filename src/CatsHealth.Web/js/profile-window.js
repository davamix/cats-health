// ELEMENTS

const saveButton = document.getElementById("save");
const closeButton = document.getElementById("close");
const profileWindow = document.getElementById("profile-window");

// EVENTS 

saveButton.addEventListener("click", (e) =>{
    e.preventDefault();
    console.log("Save profile");
});

closeButton.addEventListener("click", (e) =>{
    e.preventDefault();
    profileWindow.style.display = "none";
    
});

function openProfileWindow(){
    profileWindow.style.display = "block";
}

export { openProfileWindow };