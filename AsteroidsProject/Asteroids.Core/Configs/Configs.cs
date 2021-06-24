using Asteroid.Description;

namespace Asteroids.Core.Configs
{
    public class Configs
    {
        public readonly AsteroidDescription AsteroidDescription;
        public readonly ShotDescription ShotDescription;
        public readonly GameDifficultyDescription GameDifficultyDescription;
        public readonly ShopDescription ShopDescription;
        public readonly ScoreDescription ScoreDescription;

        public Configs(AsteroidDescription asteroidDescription, ShotDescription shotDescription, GameDifficultyDescription gameDifficultyDescription, ShopDescription shopDescription, ScoreDescription scoreDescription)
        {
            AsteroidDescription = asteroidDescription;
            ShotDescription = shotDescription;
            GameDifficultyDescription = gameDifficultyDescription;
            ShopDescription = shopDescription;
            ScoreDescription = scoreDescription;
        }
    }
}