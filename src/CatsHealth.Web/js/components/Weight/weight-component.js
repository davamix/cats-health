import { openWeightWindow } from "./weight-window.js";

export default class WeightComponent {
    constructor() {

    }

    createCard() {
        const card = document.createElement("div");
        card.classList.add("dashboard-card");
        card.setAttribute("id", "card-weight");
        card.innerHTML = `
            <div class="title">
                <i class="fas fa-weight-hanging fa-2x"> 6.6 kg</i>
            </div>
            <div>
                <p class="date">13/10/2020</p>
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

        addButton.addEventListener("click", (e) => {
            e.preventDefault();
            openWeightWindow();

        });

        return card;
    }
}