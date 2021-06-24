using Asteroid.Description;
using Asteroids.Models.Screens.GameScreen;
using Asteroids.Models.Screens.StartScreen;
using Asteroids.Utility;

namespace Asteroids.Core
{
    public class Screens
    {
        public readonly StartScreenData StartScreenData;
        public readonly GameScreenData GameScreenData = new GameScreenData();
        
        public Screens(ShopDescription shopDescription, ISaveModel saveModel)
        {
            StartScreenData = new StartScreenData(shopDescription, saveModel.GetList<int>("purchasedShips"));
        }
    }
}