# Exercice de Recrutement Eudonet


## ARCHITECTURE DE L’APPLICATION


### Objectifs
Dans cette partie, vous devez être capable d’expliquer les choix effectués, les risques liés à ce type d’architecture et les possibilités d’évolution que vous voyez.


### Schéma de base de données
![Logo](images/bd/restaurant-bd.jpeg "Base de données")
Pour la base de données, j'ai choisi une architecture simple avec trois tables principales : Restaurants, Plats et Ingrédients. Les restaurants ont une relation
de 1 à plusieurs avec les plats, et les plats ont une relation de plusieurs à plusieurs avec les ingrédients. Cela permet de modéliser les données de manière
logique et de gérer les relations entre les entités. J'ai utilisé Entity Framework Core pour gérer la couche d'accès aux données et les migrations de base de données.
Pour configurer la base de données, j'ai utilisé le DbContext de l'API pour définir les entités et les relations, puis j'ai généré les migrations et mis à jour la base de données.
Il faut noter que j'ai utilisé des clés primaires et étrangères pour garantir l'intégrité des données et des relations entre les tables.
Aussi il faut s'assurer que dans le fichier appsettings.json, la chaine de connexion est bien configurée pour que l'API puisse se connecter à la base de données locale de 
votre machine.


### Architecture de l'application
Pour l'architecture de l'application, j'ai choisi une architecture en couches avec une séparation claire des responsabilités et des fonctionnalités.
L'application est divisée en plusieurs couches : Présentation/API Swagger, Logique Métier, Accès aux Données, et Modèles. Chaque couche a un rôle
spécifique et communique avec les autres couches de manière structurée et organisée. Voici un aperçu de l'architecture de l'application et des flux
de données entre les différentes couches pour les fonctionnalités de l'API.


### Risques et Possibilités d'évolution
L'architecture en couches de l'application permet une séparation claire des responsabilités et des fonctionnalités, ce qui facilite la maintenance,
l'extension et l'évolutivité de l'application. Cela permet de modifier ou d'ajouter de nouvelles fonctionnalités sans affecter les autres parties de l'application.
Cependant, cela peut entraîner une complexité accrue et des problèmes de performance si les couches ne sont pas correctement conçues et organisées.
Il est important de bien définir les interfaces entre les
couches et de s'assurer que les données sont transférées de manière efficace et sécurisée entre les différentes parties de l'application.
Pour améliorer l'architecture de l'application, on pourrait envisager d'ajouter des tests unitaires et d'intégration pour valider le bon fonctionnement
de l'API et des différentes couches. On pourrait également envisager d'ajouter une couche de cache pour améliorer les performances et réduire la charge
sur la base de données. Enfin, on pourrait envisager d'ajouter une couche de sécurité pour protéger l'API contre les attaques et les vulnérabilités.


### Couches de l'application
Dans Restaurant API je développe une application plus précisément un API qui selon les contraintes de l’exercice va me permettre de faire la 
gestion de menu pour des restaurants. C’est une application Backend en C# .Net avec EntityFramework qui me permet des faire des manipulations
sur les données. J’ai organisé l’application en plusieurs dossiers. Le dossier Controllers ou je vais retrouver tous mes contrôleurs de l’application. 
Le dossier Data ou j’utilises des interfaces et leurs définitions pour faires des manipulations sur mes données dans la bd. 
C’est aussi dans ce dossier que j’ai le fichier RestaurantDbContext.cs qui va me permettre de définir toutes les spécifications sur mes données dans 
la base de données. Avec entity Framework je gère la couche "Data Access" de l'application, qui gère la logique d'accès aux données et l'interaction
avec la base de données. C’est dans ce dossier aussi que Je Seed ma base dedonnées avec DbInitializer.cs pour me permettre de tester mon Api dans 
Swagger rapidement avec déjà des données types. Le dossier Models est tout simplement un ensemble de classes modèles définissant la structure des 
données avec lesquelles mon application va travailler. C’est-à-dire les propriétés et les champs qui représentent les entités dans ma base de données,
comme les tables et leurs relations. Le dossier Migrations est généré automatiquement par Entity framework lorsque nous settons notre bd avec les 
commandes « dotnet ef migrations add InitialCreate » et « dotnet ef database update ». Le dossier Service va être le lien de mon dossier 
Data avec mon Dossier Controller. Cela va me permettre d’encapsuler et isoler la logique métier de l'application des autres parties. Cela signifie que 
les opérations complexes, les règles métier et les calculs sont effectués à l'intérieur des services, gardant ainsi cette logique séparée de l'interface 
utilisateur et du stockage des données. 


