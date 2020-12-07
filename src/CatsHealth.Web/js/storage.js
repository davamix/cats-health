const CURRENT_ANIMAL = "current-animal";

function setAnimal(data) {
    localStorage.removeItem(CURRENT_ANIMAL);

    localStorage.setItem(CURRENT_ANIMAL, JSON.stringify(data));
}

function getAnimal(){
    return JSON.parse(localStorage.getItem(CURRENT_ANIMAL));
}

export { setAnimal, getAnimal };