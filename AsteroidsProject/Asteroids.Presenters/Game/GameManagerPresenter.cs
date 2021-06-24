using System.Collections.Generic;
using Asteroids.Controllers.Game.Asteroids;
using Asteroids.Controllers.Game.GameDifficulty;
using Asteroids.Controllers.Game.Score;
using Asteroids.Controllers.Game.Ship;
using Asteroids.Controllers.Game.Shots;
using Asteroids.Controllers.Main.Observers.GameObservers;
using Asteroids.Core;
using Asteroids.Core.Updaters;
using Asteroids.Models.Game;
using Asteroids.Utility;
using Environment = Asteroids.Core.Environment;

namespace Asteroids.Controllers.Game
{
    public class GameManagerPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly GameManagerData _data;
        private readonly IEnvironmentView _environmentView;
        private readonly StepExecutor _gameStepExecutor = new StepExecutor();
        private readonly List<IPresenter> _gameControllers = new List<IPresenter>();

        public GameManagerPresenter(Environment environment, GameManagerData data, IEnvironmentView environmentView)
        {
            _environment = environment;
            _data = data;
            _environmentView = environmentView;
        }

        public void Attach()
        {
            _data.OnStart += Start;
            _data.OnStop += Stop;
        }

        public void Detach()
        {
            _data.OnStart -= Start;
            _data.OnStop -= Stop;
        }

        private void Start()
        {
            _gameStepExecutor.Add(new ShipStep());
            _gameStepExecutor.Add(new AsteroidsStep());
            _gameStepExecutor.Add(new InputStep());
            _gameStepExecutor.Add(new ShotStep());
            _gameStepExecutor.Add(new GameObserverStep());
            _gameStepExecutor.Add(new GameDifficultyStep());
            _gameStepExecutor.Add(new GameScoreStep());
            _gameStepExecutor.Execute(_gameControllers, _environment, _environmentView);
            _environment.SystemUpdater.Add(new AsteroidsFactoryUpdater());
            _environment.SystemUpdater.Add(new ShotUpdater());
            foreach (var gameController in _gameControllers)
            {
                gameController.Attach();
            }

            _environment.Screens.GameScreenData.Show();
        }

        private void Stop()
        {
            _environment.SystemUpdater.Clear();
            _gameStepExecutor.Clear();
            foreach (var controller in _gameControllers)
            {
                controller.Detach();
            }

            _gameControllers.Clear();
            _environment.Screens.StartScreenData.Show();
            _environment.Screens.GameScreenData.Hide();
        }
    }
}