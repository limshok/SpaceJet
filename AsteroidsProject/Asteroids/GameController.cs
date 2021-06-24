using System.Collections.Generic;
using Asteroids.Controllers.Game;
using Asteroids.Controllers.Main.Player;
using Asteroids.Controllers.Screens.GameScreen;
using Asteroids.Controllers.Screens.StartScreen;
using Asteroids.Controllers.Screens.StartScreen.Dialogs;
using Asteroids.Core;
using Asteroids.Core.Configs;
using Asteroids.Utility;

namespace Asteroids
{
    public class GameController
    {
        private Environment _environment;
        private readonly List<IPresenter> _baseControllers = new List<IPresenter>();

        public void Awake(IEnvironmentView view, ISaveModel saveModel, Configs configs)
        {
            _environment = new Environment(saveModel, configs, view.GameLocationBoundaries);
            InitPulls(view.PullContainerCollection);
        }

        public bool Execute(IEnvironmentView view)
        {
            var stepExecutor = new StepExecutor();
            stepExecutor.Add(new GameManagerStep());
            stepExecutor.Add(new StartScreenStep());
            stepExecutor.Add(new GameScreenStep());
            stepExecutor.Add(new DialogsStep());
            stepExecutor.Add(new PlayerStep());
            stepExecutor.Execute(_baseControllers, _environment, view);
            foreach (var controller in _baseControllers)
            {
                controller.Attach();
            }

            return true;
        }

        public void Update(float deltaTime)
        {
            _environment.SystemUpdater.Update(_environment);
            _environment.TimerCollection.Update(deltaTime);
        }

        private void InitPulls(IPullContainerCollection pullContainerCollection)
        {
            _environment.AsteroidPullDictionary.HugeFirstAsteroidsPull.Init(pullContainerCollection.HugeFirstAsteroidPullContainer);
            _environment.AsteroidPullDictionary.NormalFirstAsteroidsPull.Init(pullContainerCollection.NormalFirstAsteroidPullContainer);
            _environment.AsteroidPullDictionary.SmallFirstAsteroidsPull.Init(pullContainerCollection.SmallFirstAsteroidPullContainer);

            _environment.AsteroidPullDictionary.HugeSecondAsteroidsPull.Init(pullContainerCollection.HugeSecondAsteroidPullContainer);
            _environment.AsteroidPullDictionary.NormalSecondAsteroidsPull.Init(pullContainerCollection.NormalSecondAsteroidPullContainer);
            _environment.AsteroidPullDictionary.SmallSecondAsteroidsPull.Init(pullContainerCollection.SmallSecondAsteroidPullContainer);

            _environment.AsteroidPullDictionary.LavaAsteroidPull.Init(pullContainerCollection.LavaAsteroidPullContainer);
            _environment.AsteroidPullDictionary.MetalAsteroidPull.Init(pullContainerCollection.MetalAsteroidPullContainer);

            _environment.ShotPullDictionary.FirstShotsPull.Init(pullContainerCollection.FirstShotsPullContainer);
            _environment.ShotPullDictionary.SecondShotsPull.Init(pullContainerCollection.SecondShotsPullContainer);
            _environment.ShotPullDictionary.ThirdShotsPull.Init(pullContainerCollection.ThirdShotsPullContainer);
            _environment.ShotPullDictionary.FourthShotsPull.Init(pullContainerCollection.FourthShotsPullContainer);
            _environment.ShotPullDictionary.FifthShotsPull.Init(pullContainerCollection.FifthShotsPullContainer);
        }

        public void Clear()
        {
            foreach (var controller in _baseControllers)
            {
                controller.Detach();
            }

            _baseControllers.Clear();
        }
    }
}