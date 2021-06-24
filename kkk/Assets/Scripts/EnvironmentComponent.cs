using Asteroids.Core;
using Asteroids.Views;
using Asteroids.Views.Game.Asteroids;
using Asteroids.Views.Game.Ship;
using Asteroids.Views.Game.Shots;
using Asteroids.Views.Screens.GameScreen;
using Asteroids.Views.Screens.StartScreen;
using DefaultNamespace.MonoViews;
using MonoViews;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnvironmentComponent : MonoBehaviour,IEnvironmentView
    {
        [SerializeField] private ShipView _shipView;
        [SerializeField] private InputView _inputView;
        [SerializeField] private StartScreenView _startScreenView;
        [SerializeField] private GameLocationBoundaries _gameLocationBoundaries;
        [SerializeField] private GameScreenView _gameScreenView;
        [SerializeField] private PullCollection _pullCollection;
        [SerializeField] private AsteroidView _asteroidView;

        public IShipView ShipView => _shipView;
        public IInputView InputView => _inputView;
        public IStartScreenView StartScreenView => _startScreenView;
        public IGameLocationBoundaries GameLocationBoundaries => _gameLocationBoundaries;
        public IGameScreenView GameScreenView => _gameScreenView;
        public IAsteroidView AsteroidView => _asteroidView;
        public IPullContainerCollection PullContainerCollection => _pullCollection;
    }
}