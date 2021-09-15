using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Application
{
    public class AnimalShop : IAnimalShop
    {
        public decimal Capital { get; set; }
        public ICollection<Animal> AnimalsInStock { get; set; } = new List<Animal>();

        public AnimalShop(decimal capital)
        {
            Capital = capital;
        }


        //This method is generated according to instructions given by the teacher. However, the method is not used in the program
        public Animal SellAnimal(string animalType)
        {
            var animal = AnimalsInStock.FirstOrDefault(a => a.Type == animalType);
            if (animal == null) return null;

            AnimalsInStock.Remove(animal);
            Capital += animal.SellPrice;
            return animal;
        }


        public string Buy(Animal animal)
        {
            if (Capital - animal.PurchasePrice < 0)
                return "You do not have sufficient funds to buy this animal.";

            AnimalsInStock.Add(animal);
            Capital -= animal.PurchasePrice;
            return $"The animal {animal.Name} has been bought and is now added to stock." +
                   $"\nYou paid {animal.PurchasePrice:C2} to purchase {animal.Name}" +
                   $"\nYour capital is now {Capital:C2}";
        }

        public string Sell(int animalId)
        {
            var animal = AnimalsInStock.FirstOrDefault(a => a.AnimalId == animalId);
            if (animal == null) return "The animal could not be found";

            AnimalsInStock.Remove(animal);
            Capital += animal.SellPrice;
            return $"You have sold {animal.Name} for {animal.SellPrice:C2}. Your capital is now {Capital:C2}";
        }
    }
}