#### Couche Présentation/API Swagger
Interface utilisateur, souvent construite avec des frameworks tels que Vue.js, React ou Angular. Elle est responsable de la présentation des données 
et de l'interaction avec l'utilisateur. Dans mon cas c’est Swagger que j’utilise pour interagir avec mon api.


#### Couche Logique Métier
API ou backend de l'application, construite avec ASP.NET Core pour .NET avec C# comme langage de programmation. Cette couche contient la logique métier,
la validation des données, et les règles métier.


#### Couche Accès aux Données
Composants qui communiquent directement avec la base de données, responsables des requêtes, des opérations CRUD, et de la transformation des données 
en modèles pour le backend. J’utile Entity Framework pour cette couche.


### Schéma de flux entre les couches pour les fonctionnalités
1. Lister les Restaurants :
- Swagger envoie une requête GET à l'API.
-L'API interroge la base de données pour obtenir la liste des restaurants.
-Les données sont renvoyées au format Json pour affichage dans Swagger.
2. Ajouter de Nouveaux Restaurants :
- Swagger collecte les données du formulaire et les envoie via une requête POST à l'API.
- L'API valide les données et les insère dans la base de données.
- Un statut de réussite est renvoyé à Swagger avec un Json avec les informations du nouveau restaurant.
3. Afficher les Plats d'un Restaurant :
- Swagger demande les plats d'un restaurant spécifique avec une requête GET, incluant l'ID du restaurant.
- L'API extrait les plats de ce restaurant depuis la base de données.
- Les plats sont renvoyés à Swagger dans un format Json pour affichage.
4. Vue Détail d'un Plat :
- Une requête GET avec l'ID du plat est envoyée par Swagger.
- L'API récupère les détails du plat et les ingrédients associés.
- Les informations sont transmises à Swagger au format Json avec les propriétés du plat.
5. Ajouter de Nouveaux Plats via TheMealDb :
- Swagger envoie une requête pour ajouter un plat via l'API.
- L'API interroge TheMealDb.com pour obtenir les détails d’un plat random.
- L'API sauvegarde le plat et ses ingrédients dans la base de données.
- la confirmation envoyée à Swagger.


## SPECIFIER


### Ajouter de nouveaux restaurants - Fonctionnalité 2
Pour Réaliser la fonctionnalité 2 voici les étapes à suivre pour qu’un autre développeur puisse effectuer le travail demandé.
1. Préparer le Modèle de Données :
Restaurant.cs dans le dossier Models :
S’assurer que la classe Restaurant a les attributs nécessaires tels que Id, Nom, et Adresse avec les annotations de validation appropriées.
2. Ajouter un Repository :
IRestaurantRepository.cs dans le dossier Data :
Créer une interface pour définir les opérations de base de données nécessaires, telles que AddRestaurantAsync.
RestaurantRepository.cs dans le dossier Data :
Implémenter l'interface dans une classe concrète, s’assurant qu’il y a une méthode pour ajouter un restaurant dans la base de données.
3. Créer un Service :
RestaurantService.cs dans le dossier Services :
Créer une méthode AddRestaurantAsync qui utilise IRestaurantRepository pour ajouter un nouveau restaurant à la base de données.
4. Définir le Contrôleur :
RestaurantController.cs dans le dossier Controllers :
Ajouter une méthode POST dans le contrôleur pour prendre en charge l'ajout de nouveaux restaurants via l'API.
5. Migration de la Base de Données :
Générer une nouvelle migration pour tout changement de schéma à l'aide de Entity Framework Core.
dotnet ef migrations add AddRestaurant
dotnet ef database update
6. Validation Front-End :
Si un front-end est en place, créez une interface utilisateur pour soumettre les informations du nouveau restaurant et valider les entrées côté client.



### Afficher une vue détaillée d’un plat - Fonctionnalité 4
1. Conception du DTO (Data Transfer Object) :
Créer un PlatDetailDto pour représenter les détails d'un plat, y compris ses ingrédients et quantités.
PlatDetailDto.cs dans le dossier Models :
2. Modification du Modèle Plat (si nécessaire) :
S’assurer que le modèle Plat dans le dossier Models possède des propriétés de navigation vers les ingrédients et qu'il peut être utilisé pour les requêtes Entity Framework.
3. Création ou Mise à jour des Services :
Mettre à jour PlatService dans le dossier Services pour inclure une méthode qui récupère les détails d'un plat y compris ses ingrédients.
4. Ajout d'un Endpoint API :
Ajouter un nouvel endpoint dans PlatController qui utilise PlatService pour renvoyer les détails d'un plat.
5. Interface Utilisateur (si applicable) :
Si un front-end est présent, créer les composants d'interface utilisateur nécessaires pour afficher les détails d'un plat.
