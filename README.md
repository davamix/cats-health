# Cats Health (WIP)

## Requirements

[.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) and [MongoDB docker](https://hub.docker.com/_/mongo)

## Run with Docker

1. Generate a certificate. From `src/CatsHealth.API` folder execute:

    ```
    dotnet dev-certs https -v -ep ./cert-aspnetcore.pfx -p 1234
    ```

2. From the main folder: 

    ```
    docker-compose build
    docker-compose up
    ```

## Run manually

1. Download and run MongoDB:

    ```
    docker run -p 27017:27017 mongo:4.4.2
    ```

2. From `src` folder: `dotnet run -p CatsHealth.API`

3. Navigate to `index.html`

---

## TODO

A lot of things 😛

The big picture:

- [ ] Managing animal's profile.
- [ ] Health area
    - [ ] Vacciness
        - Latest
        - Next + Reminder
    - [ ] Control Weight
    - [ ] Analysis
        - Upload documents (pdf's, images...)
        - Search in documents
        - Charts based on data history
- [ ] Calendar
    - Reminders
