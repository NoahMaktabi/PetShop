using System;

namespace Domain
{
    public class Animal
    {
        public int AnimalId { get; init; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public bool IsInsured { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}
