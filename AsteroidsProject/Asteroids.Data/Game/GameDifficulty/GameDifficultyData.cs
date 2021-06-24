using System;

namespace Asteroids.Models.Game.GameDifficulty
{
    public class GameDifficultyData: IData
    {
        public event Action<float> OnSetSpawnTime;

        public float ShipRating;


        public readonly int AsteroidRatingSpan;
        public readonly int StartHp;
        public readonly float GameRatingSpanMultiplier;
        public readonly float SpawnRatingMultiplier;

        private Random _random = new Random();

        public GameDifficultyData(float spawnRatingMultiplier, float gameRatingSpanMultiplier, int asteroidRatingSpan, int startHp)
        {
            SpawnRatingMultiplier = spawnRatingMultiplier;
            GameRatingSpanMultiplier = gameRatingSpanMultiplier;
            AsteroidRatingSpan = asteroidRatingSpan;
            StartHp = startHp;
        }

        public int GetHp()
        {
            float hpChance = _random.Next((int) ShipRating, (int) (ShipRating + AsteroidRatingSpan * GameRatingSpanMultiplier));
            var hp = Math.Truncate(hpChance / AsteroidRatingSpan) + StartHp;
            return (int) hp;
        }

        public void SetSpawnRate(float spawnRate)
        {
            OnSetSpawnTime?.Invoke(spawnRate);
        }
    }
}