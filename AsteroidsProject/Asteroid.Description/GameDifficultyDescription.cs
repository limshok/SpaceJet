using System;

namespace Asteroid.Description
{
    [Serializable]
    public class GameDifficultyDescription
    {
        public int AsteroidRatingSpan;
        public float GameRatingSpanMultiplier;
        public float AsteroidSpawnRatingMultiplier;
        public int StartHp;
    }
}