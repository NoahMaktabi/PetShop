using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Domain;
using Presentation.Interfaces;
using Presentation.MenuAssembly;

namespace Presentation
{
    public class MenuRunner
    {
        private AnimalShop _animalShop;
        public void Start()
        {
            _animalShop = new AnimalShop(InputHandler.GetCapitalInfoFromUser());
            _animalShop.Seed();
            RunMainMenu();
        }
        private void RunMainMenu()
        {
            var prompt = @"
Welcome to your PetShop. What would you like to do?
(Use the arrow keys to cycle through options and press enter to select an option)";
            prompt += GetCapitalDetails(_animalShop.Capital, _animalShop.AnimalsInStock.ToList());

            string[] options = { "View pets in stock", "Buy pets", "Sell pets", "Exit program" };
            
            IMenu mainMenu = new Menu(prompt, options);
            var selectedIndex = mainMenu.Run();
            
            switch (selectedIndex)
            {
                case 0:
                    ViewPetsInStock();
                    break;
                case 1:
                    BuyPets();
                    break;
                case 2:
                    SellPets();
                    break;
                case 3:
                    ExitProgram();
                    break;
            }
        }

        private void ViewPetsInStock()
        {
            Console.Clear();
            var viewPetsMenu = new ViewPetsMenu(_animalShop);
            while (!viewPetsMenu.Run())
            {
                RunMainMenu(); 
            }
        }

        private void BuyPets()
        {
            var buyMenu = new BuyPetsMenu(_animalShop);
            while (!buyMenu.Run())
            {
                RunMainMenu(); 
            }
        }

        private void SellPets()
        {
            var sellMenu = new SellPetsMenu(_animalShop);
            while (!sellMenu.Run())
            {
                RunMainMenu();
            }
        }

        private static void ExitProgram()
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }


        private static string GetCapitalDetails(decimal capital, IEnumerable<Animal> animals)
        {
            var animalCost = animals.Sum(c => c.PurchasePrice);
            return $"\nYour available cash: {capital:C2}.\n" +
                   $"The cost of pets in stock is {animalCost:C2}";
        }
    }
}
