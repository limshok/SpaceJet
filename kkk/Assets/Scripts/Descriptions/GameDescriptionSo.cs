using Asteroid.Description;
using UnityEngine;

namespace Descriptions
{
    [CreateAssetMenu(fileName = "GameDescription",menuName = "Create game description")]
    public class GameDescriptionSo : ScriptableObject
    {
        public AsteroidDescription asteroidDescription;
        public ShipDescription shipDescription;
        public ShotDescription shotDescription;
        public GameDifficultyDescription gameDifficultyDescription;
        public ShopDescription ShopDescription;
        public ScoreDescription ScoreDescription;
    }
}