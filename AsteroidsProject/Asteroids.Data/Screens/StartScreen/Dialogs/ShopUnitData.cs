using Asteroid.Description;

namespace Asteroids.Models.Screens.StartScreen.Dialogs
{
    public class ShopUnitData
    {
        public readonly ShipDescription Description;
        public bool IsPurchased;

        public ShopUnitData(ShipDescription description, bool isPurchased)
        {
            IsPurchased = isPurchased;
            Description = description;
        }
    }
}