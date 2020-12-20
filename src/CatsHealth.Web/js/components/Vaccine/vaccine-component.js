export default class VaccineComponent {
    constructor() { }

    createCard() {
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

        return card;
    }
}