import { getRequestTo, postRequestTo } from "./requests.js";

const URL_PROFILES = "https://localhost:5001/api/Profile";

// Test GET
getRequestTo(URL_PROFILES).then(data => console.log("GET: ", data));


// Test POST
const profile = {
    name: "P1"
};

postRequestTo(URL_PROFILES, profile).then(data => console.log("POST: ", data));
