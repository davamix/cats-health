class BaseComponent {
    constructor() { }

    createCard() {
        // const card_id = "card-" + name;
        const card = document.createElement("div");
        card.classList.add("dashboard-card");
        // card.setAttribute("id", card_id);
        card.innerHTML = `
            <div class="title">
                Title
            </div>
            <div>
                <p>Body</p>
            </div>
        `

        return card;
    }

    opentDialog(){
        
    }
}