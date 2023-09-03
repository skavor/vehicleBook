
# Vehicle Booking

Il s'agit d'une application pour vendre des voitures 


## Documentation

Le projet est en architecture microservice et basé sur:
- .Net core 6 WEB API

- Entity Framework Core 

- SQL Server pour la base de données

- Architecture CQRS (Command Query Responsibility Segregation) basé sur le design pattern Mediator

- Xunit pour le test unitaire

- SpecFlow pour BDD
- Redis Cache pour Caching

La solution contient 5 dossiers:

- VehicleBooking.Customer.API => pour le service Customer
- VehicleBooking.Vehicle.API => pour le service Vehicle
- VehicleBooking.ApiGateway => pour la partie API ApiGateway
- VehicleBooking.Specs => pour la partie BDD
- VehicleBooking.Tests => pour le test unitaire


## Installation

Cloner le projet à partir de repo

```bash
  git clone https://github.com/skavor/vehicleBook.git
  cd vehicleBook
```
Dans visual studio, Ouvrir Package Manager Console et lancer les commandes suivantes pour chaque projet VehicleBook.Vehicle.API et VehicleBook.Customer.API : 

```bash
add-migration YourCustomEntityChanges
update-database
```
Cliquez droit sur la solution  Propritiés => sélectionnez l'option Plusieurs projets de démarrage => Choisissez l'option Start pour les trois projets suivants:
- VehicleBooking.Customer.API
- VehicleBooking.Vehicle.API
- VehicleBooking.ApiGateway

Cliquez Démarrer l'application qui va générer 3 documentations des API en utilisant SWAGGER

pour le test, lancez la commande suivante:
```bash
dotnet test
```
