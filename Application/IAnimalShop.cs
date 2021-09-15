using Domain;

namespace Application
{
    public interface IAnimalShop
    {
        string Buy(Animal animal);
        string Sell(int animalId);
    }
}
