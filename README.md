# PetShop
Console app that simulates a Pet Shop. The user can view the stock. Buy and sell pets. 

The solution is divided into 3 layers as it applies the clean architecture design pattern. 
<h1>Layers:</h1>

<h3>1- Domain:</h3>
Project type: C# Class Library
The Domain layer contains the definition of the objects (animals) that the app uses. 
Here we only define the shape of the Animal class and the classes that inherit from Animal.
The Domain layer has no dependencies. 

<h3>2- Application:</h3>
Project type: C# Class Library
The Application layer contains the business logic for the app. The idea is that we can use the Domain and Application layer with any kind of project, 
so those are constants when the Presentation can change. It can be swapped with WPF, MVC etc... 
The business logic for this app is in the AnimalShop:
It contains 2 properties, Capital which is the amount of money the shop has, and AnimalsInStock which is a list that contains all the animals that the shop has. 
The list is populated by Seed method which is an extension method of the class AnimalShop. It populates the list with some fake data. 
AnimalShop also contains a method to buy and another to sell pets. 
The Buy method accepts an animal as param and returns string with success or fail message. 
The Sell method accepts an int as animalId. Also, returns a string with success or fail message.

The Application layer has a dependency on Domain. 


<h3>3- Presentation:</h3>
Project type: C# Console App.
Here we create a Menu class inside MenuAssembly folder. In this class a modern menu is defined. 
The menu will only allow for selections via pressing up or down arrows. The user won't be able to type input unless it's necessary. 
This menu is then called by MenuRunner. 
MenuRunner instantiate the AnimalShop class by asking the user for the capital of the shop. The same instance is then used while the app is running. 
MenuRunner defines the shape of the mainMenu and handles selection. 
The choices are handled in different classes inside MenuAssembly. 
All those classes use InputHandler class which is created to handle input from user and return valid data. 
The program class has only one job. To instantiate the MenuRunner class and start the menu. 

The Presentation layer has a dependency on Application. 
