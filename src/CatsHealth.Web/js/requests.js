async function getRequestTo(url) {
    return await fetch(url).then(response => response.json());
}

async function postRequestTo(url, data) {
    return await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
    .then(response => response.json());
}

export { getRequestTo, postRequestTo };