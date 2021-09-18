using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Domain.Animals;
using Domain;
using Presentation.Interfaces;

/*
 * This class has members marked as protected as they are needed in another derived class.
 * It has even a virtual method that gets overriden by the derived class. 
 */


namespace Presentation.MenuAssembly
{
    public class ViewPetsMenu
    {
        protected readonly AnimalShop AnimalShop;

        public ViewPetsMenu(AnimalShop animalShop)
        {
            this.AnimalShop = animalShop;
        }

        public virtual bool Run()
        {
            const string prompt = "Animals in stock are shown below. Select an option to view details";
            var options = GetOptionsWithStatistiks(AnimalShop.AnimalsInStock);
            IMenu showStatsMenu = new Menu(prompt, options);
            startLabel:
            var selectedIndex = showStatsMenu.Run();  //0 dogs, 1 cats, 2 fish, 3 birds, 4 rabbits, 5 exit
            switch (selectedIndex)
            {
                case 0:
                    ShowInfoFromList(AnimalShop.AnimalsInStock.Where(animal => animal is Dog));
                    break;
                case 1:
                    ShowInfoFromList(AnimalShop.AnimalsInStock.Where(animal => animal is Cat));
                    break;
                case 2:
                    ShowInfoFromList(AnimalShop.AnimalsInStock.Where(animal => animal is Fish));
                    break;
                case 3:
                    ShowInfoFromList(AnimalShop.AnimalsInStock.Where(animal => animal is Bird));
                    break;
                case 4:
                    ShowInfoFromList(AnimalShop.AnimalsInStock.Where(animal => animal is Rabbit));
                    break;
                case 5:
                    return false;
            }
            Console.WriteLine($"\nPress any key to return to the list.");
            Console.ReadKey(true);
            goto startLabel;
        }

        protected static string[] GetOptionsWithStatistiks(ICollection<Animal> animals)
        {
            var dogs = animals.Count(a => a is Dog);
            var cats = animals.Count(a => a is Cat);
            var fish = animals.Count(a => a is Fish);
            var birds = animals.Count(a => a is Bird);
            var rabbits = animals.Count(a => a is Rabbit);
            var options = new string[]
            {
                $"Dogs: {dogs}.",
                $"Cats: {cats}.",
                $"Fish: {fish}.",
                $"Birds: {birds}.",
                $"Rabbits: {rabbits}",
                "Back to main menu"
            };

            return options;
        }


        #region AnimalInfo

        protected virtual void ShowInfoFromList(IEnumerable<Animal> animals)
        {
            var animalList = animals.ToList();
            if (!animalList.Any())
            {
                Console.WriteLine("There are no items in this list!");
                return;
            }
            foreach (var animal in animalList)
            {
                switch (animal)
                {
                    case Dog d:
                        ShowDogInfo(d);
                        break;
                    case Fish f:
                        ShowFishInfo(f);
                        break;
                    case Bird b:
                        ShowBirdInfo(b);
                        break;
                    case Rabbit r:
                        ShowRabbitInfo(r);
                        break;
                    case Cat c:
                        ShowCatInfo(c);
                        break;
                    default:
                        ShowAnimalInfo(animal);
                        break;
                }
            }
        }

        protected static void ShowAnimalInfo(Animal animal)
        {
            Console.WriteLine("-----------------");
            Console.WriteLine(
                $"Id is: {animal.AnimalId}\n" +
                $"Name is: {animal.Name}\n" +
                $"Age is: {animal.Age}\n" +
                $"Description is: {animal.Description}\n" +
                $"Purchase price is: {animal.PurchasePrice:C2}\n" +
                $"Sell price is: {animal.SellPrice:C2}\n" +
                $"Has insurance: " + (animal.IsInsured ? "Yes." : "No.")
            );
        }

        protected static void ShowDogInfo(Dog dog)
        {
            ShowAnimalInfo(dog);
            Console.WriteLine(
                $"Breed is: {dog.Breed}.\n" +
                $"Sex: " + (dog.Male ? "Male.\n" : "Female.\n") +
                $"Has leash: " + (dog.WithLeash ? "Yes." : "No.")
            );
        }

        protected static void ShowCatInfo(Cat cat)
        {
            ShowAnimalInfo(cat);
            Console.WriteLine(
                $"Breed is: {cat.Breed}.\n" +
                $"Sex: " + (cat.Male ? "Male.\n" : "Female.\n") +
                $"Vaccinated: " + (cat.Vaccinated? "Yes." : "No.")
            );
        }

        protected static void ShowFishInfo(Fish fish)
        {
            ShowAnimalInfo(fish);
            Console.WriteLine(
                $"With aquarium: " + (fish.HasAquarium ? "Yes.\n" : "No.\n") +
                $"Has fish-memory: " + (fish.HasFishMemory ? "Yes.\n" : "No.\n") +
                $"Eatable: " + (fish.IsEatable ? "Yes." : "No.")
            );
        }

        protected static void ShowBirdInfo(Bird bird)
        {
            ShowAnimalInfo(bird);
            Console.WriteLine(
                $"Can fly: " + (bird.CanFly ? "Yes.\n" : "No.\n") +
                $"Can sing: " + (bird.CanSing ? "Yes.\n" : "No.\n") +
                $"Has cage: " + (bird.HasCage ? "Yes." : "No.")
            );
        }

        protected static void ShowRabbitInfo(Rabbit rabbit)
        {
            ShowAnimalInfo(rabbit);
            Console.WriteLine(
                $"Bites: " + (rabbit.BitesOthers ? "Yes.\n" : "No.\n") +
                $"Can jump: " + (rabbit.CanJump ? "Yes.\n" : "No.\n") +
                $"Can live inside: " + (rabbit.CanLiveInside ? "Yes." : "No.")
            );
        }
        
        #endregion
        
    }
}
