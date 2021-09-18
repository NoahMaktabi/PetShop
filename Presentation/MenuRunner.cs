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
       
        /// <summary>
        /// Entry point to the menu system. The method creates an instance of AnimalShop that is used throughout the app.
        /// The method calls Seed method to populate the animalShop with a list of animals.
        /// Then presents a menu to the user. 
        /// </summary>
        public void Start()
        {
            _animalShop = new AnimalShop(InputHandler.GetCapitalInfoFromUser());
            _animalShop.Seed();
            RunMainMenu();
        }


        /*
         *MainMenu logic. RunMainMenu creates an instance of Menu class that handles the menu system.
         * The method provides the prompt that Menu needs, and options to present to the user.
         * The method then runs the Menu via Run method. Run method returns an int that represents the index of the options array.
         * Based on selected index, the switch statement handles different outcomes. 
         * The methods used below are all marked as private, that is because they are not meant to be exposed to other classes.
         * Other classes should only see Start method as it is the only relevant methods to the outside.
         * Most of the methods rely on other classes. This is because the logic is too long to be handled just in this class.
         * This class should only handle the Run part of the menu as the name suggests. This is according to the S in Solid. 
         */
        #region HelperMethods
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

        /*
         * The first option in the switch statement. The method creates an instance of ViewPetsMenu and runs that menu.
         * The Run method in ViePetsMenu returs a bool. If the bool is false then the menu is done. Which means we can return to main menu.
         * That is why we have the while loop. To run the main menu when Run returs false. 
         */
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

        /// <summary>
        /// Returns a string that shows info about the capital and the cost of the animals in stock.
        /// The capital should be provided along with a list of Animals. 
        /// </summary>
        /// <param name="capital">The capital that exits in the animalShop</param>
        /// <param name="animals">A list of animals that exists in animalShop</param>
        /// <returns>string that shows info about the capital and the cost of the animals in stock.</returns>
        private static string GetCapitalDetails(decimal capital, IEnumerable<Animal> animals)
        {
            var animalCost = animals.Sum(c => c.PurchasePrice);
            return $"\nYour available cash: {capital:C2}.\n" +
                   $"The cost of pets in stock is {animalCost:C2}";
        }
        

        #endregion
        
    }
}
