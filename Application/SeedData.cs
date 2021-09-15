using System.Collections.Generic;
using Domain;
using Domain.Animals;

namespace Application
{
    public static class SeedData
    {
        /// <summary>
        /// Extension to AnimalShop class to populate AnimalsInStock with some data
        /// </summary>
        /// <param name="shop"></param>
        public static void Seed(this AnimalShop shop)
        {
            var animals = new List<Animal>
            {
                new Dog
                {
                    AnimalId = 1,
                    Type = "Dog",
                    Name = "Vovve",
                    Age = 5,
                    Description = "Nice dog",
                    IsInsured = true,
                    PurchasePrice = 7000,
                    SellPrice = 9000,
                    Breed = "Tax",
                    Male = true,
                    WithLeash = false,
                },
                new Dog
                {
                    AnimalId = 2,
                    Type = "Dog",
                    Name = "Pucko",
                    Age = 7,
                    Description = "Stupid dog",
                    IsInsured = false,
                    PurchasePrice = 3500,
                    SellPrice = 6000,
                    Breed = "Husky",
                    Male = true,
                    WithLeash = true,
                },
                new Dog
                {
                    AnimalId = 3,
                    Type = "Dog",
                    Name = "Milo",
                    Age = 3,
                    Description = "Like to play around",
                    IsInsured = true,
                    PurchasePrice = 11500,
                    SellPrice = 14000,
                    Breed = "Golden",
                    Male = true,
                    WithLeash = false,
                },

                new Cat
                {
                    AnimalId = 4,
                    Type = "Cat",
                    Name = "Lucy",
                    Age = 2,
                    Description = "Good kitty",
                    IsInsured = true,
                    PurchasePrice = 7000,
                    SellPrice = 8500,
                    Breed = "Ragdoll",
                    Male = false,
                    Vaccinated = true,
                },
                new Cat
                {
                    AnimalId = 5,
                    Type = "Cat",
                    Name = "Dexter",
                    Age = 4,
                    Description = "Trouble maker",
                    IsInsured = false,
                    PurchasePrice = 2000,
                    SellPrice = 3000,
                    Breed = "Persian",
                    Male = true,
                    Vaccinated = false,
                },
                new Cat
                {
                    AnimalId = 6,
                    Type = "Cat",
                    Name = "Jack",
                    Age = 7,
                    Description = "Old lazy cat",
                    IsInsured = false,
                    PurchasePrice = 1500,
                    SellPrice = 2000,
                    Breed = "Street cat",
                    Male = true,
                    Vaccinated = false,
                },

                new Bird
                {
                    AnimalId = 7,
                    Type = "Bird",
                    Name = "Flyer",
                    Age = 1,
                    Description = "A bird",
                    IsInsured = false,
                    PurchasePrice = 200,
                    SellPrice = 400,
                    CanFly = true,
                    HasCage = true,
                    CanSing = false,
                },
                new Bird
                {
                    AnimalId = 8,
                    Type = "Chicken",
                    Name = "Chuck",
                    Age = 2,
                    Description = "Taste nice",
                    IsInsured = false,
                    PurchasePrice = 100,
                    SellPrice = 200,
                    CanFly = false,
                    HasCage = false,
                    CanSing = false,
                },

                new Fish
                {
                    AnimalId = 9,
                    Type = "Fish",
                    Name = "Nemo",
                    Age = 2,
                    Description = "Funny",
                    IsInsured = false,
                    PurchasePrice = 500,
                    SellPrice = 700,
                    HasAquarium = true,
                    HasFishMemory = false,
                    IsEatable = false,
                },
                new Fish
                {
                    AnimalId = 10,
                    Type = "Fish",
                    Name = "Dory",
                    Age = 10,
                    Description = "Bad memory",
                    IsInsured = false,
                    PurchasePrice = 300,
                    SellPrice = 450,
                    HasAquarium = false,
                    HasFishMemory = true,
                    IsEatable = false,
                },
                new Fish
                {
                    AnimalId = 11,
                    Type = "Fish",
                    Name = "Marvin",
                    Age = 15,
                    Description = "Doesn't give up",
                    IsInsured = false,
                    PurchasePrice = 700,
                    SellPrice = 850,
                    HasAquarium = false,
                    HasFishMemory = false,
                    IsEatable = true,
                },

                new Rabbit
                {
                    AnimalId = 12,
                    Type = "Rabbit",
                    Name = "Bunny",
                    Age = 6,
                    Description = "White rabbit",
                    IsInsured = false,
                    PurchasePrice = 700,
                    SellPrice = 850,
                    BitesOthers = false,
                    CanJump = true,
                    CanLiveInside = false,
                },
                new Rabbit
                {
                    AnimalId = 13,
                    Type = "Rabbit",
                    Name = "Jumpy",
                    Age = 4,
                    Description = "Brown rabbit",
                    IsInsured = false,
                    PurchasePrice = 650,
                    SellPrice = 850,
                    BitesOthers = true,
                    CanJump = true,
                    CanLiveInside = false,
                },
            };

            shop.AnimalsInStock = animals;
        }
    }
}
