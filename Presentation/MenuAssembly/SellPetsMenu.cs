using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Domain;
using Domain.Animals;
using Presentation.Interfaces;

namespace Presentation.MenuAssembly
{
    public class SellPetsMenu : ViewPetsMenu
    {
        public SellPetsMenu(AnimalShop animalShop) : base(animalShop)
        {
        }

        public override bool Run()
        {
            const string prompt = "Animals in stock are shown below. Select an option to view details";
            startLabel:
            var options = GetOptionsWithStatistiks(AnimalShop.AnimalsInStock);
            IMenu sellPetsMenu = new Menu(prompt, options);
            var selectedIndex = sellPetsMenu.Run();  //0 dogs, 1 cats, 2 fish, 3 birds, 4 rabbits, 5 exit
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

        protected override void ShowInfoFromList(IEnumerable<Animal> animals)
        {
            var animalList = animals.ToList();
            base.ShowInfoFromList(animalList);

            if (!animalList.Any())
            {
                Console.WriteLine("There are no items in this list!");
                return;
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            var sell = InputHandler.GetBoolValue("Do you want to sell a pet?", false);
            if (!sell)
            {
                Console.ResetColor();
                return;
            }

            var minId = animalList.Min(m => m.AnimalId);
            var maxId = animalList.Max(m => m.AnimalId);
            startLabel:
            var id = InputHandler.GetId(minId, maxId);
            var animal = animalList.FirstOrDefault(a => a.AnimalId == id);
            if (animal == null)
            {
                Console.WriteLine("Could not find the pet with the id that you gave. Try again");
                goto startLabel;
            }

            animalList.Remove(animal);
            var msg = AnimalShop.Sell(id);
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
