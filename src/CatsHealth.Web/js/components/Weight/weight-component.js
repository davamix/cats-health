import { getRequestTo } from "../../requests.js";
import * as urls from "../../urls.js";
import { openWeightWindow } from "./weight-window.js";

export default class WeightComponent {
    constructor() {
    }

    async createCard(profile_id) {
        const url = urls.URL_WEIGHTS_LAST.replace("{profile_id}", profile_id);

        return getRequestTo(url)
            .then(data => this.createElement(data));
    }

    // private methods are experimental on Firefox
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes/Private_class_fields
    // #createElement(data)

    createElement(data) {
        let formated_date = "No weights registered";
        let weight_value = "";

        if(data){
            formated_date = data.registeredOn.split("T")[0];
            weight_value = data.value;
        }

        const card = document.createElement("div");
        card.classList.add("dashboard-card");
        card.setAttribute("id", "card-weight");
        card.innerHTML = `
            <div class="title">
                <i class="fas fa-weight-hanging fa-2x"> <span class="weight">${weight_value}</span> kg</i>
            </div>
            <div>
                <p class="date">${formated_date}</p>
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