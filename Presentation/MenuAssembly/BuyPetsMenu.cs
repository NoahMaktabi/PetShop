using System;
using System.Linq;
using Application;
using Domain;
using Domain.Animals;
using Presentation.Interfaces;

namespace Presentation.MenuAssembly
{
    public class BuyPetsMenu
    {
        private readonly AnimalShop _animalShop;

        public BuyPetsMenu(AnimalShop animalShop)
        {
            _animalShop = animalShop;
        }

        /// <summary>
        /// Runs the Buy pets menu. returns false if the user chooses to return to main menu.
        /// </summary>
        /// <returns>True while the user uses the menu. False when the user want to return to main menu.</returns>
        public bool Run()
        {
            const string prompt = "Select which kind of pet you want to purchase";
            string[] options = { "Dog", "Cat", "Fish", "Bird", "Rabbit", "Back to main menu" };
            IMenu buyMenu = new Menu(prompt, options);
            var selectedIndex = buyMenu.Run();
            var animal = new Animal();
            switch (selectedIndex)
            {
                case 0:
                    animal = GetDogDetails();
                    break;
                case 1:
                    animal = GetCatDetails();
                    break;
                case 2:
                    animal = GetFishDetails();
                    break;
                case 3:
                    animal = GetBirdDetails();
                    break;
                case 4:
                    animal = GetRabbitDetails();
                    break;
                case 5:
                    return false;
            }

            var msg = _animalShop.Buy(animal);
            
            Console.WriteLine($"{msg}\nPress any key to return to main menu");
            Console.ReadKey(true);
            return false;
        }



        #region GetsAnimalInfo

        

        
        /// <summary>
        /// Gets animal details from the user. The method gets the details that all animals share.
        /// The method creates a new Id for the new Animal. 
        /// </summary>
        /// <returns>Returns an Animal created from the details supplied by the user</returns>
        private Animal GetAnimalDetails()
        {
            var lastAnimal = _animalShop.AnimalsInStock.LastOrDefault();
            var newId = lastAnimal == null ? 1 : lastAnimal.AnimalId + 1;
            
            var animal = new Animal()
            {
                AnimalId = newId,
                Name = InputHandler.GetString("name"),
                Age = InputHandler.GetAge(),
                Description = InputHandler.GetString("description"),
                IsInsured = InputHandler.GetBoolValue("Is the pet insured?"),
                PurchasePrice = InputHandler.GetPriceInfoFromUser("purchase"),
            };
            animal.SellPrice = InputHandler.GetPriceInfoFromUser("sell", animal.PurchasePrice);
            
            return animal;
        }

        private Dog GetDogDetails()
        {
            var animal = GetAnimalDetails();
            var dog = new Dog
            {
                AnimalId = animal.AnimalId,
                Name = animal.Name,
                Age = animal.Age,
                SellPrice = animal.SellPrice,
                PurchasePrice = animal.PurchasePrice,
                IsInsured = animal.IsInsured,
                Description = animal.Description,
                Type = "Dog",
                Breed = InputHandler.GetString("breed"),
                Male = InputHandler.GetBoolValue("Is the dog a male?"),
                WithLeash = InputHandler.GetBoolValue("Does the dog has a leash?"),
            };
            return dog;
        }

        private Cat GetCatDetails()
        {
            var animal = GetAnimalDetails();
            var cat = new Cat()
            {
                AnimalId = animal.AnimalId,
                Name = animal.Name,
                Age = animal.Age,
                SellPrice = animal.SellPrice,
                PurchasePrice = animal.PurchasePrice,
                IsInsured = animal.IsInsured,
                Description = animal.Description,
                Type = "Cat",
                Breed = InputHandler.GetString("breed"),
                Male = InputHandler.GetBoolValue("Is the cat a male?"),
                Vaccinated = InputHandler.GetBoolValue("Is the cat vaccinated?"),
            };

            return cat;
        }

        private Fish GetFishDetails()
        {
            var animal = GetAnimalDetails();
            var fish = new Fish
            {
                AnimalId = animal.AnimalId,
                Name = animal.Name,
                Age = animal.Age,
                SellPrice = animal.SellPrice,
                PurchasePrice = animal.PurchasePrice,
                IsInsured = animal.IsInsured,
                Description = animal.Description,
                Type = "Fish",
                HasAquarium = InputHandler.GetBoolValue("Does the fish come with an aquarium?"),
                HasFishMemory = InputHandler.GetBoolValue("Does the fish has fish-memory?"),
                IsEatable = InputHandler.GetBoolValue("Is the fish the eatable type?"),
            };
            return fish;
        }

        private Bird GetBirdDetails()
        {
            var animal = GetAnimalDetails();
            var bird = new Bird
            {
                AnimalId = animal.AnimalId,
                Name = animal.Name,
                Age = animal.Age,
                SellPrice = animal.SellPrice,
                PurchasePrice = animal.PurchasePrice,
                IsInsured = animal.IsInsured,
                Description = animal.Description,
                Type = InputHandler.GetString("kind"),
                CanFly = InputHandler.GetBoolValue("Can the bird fly?"),
                CanSing = InputHandler.GetBoolValue("Can the bird sing?"),
                HasCage = InputHandler.GetBoolValue("Does the bird come with a cage?"),
            };
            return bird;
        }

        private Rabbit GetRabbitDetails()
        {
            var animal = GetAnimalDetails();
            var rabbit = new Rabbit
            {
                AnimalId = animal.AnimalId,
                Name = animal.Name,
                Age = animal.Age,
                SellPrice = animal.SellPrice,
                PurchasePrice = animal.PurchasePrice,
                IsInsured = animal.IsInsured,
                Description = animal.Description,
                Type = "Rabbit", 
                BitesOthers = InputHandler.GetBoolValue("Does the rabbit bite?"),
                CanJump = InputHandler.GetBoolValue("Can the rabbit jump?"),
                CanLiveInside = InputHandler.GetBoolValue("Can the rabbit live inside?"),
            };
            return rabbit;
        }

        #endregion
    }
}
