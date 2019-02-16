Steps involved in creating the project:

- creating of an external translator service using java and with heroku hosting

- creating .net core backend and Sql Server DB. Backend consist of two repositories for two db tables
- and a service that calls the extrenal REST API via HttpClient and a single controller

- if words exist in the database controller will fetch them and pass them the frontend, otherwise external
- service will be called and the word saved in the database

- for every succesfull translation a record will be added in the translationreport table as xml

- frontend is created with Angular 5 and relies heavily on ReactiveX to communite with the backend,
- it consist of two components and a shared service

- app is hosted on AppHarbor

- as this just a toy app only four words will get actually translated: air, water, earth, fire into arabic

To run the app locally:

- you must have .net core 2.1.500 installed, visual studio 2017, and nodejs 6 or higher and sql server        express edition.

- open the app solution with visual studio and build it to install nuget packages and node modules

- open package manager console and run 'update-database' commands to apply the migrations

- run the app with iis express or kestrel

