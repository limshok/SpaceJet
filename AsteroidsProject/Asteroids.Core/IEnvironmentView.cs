using Asteroids.Views;
using Asteroids.Views.Game.Asteroids;
using Asteroids.Views.Game.Ship;
using Asteroids.Views.Screens.GameScreen;
using Asteroids.Views.Screens.StartScreen;

namespace Asteroids.Core
{
    public interface IEnvironmentView
    {
        public IPullContainerCollection PullContainerCollection { get; }
        public IShipView ShipView { get; }
        public IInputView InputView { get; }
        public IStartScreenView StartScreenView { get; }
        public IGameLocationBoundaries GameLocationBoundaries { get; }
        public IGameScreenView GameScreenView { get; }
        public IAsteroidView AsteroidView { get; }
    }
}