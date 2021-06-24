
using Asteroids.Core.Pull;
using Asteroids.Core.Time;
using Asteroids.Core.Updaters;
using Asteroids.Models.Game;
using Asteroids.Models.Game.Asteroids;
using Asteroids.Models.Game.GameDifficulty;
using Asteroids.Models.Game.Score;
using Asteroids.Models.Game.Ship;
using Asteroids.Models.Game.Shots;
using Asteroids.Models.Main;
using Asteroids.Utility;
using Asteroids.Views.Game.Asteroids;

namespace Asteroids.Core
{
    public class Environment
    {
        public readonly SystemUpdater SystemUpdater = new SystemUpdater();
        public readonly GameManagerData GameManagerData = new GameManagerData();
        public readonly ShipData ShipData;
        public readonly AsteroidData AsteroidData;
        public readonly AsteroidPullDictionary AsteroidPullDictionary = new AsteroidPullDictionary();
        public readonly ShotPullDictionary ShotPullDictionary = new ShotPullDictionary();
        public readonly ISaveModel SaveModel;
        public readonly PlayerData PlayerData;
        public readonly ShotData ShotData;
        public readonly Screens Screens;
        public readonly IGameLocationBoundaries GameLocationBoundaries;
        public readonly TimerCollection TimerCollection = new TimerCollection();
        public readonly GameDifficultyData GameDifficultyData;
        public readonly GameScoreData GameScoreData;


        public Environment(ISaveModel saveModel, Configs.Configs configs, IGameLocationBoundaries gameLocationBoundaries)
        {
            Screens = new Screens(configs.ShopDescription, saveModel);
            GameDifficultyData = new GameDifficultyData(configs.GameDifficultyDescription.AsteroidSpawnRatingMultiplier, configs.GameDifficultyDescription.GameRatingSpanMultiplier, configs.GameDifficultyDescription.AsteroidRatingSpan,
                configs.GameDifficultyDescription.StartHp);
            ShipData = new ShipData(configs.ShopDescription.ShipDescriptions);
            SaveModel = saveModel;
            GameLocationBoundaries = gameLocationBoundaries;
            PlayerData = new PlayerData();
            GameScoreData = new GameScoreData(configs.ScoreDescription.TimeScoreMultiplier, configs.ScoreDescription.KillScoreMultiplier);
            AsteroidData = new AsteroidData(configs.AsteroidDescription.AsteroidDescriptions, configs.AsteroidDescription.HugeToNormal, configs.AsteroidDescription.NormalToSmall, configs.AsteroidDescription.SpawnRate);
            ShotData = new ShotData(configs.ShotDescription.FireRate, configs.ShotDescription.ShotSpeed);
        }
    }
}